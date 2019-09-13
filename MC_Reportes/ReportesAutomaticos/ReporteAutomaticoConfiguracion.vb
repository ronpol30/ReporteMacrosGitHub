Imports MC_Framework
Imports MC_Data
Imports System.Configuration
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports DevExpress.XtraEditors

Public Class ReporteAutomaticoConfiguracion
    Dim bsEnvio As New BindingSource
    Dim LocalDao As New LocalDAO
    Sub New()
        If LocalDao.conexionLocal(ServidorCentral) Then
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            'Se configura el control GridView
            ControlesDevExpress.InitGridView(GridView1)
            ControlesDevExpress.InitGridViewColumn(GridView1, "ID", "IDENVIO", 20, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "IDREPORTE", "IDREPORTE", 50, False)
            ControlesDevExpress.InitGridViewColumn(GridView1, "REPORTE", "NOMBREREPORTE", 200, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "FECHA ENVIO", "FECHAINICIOENVIO", 80, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "HORA ENVIO", "HORAENVIO", 80, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "FRECUENCIA DE ENVIO", "FRECUENCIAENVIO", 120, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "ASUNTO", "ASUNTO", 250, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "MENSAJE", "MENSAJE", 250, True)
            ControlesDevExpress.InitGridViewColumn(GridView1, "ACTIVO", "ACTIVO", 250, False)
            ControlesDevExpress.InitGridViewColumn(GridView1, "USUARIO", "USUARIO", 150, True)

            'Se establece la fuente de datos del Binding
            bsEnvio.DataSource = EnvioDAO.GetByEnvios(UsuarioBE.IDUsuario)

            'Se enlace el binding con la grilla
            Me.GridControl1.DataSource = bsEnvio
        Else
            XtraMessageBox.Show("Error en la Conexion, volver a intentar en unos momentos...")
        End If
    End Sub

    Private Sub btnNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick
        'Se estable a cero para registro nuevo
        EnvioDAO.IDEnvio = 0

        Dim MiForm As New EnvioDetails
        MiForm.ShowDialog()

        'Se actualiza el Binding
        bsEnvio.DataSource = EnvioDAO.GetByEnvios(UsuarioBE.IDUsuario)
    End Sub

    Private Sub btnEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick

        'Se obtiene el ID Seleccionado
        EnvioDAO.IDEnvio = GridView1.GetFocusedRowCellValue("IDENVIO")

        'Se puede editar solo si el ID es diferente de cero
        If EnvioDAO.IDEnvio <> 0 Then

            Dim MiForm As New EnvioDetails
            MiForm.ShowDialog()

            'Se actualiza el Binding
            bsEnvio.DataSource = EnvioDAO.GetByEnvios(UsuarioBE.IDUsuario)
        End If
    End Sub

    Private Sub btnCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCerrar.ItemClick
        Close()
    End Sub

    Private Sub btnEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEliminar.ItemClick
        'Se obtiene el ID Seleccionado
        EnvioDAO.IDEnvio = GridView1.GetFocusedRowCellValue("IDENVIO")

        'Se puede eliminar, solo si el ID es diferente de cero
        If EnvioDAO.IDEnvio <> 0 Then
            If MessageBox.Show("Esta seguro de eliminar el registro ID: " & EnvioDAO.IDEnvio.ToString, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                'Se elimina el registro
                EnvioDAO.Delete(EnvioDAO.IDEnvio)

                'Se actualiza el Binding
                bsEnvio.DataSource = EnvioDAO.GetByEnvios(UsuarioBE.IDUsuario)
            End If
        End If
    End Sub

    Private Sub btnPrevisualizar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrevisualizar.ItemClick

        'Se obtiene el ID Seleccionado
        EnvioDAO.IDEnvio = GridView1.GetFocusedRowCellValue("IDENVIO")

        'Se puede editar solo si el ID es diferente de cero
        If EnvioDAO.IDEnvio <> 0 Then

            'Se muestra el Reporte
            Dim MiForm As New ReportViewerRA
            MiForm.WindowState = FormWindowState.Normal
            MiForm.ShowDialog()

            'Se actualiza el Binding
            bsEnvio.DataSource = EnvioDAO.GetByEnvios(UsuarioBE.IDUsuario)
        End If
    End Sub

    Private Sub btnEnviar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEnviar.ItemClick
        Dim EnvioBE As New EnvioBE

        If MessageBox.Show("¿Esta seguro de enviar el reporte vía correo electrónico a los usuarios?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        '  Try
        'Se obtiene el ID Seleccionado
        EnvioDAO.IDEnvio = GridView1.GetFocusedRowCellValue("IDENVIO")

        'Se obtiene la Entidad del envio
        EnvioBE = EnvioDAO.GetByID(EnvioDAO.IDEnvio)

        'Se valida que exista usuarios asignados al reporte
        If EnvioBE.UsuarioItems Is Nothing Then
            Throw New Exception("El reporte no tiene usuarios asignados, no se puede visualizar.")
        End If

        'Se valida que exista un minimo de un local
        If EnvioBE.LocalItems Is Nothing Then
            Throw New Exception("El reporte no tiene locales asignados, no se puede visualizar.")
        End If

        'Se repite este proceso por el numero de usuarios que se envia el correo
        For Each Item In EnvioBE.UsuarioItems

            'Se obtiene la carpeta Temporal
            Dim CarpetaTemporal As String = ConfigurationManager.AppSettings("CarpetaTemporalReportes")

            If Not Directory.Exists(CarpetaTemporal) Then
                Directory.CreateDirectory(CarpetaTemporal)
            End If

            'Se agrega el nombre del archivo PDF
            CarpetaTemporal &= EnvioBE.Nombre.Trim & "_" & Path.GetRandomFileName() & If(EnvioBE.FormatoReporte = "0", ".pdf", ".xls")

            'Se crea el reporte
            Dim MiReporte As New XtraReport
            MiReporte = ReportesDao.GetGeneraReportes(EnvioBE)

            'Se genera la plantilla de reporte en PDF=0 / Excel=1
            If EnvioBE.FormatoReporte = "0" Then
                MiReporte.ExportToPdf(CarpetaTemporal)
            Else
                MiReporte.ExportToXls(CarpetaTemporal)
            End If

            Dim ServidorSMTP As New System.Net.Mail.SmtpClient
            Dim Correo As New System.Net.Mail.MailMessage
            Dim Adjunto As System.Net.Mail.Attachment

            'Se obtiene los datos del correo de envio
            Dim CorreoEnvio As String = ConfigurationManager.AppSettings("Email")
            Dim CorreoEnvioContrasena As String = ConfigurationManager.AppSettings("EmailPassword")
            Dim CorreoEnvioServidor As String = ConfigurationManager.AppSettings("EmailServer")

            'Se configura el servidor SMTP
            With ServidorSMTP
                .Port = 25
                .Host = CorreoEnvioServidor
                .Credentials = New System.Net.NetworkCredential(CorreoEnvio, CorreoEnvioContrasena)
                .EnableSsl = False
            End With

            'Se asocia el archivo adjunto del correo
            Adjunto = New System.Net.Mail.Attachment(CarpetaTemporal)

            'Se configura el objeto correo
            With Correo
                .From = New System.Net.Mail.MailAddress(CorreoEnvio)
                .To.Add(Item.CorreoElectronico)
                .Subject = "MACROSCEM - REPORTES AUTOMATICOS " & EnvioBE.Asunto
                .Body = "<strong>Reportes Automaticos</strong><br> " & EnvioBE.Mensaje
                .IsBodyHtml = True
                .Priority = System.Net.Mail.MailPriority.Normal
                .Attachments.Add(Adjunto)
            End With

            'Se envia el correo electronico
            ServidorSMTP.Send(Correo)

            'Se espera unos cinco segundos por cada envio
            System.Threading.Thread.Sleep(5000)

            'Se configura la entidad del log
            Dim EnvioLogBE As New EnvioLogBE
            With EnvioLogBE
                .IDReporte = EnvioBE.IDEnvio
                .IDUsuario = Item.IDUsuario
                .FechaEnvio = DateTime.Now.Date
                .HoraEnvio = New TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0)
            End With

            'Se guarda el log
            EnvioDAO.SaveLog(EnvioLogBE)
        Next

        MessageBox.Show("El reporte se ha enviado a los usuarios.", "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & vbCrLf & ex.InnerException.ToString, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub ReporteAutomaticoConfiguracion_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        DesktopMain.Ribbon.SelectedPage = Me.RibbonPage1
    End Sub
End Class