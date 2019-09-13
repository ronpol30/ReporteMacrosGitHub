Imports MC_Data
Imports MC_Framework
Public Class opciReporteOperacionVenta1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Se inicializa los controles
        Me.Text = "REPORTE DOCUMENTO DETALLADO - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False
        ControlesDevExpress.InitGridLookUpEditSearch(cbolocal, LocalDAO.GetByAllLocalXMLGrid(UsuarioBE.IDUsuario), "IdLocal", "RazonComercial", 700)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RAZON COMERCIAL", "RazonComercial", 80, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "ID LOCAL", "IdLocal", 80, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "IPSERVER", "IpServer", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDINFOREST", "BDInforest", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDALMACEN", "BDAlmacen", 50, False)
        DateIni.DateTime = DateTime.Today.AddDays(-7)
        DateFin.DateTime = DateTime.Today
    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Reporte()
    End Sub
    Private Sub Reporte()
        Dim RPT As New rptReporteOperacionVenta1
        'Controla los datos ingresados
        If Not Tools.CampoObligatorio(cbolocal, Tools.eValidaControl.SearchLookUpEdit) Then
            Return
        End If

        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        SplashScreenManager.ShowForm(GetType(WaitForm))
        RPT.DataSource = ReportesDAO.ReporteOperacionVenta1(cbolocal.Properties.View.GetFocusedRowCellValue("BDInforest"), (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel17.Text = cbolocal.Properties.View.FocusedValue
        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        SplashScreenManager.CloseForm()
        ReporteView.Show()
    End Sub
End Class