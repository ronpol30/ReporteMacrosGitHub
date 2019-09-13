Imports MC_Data
Imports MC_Framework
Imports System.IO
Imports System.Text
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraEditors
Imports System.Diagnostics
Imports System.Configuration

Public Class opciReporteOperacionCompra1
    Dim sLista As String = ""
    Dim NombreArchivoReporte As String
    Public Sub New()
        Dim bsLocales As New BindingSource
        ' This call is required by the designer.
        InitializeComponent()
        Me.Text = "REPORTE DE COMPRAS - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False
        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(GridControl1)
        'Se configura el control GridView(gridView1)
        ControlesDevExpress.InitGridView(GridView1)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ID", "IDLOCAL", 50, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SELEC", "SELECCION", 50, True, ControlesDevExpress.eGridViewFormato.Check, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "RAZON COMERCIAL", "RAZONCOMERCIAL", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "RAZON SOCIAL", "RAZONSOCIAL", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "TIPO LOCAL", "TIPOLOCAL", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "UBICACION", "UBICACION", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ESTADO", "ESTADO", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SUPERVISOR", "SUPERVISOR", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "JEFE ZONAL", "JEFEZONAL", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        With GridView1
            .Columns("RAZONCOMERCIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("RAZONSOCIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("TIPOLOCAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("UBICACION").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("ESTADO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("SUPERVISOR").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("JEFEZONAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With
        'Se enlaza el binding con la grilla
        bsLocales.DataSource = LocalDAO.GetByAllLocal
        GridControl1.DataSource = bsLocales
        NombreArchivoReporte = ConfigurationManager.AppSettings("NombreArchivoReporte")
        ' Add any initialization after the InitializeComponent() call.
        DateIni.DateTime = DateTime.Today.AddDays(-7)
        DateFin.DateTime = DateTime.Today
        cboagrupacion.SelectedIndex = 0
    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If cboagrupacion.EditValue = 0 Then
            XArticulo()
        End If
        If cboagrupacion.EditValue = 1 Then
            XProveedor()
        End If
    End Sub
    Private Sub XArticulo()
        Try
            SplashScreenManager.ShowForm(GetType(WaitForm))
            Dim RPT As New rptReporteOperacionCompra1_Opc1 ' rptReporteOperacionCompra1
            If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
                MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            ObtenerListas()
            RPT.DataSource = ReportesDAO.ReporteOperacionCompra1(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
            RPT.DataMember = "Reporte"
            RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
            RPT.XrLabel17.Text = "Lista de Locales"
            ReporteView.DocumentViewer1.DocumentSource = RPT
            ReporteView.DocumentViewer1.Refresh()
            ReporteView.Show()
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
        End Try
    End Sub
    Private Sub XProveedor()
        Try
            SplashScreenManager.ShowForm(GetType(WaitForm))
            Dim RPT As New rptReporteOperacionCompra1_Opc2 ' rptReporteOperacionCompra1
            If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
                MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            ObtenerListas()
            RPT.DataSource = ReportesDAO.ReporteOperacionCompra1(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
            RPT.DataMember = "Reporte"
            RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
            RPT.XrLabel17.Text = "Lista de Locales"
            ReporteView.DocumentViewer1.DocumentSource = RPT
            ReporteView.DocumentViewer1.Refresh()
            ReporteView.Show()
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
        End Try
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        SplashScreenManager.ShowForm(GetType(WaitForm))
        Dim DT As New DataTable
        Dim Ruta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + NombreArchivoReporte + ".xlsx"
        'Path.GetTempPath + 
        ObtenerListas()
        DT = ReportesDAO.ReporteOperacionCompra1(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        Tools.ExportToExcel(DT, Ruta, "Hoja")
        Process.Start(Ruta)
        SplashScreenManager.CloseForm()
    End Sub
    Private Function ObtenerListas() As String
        GridView1.ClearColumnsFilter()
        GridView1.FindFilterText = ""
        Dim xContLocal As Integer = 0

        Me.GridView1.PostEditor()
        Me.GridView1.CloseEditor()
        Me.GridView1.UpdateCurrentRow()
        For j As Integer = 0 To GridView1.RowCount - 1
            Dim SELECCIONLOCAL As Boolean
            SELECCIONLOCAL = If(GridView1.GetRowCellValue(j, "SELECCION").ToString = "False", 0, 1)

            If SELECCIONLOCAL Then
                If xContLocal > 0 Then
                    sLista = sLista + ","
                End If
                sLista = sLista + GridView1.GetRowCellValue(j, "IDLOCAL").ToString
                xContLocal = xContLocal + 1
            End If
        Next
        Return sLista
    End Function
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked Then
            CheckEdit1.Text = "Deseleccionar"
            Tools.MarcaGrilla(GridView1, "SELECCION", True)
        Else
            CheckEdit1.Text = "Seleccionar"
            Tools.MarcaGrilla(GridView1, "SELECCION", False)
        End If
    End Sub
End Class