Imports MC_Data
Imports MC_Framework
Imports System.IO
Imports System.Diagnostics
Imports System.Configuration
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class opciReporteRRHH1
    Dim sLista As String = ""
    Dim sListarelojes As String = ""
    Dim sListaIPRelojes As String = ""
    Dim NombreArchivoReporte As String
    Dim bsempleados As New BindingSource
    Dim dtrelojes As New DataTable
    Dim Listas As New DataTable
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.Text = "REPORTE DE MARCACIONES - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False
        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(GridControl1)
        ControlesDevExpress.InitGridView(GridView1, False, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SELECCION", "seleccion", 80, True, ControlesDevExpress.eGridViewFormato.Ninguno, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "CODIGO", "codigo_unico", 50, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "MATRICULA", "matricula", 80, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "APELLIDO PATERNO", "apellido_paterno", 120, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "APELLIDO MATERNO", "apellido_materno", 120, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "NOMBRE", "nombre", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "PUESTO", "descripcion_puesto", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "UNIDAD FUNCIONAL", "nombre_unidad_funcional", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "GRUPO FUNCIONAL", "descripcion_grupo_funcional", 150, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ESTADO", "situacion", 80, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ipmarcador", "ipmarcador", 80, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)

        'Filtro por cualquier campo
        With GridView1
            .Columns("codigo_unico").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("matricula").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("apellido_paterno").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("apellido_materno").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("nombre").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("descripcion_puesto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("nombre_unidad_funcional").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("descripcion_grupo_funcional").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With

        'Se configura el control GridControl
        'ControlesDevExpress.InitGridLookUpEditSearch(slelocalesmarcacion, EmpleadoDao.GetByAllListaLocalesMarcacion, "desc_reloj", "UBICACION_REF", 100)

        'Se enlaza el binding con la grilla
        bsempleados.DataSource = EmpleadoDao.GetByAllEmpleados(UsuarioBE.IDUsuario)
        GridControl1.DataSource = bsempleados
        NombreArchivoReporte = ConfigurationManager.AppSettings("NombreArchivoReporte")
        chklocalesmarcacion.Properties.DataSource = EmpleadoDao.GetByAllListaLocalesMarcacion
        'slelocalesmarcacion.Properties.DataSource = EmpleadoDao.GetByAllListaLocalesMarcacion
        DateIni.DateTime = DateTime.Today.AddDays(-7)
        DateFin.DateTime = DateTime.Today
        dtrelojes.Columns.Add("Relojes", GetType(String))

        Listas.Columns.Add("codigo_unico", GetType(String))
        Listas.Columns.Add("ipmarcador", GetType(String))

        'cboagrupacion.SelectedIndex = 0
    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Try
            SplashScreenManager.ShowForm(GetType(WaitForm))
            Dim RPT As New rptReporteRecursosHumanos1 ' rptReporteOperacionCompra1 Report2 '
            If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
                MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            ObtenerListas()
            ObtenerListasDT(dtrelojes)
            If dtrelojes.Rows.Count > 0 Then
                RPT.DataSource = ReportesDAO.ReporteRRHH1_opc1(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), sListarelojes)
            ElseIf chklocal.Checked Then
                Listas.Clear()
                For j As Integer = 0 To GridView1.RowCount - 1
                    Dim SELECCIONLOCAL As Boolean
                    SELECCIONLOCAL = If(GridView1.GetRowCellValue(j, "seleccion").ToString = "False", 0, 1)
                    If SELECCIONLOCAL Then
                        Dim row As DataRow = Listas.NewRow
                        row.Item("codigo_unico") = GridView1.GetRowCellValue(j, "codigo_unico").ToString
                        row.Item("ipmarcador") = GridView1.GetRowCellValue(j, "ipmarcador").ToString
                        Listas.Rows.Add(row)
                    End If
                Next
                RPT.DataSource = ReportesDao.ReporteRRHH1_opc2(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), Listas)
                'RPT.DataSource = ReportesDAO.ReporteRRHH1_opc2(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), sListaIPRelojes)
            Else
                RPT.DataSource = ReportesDAO.ReporteRRHH1(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
            End If
            RPT.DataMember = "Reporte"
            RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
            RPT.XrLabel17.Text = "Reporte de Asistencias"
            ReporteView.DocumentViewer1.DocumentSource = RPT
            ReporteView.DocumentViewer1.Refresh()
            ReporteView.Show()
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
        End Try
    End Sub
    Private Function ObtenerListas() As String
        sLista = ""
        sListaIPRelojes = ""
        'GridView1.ClearColumnsFilter()
        'GridView1.FindFilterText = ""
        Dim xContLocal As Integer = 0
        Me.GridView1.PostEditor()
        Me.GridView1.CloseEditor()
        Me.GridView1.UpdateCurrentRow()
        For j As Integer = 0 To GridView1.RowCount - 1
            Dim SELECCIONLOCAL As Boolean
            SELECCIONLOCAL = If(GridView1.GetRowCellValue(j, "seleccion").ToString = "False", 0, 1)
            If SELECCIONLOCAL Then
                If xContLocal > 0 Then
                    sLista = sLista + ","
                    sListaIPRelojes = sListaIPRelojes + ","
                End If
                sLista = sLista + GridView1.GetRowCellValue(j, "codigo_unico").ToString
                sListaIPRelojes = sListaIPRelojes + GridView1.GetRowCellValue(j, "ipmarcador").ToString
                xContLocal = xContLocal + 1
            End If
        Next
        Return sLista
        Return sListaIPRelojes
    End Function
    Private Function ObtenerListasDT(ByVal dt As DataTable) As String
        sListarelojes = ""
        Dim xContLocal As Integer = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim SELECCIONLOCAL As Boolean
            SELECCIONLOCAL = dt.Rows(i)(0).ToString
            If xContLocal > 0 Then
                sListarelojes = sListarelojes + ","
            End If
            sListarelojes = sListarelojes + dt.Rows(i)(0).ToString
            xContLocal = xContLocal + 1
        Next
        Return sListarelojes
    End Function
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked Then
            CheckEdit1.Text = "Deseleccionar"
            Tools.MarcaGrilla(GridView1, "seleccion", True)
        Else
            CheckEdit1.Text = "Seleccionar"
            Tools.MarcaGrilla(GridView1, "seleccion", False)
        End If
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        SplashScreenManager.ShowForm(GetType(WaitForm))
        Dim DT As New DataTable
        Dim Ruta As String = Path.GetTempPath + NombreArchivoReporte + ".xlsx"
        ObtenerListas()
        ObtenerListasDT(dtrelojes)


        If chklocal.Checked = False Then
            DT = ReportesDAO.ReporteRRHH1(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        Else
            'DT = ReportesDAO.ReporteRRHH1_opc2(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text), sListaIPRelojes)
        End If

        Tools.ExportToExcel(DT, Ruta, "Hoja")
        Process.Start(Ruta)
        SplashScreenManager.CloseForm()
    End Sub

    Private Sub chklocalesmarcacion_EditValueChanged(sender As Object, e As EventArgs) Handles chklocalesmarcacion.EditValueChanged
        dtrelojes.Clear()
        Dim chk As CheckedComboBoxEdit = CType(sender, CheckedComboBoxEdit)

        For Each item As CheckedListBoxItem In chklocalesmarcacion.Properties.Items
            If item.CheckState = CheckState.Checked Then
                dtrelojes.Rows.Add(item.Value.ToString)
            End If
        Next item
    End Sub
End Class