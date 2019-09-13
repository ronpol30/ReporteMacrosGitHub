Imports System.Diagnostics
Imports DevExpress.XtraEditors
Imports MC_Data
Imports MC_Framework
Public Class opciReporteContabilidad1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Text = "REGISTRO DEL INVENTARIO PERMANENTE EN UNIDADES FÍSICAS" '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False

        ControlesDevExpress.InitGridLookUpEditSearch(cboperiodo, ReportesDAO.MCRM_MES_CONTABLE_LIST, "IDMES", "MES", 90)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboperiodo, "Mes", "MES", 40, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboperiodo, "Año", "ANIO", 50, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cboperiodo, "IDMES", "IDMES", 40, False)
        ' Add any initialization after the InitializeComponent() call.
        ControlesDevExpress.InitGridLookUpEditSearch(cbolocal, LocalDAO.GetByAllLocal, "IDLOCAL", "RAZONCOMERCIAL", 550)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "IDLOCAL", "IDLOCAL", 40, False)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RAZON COMERCIAL", "RAZONCOMERCIAL", 150, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RAZON SOCIAL", "RAZONSOCIAL", 150, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "RUC", "RUC", 80, True)
        ControlesDevExpress.InitGridLookUpEditSearchColumns(cbolocal, "CONTABILIDAD", "CONTABILIDAD", 150, True)


    End Sub

    Private Sub btnemitir_Click(sender As Object, e As EventArgs) Handles btnemitir.Click
        If cboperiodo.EditValue Is Nothing Then
            XtraMessageBox.Show("Seleccion Periodo Contable")
        Else
            SplashScreenManager.ShowForm(GetType(WaitForm))

            SplashScreenManager.Default.SetWaitFormDescription("Emitiendo Inventario ...")
            SplashScreenManager.Default.SetWaitFormCaption("Por favor, espere")

            Dim RPT As New rptReporteContabilidad
            Dim sLista As String = ""
            Dim DTtmp As New DataTable
            Dim xContLocal As Integer = 0
            'DTtmp = ReportesDAO.ReporteContabilidad1(LocalBE.BDAlmacen, cboperiodo.GetSelectedDataRow("anio"), cboperiodo.GetSelectedDataRow("MES"), LocalBE.Ruc, cboperiodo.GetSelectedDataRow("anio") + " - " + cboperiodo.GetSelectedDataRow("MES"), LocalBE.RazonSocial, LocalBE.RazonComercial, LocalBE.Direccion)
            DTtmp = ReportesDAO.ReporteContabilidad1(cbolocal.GetSelectedDataRow("BDALMACEN"), cboperiodo.GetSelectedDataRow("ANIO"), cboperiodo.GetSelectedDataRow("IDMES"), cbolocal.GetSelectedDataRow("RUC"), cboperiodo.GetSelectedDataRow("ANIO") + " - " + cboperiodo.GetSelectedDataRow("IDMES"), cbolocal.GetSelectedDataRow("RAZONSOCIAL"), cbolocal.GetSelectedDataRow("RAZONCOMERCIAL"), cbolocal.GetSelectedDataRow("DIRECCION"))
            RPT.DataSource = DTtmp
            RPT.DataMember = "Reporte"
            RPT.XrLabel2.Text = "Local " + cbolocal.GetSelectedDataRow("RAZONCOMERCIAL") + " "
            RPT.XrLabel17.Text = "REGISTRO DEL INVENTARIO PERMANENTE EN UNIDADES FÍSICAS"
            ReporteView.DocumentViewer1.DocumentSource = RPT
            ReporteView.DocumentViewer1.Refresh()
            ReporteView.Show()
            SplashScreenManager.CloseForm()
        End If
    End Sub
    Private Sub btntxt_Click(sender As Object, e As EventArgs) Handles btntxt.Click
        If cboperiodo.EditValue Is Nothing Then
            XtraMessageBox.Show("Seleccion Periodo Contable")
        Else
            SplashScreenManager.ShowForm(GetType(WaitForm))
            SplashScreenManager.Default.SetWaitFormDescription("Emitiendo TXT")
            SplashScreenManager.Default.SetWaitFormCaption("Por favor, espere")
            Dim DtTXT As New DataTable
            Dim Nombre As String
            Dim Contenido As String
            Dim CarpetaLocal As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & cbolocal.GetSelectedDataRow("RAZONCOMERCIAL")
            Dim CarpetaMes As String = CarpetaLocal & "\" & (cboperiodo.GetSelectedDataRow("MES") + " - " + cboperiodo.GetSelectedDataRow("ANIO"))

            If My.Computer.FileSystem.DirectoryExists(CarpetaMes) Then
                '===Procedimiento
            Else
                ':::Si la carpeta no existe la creamos
                My.Computer.FileSystem.CreateDirectory(CarpetaMes)
            End If
            Nombre = CarpetaMes + "\" + ReportesDao.MCRM_REPORTE_INVENTARIO_PERMANENTE_TXT_NOMBRE(cbolocal.GetSelectedDataRow("RUC"), cboperiodo.GetSelectedDataRow("ANIO"), cboperiodo.GetSelectedDataRow("IDMES"), cbolocal.GetSelectedDataRow("BDALMACEN")) + ".txt"
            Contenido = ReportesDao.MCRM_REPORTE_INVENTARIO_PERMANENTE_TXT(cboperiodo.GetSelectedDataRow("IDMES"), cboperiodo.GetSelectedDataRow("ANIO"), cbolocal.GetSelectedDataRow("BDALMACEN"))
            'Se crea el archivo
            My.Computer.FileSystem.WriteAllText(Nombre, Contenido, False, System.Text.Encoding.ASCII)
            SplashScreenManager.CloseForm()
            XtraMessageBox.Show("Se genero el txt Correctamente")
            Process.Start("explorer.exe", CarpetaMes)
        End If
    End Sub
End Class