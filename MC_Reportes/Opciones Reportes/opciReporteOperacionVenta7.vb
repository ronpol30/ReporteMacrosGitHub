Imports MC_Data
Imports MC_Framework
Public Class opciReporteOperacionVenta7
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Se inicializa los controles
        Me.Text = "LIQUIDACION DE CAJERO - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False
        ControlesDevExpress.InitGridLookUpEditSearch(cbolocal, LocalDAO.GetByAllLocalXMLGrid(UsuarioBE.IDUsuario), "IdLocal", "RazonComercial", 700)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RAZON COMERCIAL", "RazonComercial", 80, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "ID LOCAL", "IdLocal", 80, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "IPSERVER", "IpServer", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDINFOREST", "BDInforest", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDALMACEN", "BDAlmacen", 50, False)
        ' Add any initialization after the InitializeComponent() call.
        DateIni.DateTime = DateTime.Today.AddDays(-7)
        DateFin.DateTime = DateTime.Today
    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
        GridView1.ClearColumnsFilter()
        GridView1.FindFilterText = ""
        'Controla los datos ingresados
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        'Controla la Seleccion de un Tipo de Reporte
        If cbofiltro.EditValue = 1 Then
            SplashScreenManager.ShowForm(GetType(WaitForm))
            'Canal Venta
            FechaRegistro()
            SplashScreenManager.CloseForm()
        ElseIf cbofiltro.EditValue = 3 Then
            SplashScreenManager.ShowForm(GetType(WaitForm))
            'Medio de Pago
            Turno()
            SplashScreenManager.CloseForm()
        ElseIf cbofiltro.EditValue = 2 Then
            SplashScreenManager.ShowForm(GetType(WaitForm))
            'Tipo Documento
            FechaContable()
            SplashScreenManager.CloseForm()
        End If
    End Sub
    Private Sub FechaRegistro()
        Dim RPT As New rptReporteOperacionVenta7
        Dim sLista As String = ""
        Dim DTtmp As New DataTable
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim xContLocal As Integer = 0
        DTtmp = ReportesDao.ReporteOperacionVenta7_GetDataLocales(cbolocal.Properties.View.GetFocusedRowCellValue("IpServer"), (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), 2, "", "")
        RPT.DataSource = DTtmp
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel17.Text = "Lista de Locales"

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()
    End Sub
    Private Sub FechaContable()

    End Sub
    Private Sub Turno()

    End Sub
End Class