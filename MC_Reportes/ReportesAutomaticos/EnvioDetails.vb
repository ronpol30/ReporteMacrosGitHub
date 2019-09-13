Imports MC_Framework
Imports MC_Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class EnvioDetails
    'Dim EnvioBE As New EnvioBE

    Dim bsUsuarioBaseDatos As New BindingSource
    Dim bsLocales As New BindingSource

    Dim ListaUsuarioBaseDatos As New List(Of EnvioUsuarioBE)
    Dim ListaLocales As New List(Of EnvioLocalBE)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Se inicializa los controles
        Me.Text = "MANTENIMIENTO DE ENVIOS"
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True

        ' Me.chklDiario.Enabled = True
        Me.rbtlSemanal.Enabled = False
        Me.lblDiaCorte.Enabled = False
        Me.cboMensual.Enabled = False
        Me.chkEnvioActivo.Checked = True
        Me.txtIDEnvio.Enabled = False

        Me.timHoraInicial.Properties.EditMask = "HH:mm"
        Me.timHoraFinal.Properties.EditMask = "HH:mm"
        Me.timHoraEnvio.Properties.EditMask = "HH:mm"
        Me.timHoraInicial.Properties.EditMask = "HH:mm"

        Me.dtpFechaInicioEnvio.EditValue = DateTime.Now.AddDays(1)

        'Se agrupa los periodos Diario, Semanal y Mensual
        Me.rbtDiario.Properties.RadioGroupIndex = 100
        Me.rbtSemanal.Properties.RadioGroupIndex = 100
        Me.rbtMensual.Properties.RadioGroupIndex = 100

        'Se inicializa los controles
        ControlesDevExpress.InitRibbonControl(RibbonControl)

        'Se inicializa el combo de mensualidad
        ControlesDevExpress.InitGridLookUpEdit(cboMensual, MensualDAO.GetMensual, "IDMensual", "Nombre")
        ControlesDevExpress.InitGridLookUpEditColumns(cboMensual, "NOMBRE", "Nombre", 100)
        cboMensual.EditValue = 0

        'Se inicializa el combo de usuarios
        ControlesDevExpress.InitGridLookUpEdit(cboUsuarios, UsuarioDao.GetUsuarios(UsuarioBE.IDUsuario), "IDUSUARIO", "NOMBRECOMPLETO")
        ControlesDevExpress.InitGridLookUpEditColumns(cboUsuarios, "ID", "IDUSUARIO", 50)
        ControlesDevExpress.InitGridLookUpEditColumns(cboUsuarios, "USUARIO", "NOMBRECOMPLETO", 250)
        cboUsuarios.EditValue = 0

        ''Se inicializa el combo de base de datos
        'ControlesDevExpress.InitGridLookUpEdit(cboBaseDatos, BaseDatosDAO.GetBaseDatos, "IDBASEDATOS", "NOMBRE")
        'ControlesDevExpress.InitGridLookUpEditColumns(cboBaseDatos, "ID", "IDBASEDATOS", 50)
        'ControlesDevExpress.InitGridLookUpEditColumns(cboBaseDatos, "BASE DE DATOS", "NOMBRE", 250)
        'cboBaseDatos.EditValue = 0

        'Se inicializa el combo de reportes
        ControlesDevExpress.InitGridLookUpEdit(cboReportes, ReportesDAO.GetByReportes, "IDReporte", "Nombre", 500)
        ControlesDevExpress.InitGridLookUpEditColumns(cboReportes, "ID", "IDReporte", 50)
        ControlesDevExpress.InitGridLookUpEditColumns(cboReportes, "REPORTE", "Nombre", 250)
        ControlesDevExpress.InitGridLookUpEditColumns(cboReportes, "FECHA", "ParametroFechas", 10, False)
        ControlesDevExpress.InitGridLookUpEditColumns(cboReportes, "HORA", "ParametroHoras", 10, False)
        ControlesDevExpress.InitGridLookUpEditColumns(cboReportes, "LOCALES", "ParametroLocales", 10, False)
        cboReportes.EditValue = 0

        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(gvUsuariosBaseDatos)

        'Se configura el control GridView
        ControlesDevExpress.InitGridView(GridView1, False)
        ' ControlesDevExpress.InitGridViewColumn(GridView1, "IDUSUARIO", "IDUsuario", 20, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "IDBASEDATOS", "IDBaseDatos", 20, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "USUARIO", "NombreUsuario", 250, True)
        'ControlesDevExpress.InitGridViewColumn(GridView1, "BASE DATOS", "NombreBaseDatos", 250, True)

        'Se configura el control CheckBoxItem
        chklLocales.ValueMember = "IdLocal"
        chklLocales.DisplayMember = "RazonComercial"

    End Sub

    Private Sub EnvioDetails_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Se establece la fuente de datos del Bindding
        bsUsuarioBaseDatos.DataSource = ListaUsuarioBaseDatos
        bsLocales.DataSource = LocalDAO.GetLocales(UsuarioBE.IDUsuario)

        'Se enlace el Binding con los controles
        gvUsuariosBaseDatos.DataSource = bsUsuarioBaseDatos
        chklLocales.DataSource = bsLocales

        'Se carga la entidad, si el IDEnvio es diferente de cero
        If EnvioDAO.IDEnvio = 0 Then
            txtIDEnvio.Text = 0
        Else
            EnvioBE = EnvioDAO.GetByID(EnvioDAO.IDEnvio)

            With EnvioBE
                txtIDEnvio.Text = .IDEnvio
                txtAsunto.Text = .Asunto
                txtMensaje.Text = .Mensaje
                timHoraInicial.EditValue = .IntervaloHoraInicial
                timHoraFinal.EditValue = .IntervaloHoraFinal
                timHoraEnvio.EditValue = .HoraEnvio
                cboReportes.EditValue = .IDReporte
                dtpFechaInicioEnvio.EditValue = .FechaInicioEnvio
                chkEnvioActivo.Checked = If(.Activo = 1, True, False)

                Select Case .FrecuenciaEnvio
                    Case "D"
                        rbtDiario.Checked = True
                    Case "S"
                        rbtSemanal.Checked = True
                        rbtlSemanal.SelectedIndex = Convert.ToInt16(.IntervaloDiaEnvio) - 1
                    Case "M"
                        rbtMensual.Checked = True
                        cboMensual.EditValue = .IntervaloDiaEnvio
                End Select

                rbtlFormatoReporte.SelectedIndex = Convert.ToInt16(.FormatoReporte)

            End With

            'Se carga la lista de Usuario y Base de datos
            If Not EnvioBE.UsuarioItems Is Nothing Then
                For Each Item In EnvioBE.UsuarioItems
                    ListaUsuarioBaseDatos.Add(New EnvioUsuarioBE With {.IDUsuario = Item.IDUsuario, .NombreUsuario = Item.NombreUsuario})
                Next
                gvUsuariosBaseDatos.RefreshDataSource()
            End If

            'Se carga la lista de Locales 
            If Not EnvioBE.LocalItems Is Nothing Then

                'Se marca todos los items
                For Index = 0 To chklLocales.ItemCount - 1

                    'Se convierte el objeto Item a LocalBE, solo se puede hacer si la fuente es una coleccion
                    Dim LocalBE As New LocalBE
                    LocalBE = CType(chklLocales.GetItem(Index), LocalBE)

                    'Se marca el local guardado
                    For Each Item2 In EnvioBE.LocalItems
                        If Item2.IDLocal = LocalBE.IDLocal Then
                            chklLocales.SetItemChecked(Index, True)
                        End If
                    Next
                Next
            End If

        End If
    End Sub

    Private Sub rbtSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSemanal.CheckedChanged
        rbtlSemanal.Enabled = rbtSemanal.Checked
    End Sub
    Private Sub rbtMensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbtMensual.CheckedChanged
        lblDiaCorte.Enabled = rbtMensual.Checked
        cboMensual.Enabled = rbtMensual.Checked
    End Sub

    Private Sub cboReportes_EditValueChanged(sender As Object, e As EventArgs) Handles cboReportes.EditValueChanged

        'Se obtiene la fila que contiene un objeto ReporteBE
        Dim dr As Object
        dr = cboReportes.Properties.GetRowByKeyValue(cboReportes.EditValue)

        If Not dr Is Nothing Then
            'Se conviente la fila en el objeto ReporteBE, solo funciona si el DataSource recibio una LISTA, en datatable no sirve
            Dim BE As New ReporteBE
            BE = CType(dr, ReporteBE)

            grpFecha.Enabled = BE.ParametroFechas
            grpHora.Enabled = BE.ParametroHoras
            grpLocal.Enabled = BE.ParametroLocales
        End If
    End Sub
    Private Sub cboReportes_EnabledChanged(sender As Object, e As EventArgs) Handles cboReportes.EnabledChanged

        If cboReportes.EditValue = 1 Then

        End If
    End Sub

    Private Sub btnGuardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGuardar.ItemClick, btnGuardarCerrar.ItemClick
        Try
            If Validar() Then
                'Se guarda el registro
                EnvioDAO.Save(EnvioBE)

                'Se recupera el ID autogenerado
                txtIDEnvio.Text = EnvioDAO.IDEnvio

                'Si el boton es Guardar y Cerrar, entonces se cierra el formulario
                If e.Item.Caption = "Guardar y Cerrar" Then
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCerrar.ItemClick
        Me.Close()
    End Sub

    Private Function Validar() As Boolean
        Dim Result As Boolean = False
        Dim IntervaloDiaEnvio As String = String.Empty
        Dim FormatoReporte As String = String.Empty

        'Si es diario, se establece 0 que es todos los dias de lunes a domingo
        If rbtDiario.Checked Then
            IntervaloDiaEnvio = "0"
        End If

        'Si es semanal, se obtiene un solo dia
        If rbtSemanal.Checked Then
            IntervaloDiaEnvio = rbtlSemanal.EditValue
        End If

        'Si es mensual, se obtiene un solo dia de corte, si el valor es cero es fin de mes
        If rbtMensual.Checked Then
            IntervaloDiaEnvio = cboMensual.EditValue
        End If

        'Se valida que este marcado un formato de reporte
        FormatoReporte = rbtlFormatoReporte.EditValue

        'Se obtiene todos los locales marcados CHECK
        For Each Item In chklLocales.CheckedItems

            'Se convierte el objeto Item a LocalBE, solo se puede hacer si la fuente es una coleccion
            Dim LocalBE As New LocalBE
            LocalBE = CType(Item, LocalBE)

            'Se agrega a la lista los locales seleccionados
            ListaLocales.Add(New EnvioLocalBE With {.IDLocal = LocalBE.IDLocal})
        Next

        'Si no existe mensajes de error, entonces los controles estan validados
        If String.IsNullOrEmpty(txtAsunto.ErrorText) AndAlso String.IsNullOrEmpty(txtMensaje.ErrorText) AndAlso FormatoReporte > -1 Then

            'Se carga la entidad
            With EnvioBE
                .IDEnvio = txtIDEnvio.Text
                .IDReporte = cboReportes.EditValue
                .FechaInicioEnvio = dtpFechaInicioEnvio.EditValue
                .HoraEnvio = timHoraEnvio.EditValue
                .FrecuenciaEnvio = If(rbtDiario.Checked, "D", If(rbtSemanal.Checked, "S", "M"))
                .IntervaloDiaEnvio = IntervaloDiaEnvio
                .IntervaloHoraInicial = timHoraInicial.EditValue
                .IntervaloHoraFinal = timHoraFinal.EditValue
                .Asunto = txtAsunto.Text.Trim
                .Mensaje = txtMensaje.Text.Trim
                .FormatoReporte = FormatoReporte
                .Activo = If(chkEnvioActivo.Checked, 1, 0)
                .IDUsuario = 1
                .FechaRegistro = DateTime.Now
                .UsuarioItems = ListaUsuarioBaseDatos
                .LocalItems = ListaLocales
            End With

            Result = True
        Else
            MessageBox.Show("Es necesario ingresar los valores requeridos, antes de guardar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Result
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        'Se valida que el combo Usuario y Base de Datos tengo minimo un elemento seleccionado
        If cboUsuarios.EditValue = 0 Then
            Exit Sub
        End If

        'Si no existe el IDUsuario e IDBaseDatos se agrega a la lista. El uso de un DATATABLE genera mas codigo que una Lista
        If ListaUsuarioBaseDatos.Where(Function(I) I.IDUsuario = cboUsuarios.EditValue).Count = 0 Then
            ListaUsuarioBaseDatos.Add(New EnvioUsuarioBE With {.IDUsuario = cboUsuarios.EditValue, .NombreUsuario = cboUsuarios.Text})
            gvUsuariosBaseDatos.RefreshDataSource()
        End If

    End Sub
    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        'Se puede eliminar, solo si el ID es diferente de cero
        If bsUsuarioBaseDatos.Count > 0 Then
            If MessageBox.Show("¿Esta seguro de eliminar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                bsUsuarioBaseDatos.RemoveCurrent()
            End If
        End If

    End Sub

    Private Sub timHoraFinal_EditValueChanged_1(sender As Object, e As EventArgs) Handles timHoraFinal.EditValueChanged
        'Se establece como hora de envio minimo la hora final del reporte
        timHoraEnvio.EditValue = timHoraFinal.EditValue
    End Sub
End Class