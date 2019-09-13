Imports MC_Data
Imports MC_Framework
Public Class opciReporteOperacionCompra4
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Text = "REGISTRO DE COMPRAS - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False
        ControlesDevExpress.InitGridLookUpEditSearch(cbolocal, LocalDAO.GetByAllLocalXMLGrid(UsuarioBE.IDUsuario), "IdLocal", "RazonComercial", 700)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RAZON COMERCIAL", "RazonComercial", 80, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "ID LOCAL", "IdLocal", 80, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "IPSERVER", "IpServer", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDINFOREST", "BDInforest", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "BDALMACEN", "BDAlmacen", 50, False)

        ControlesDevExpress.InitGridLookUpEditSearch(cboPeriodo, ReportesDao.GetListarMesContable, "IDMesContable", "MesNombre", 90)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboPeriodo, "ID", "IDMesContable", 80, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboPeriodo, "Mes", "MesNombre", 40, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboPeriodo, "MesID", "Mes", 50, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboPeriodo, "Año", "anio", 40, True)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
        'Controla los datos ingresados

        'Controla la Seleccion de un Tipo de Reporte

        SplashScreenManager.ShowForm(GetType(WaitForm))
        'Canal Venta
        Dim RPT As New rptReporteOperacionCompra4
        Dim sLista As String = ""
        Dim DTtmp As New DataTable
        Dim xContLocal As Integer = 0
        DTtmp = ReportesDAO.ReporteOperacionCompra4(cbolocal.Properties.View.GetFocusedRowCellValue("IdLocal"), cboPeriodo.Properties.View.GetFocusedRowCellValue("IDMesContable"))
        RPT.DataSource = DTtmp
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte del Periodo " + cboPeriodo.Properties.View.GetFocusedRowCellValue("MesNombre") + " "
        RPT.XrLabel2.Text = "Local " + cbolocal.Properties.View.GetFocusedRowCellValue("RazonComercial") + " "

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()


        SplashScreenManager.CloseForm()

    End Sub
End Class