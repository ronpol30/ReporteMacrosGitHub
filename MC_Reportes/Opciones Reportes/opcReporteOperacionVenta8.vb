Imports DevExpress.XtraEditors
Imports MC_Data
Imports MC_Framework
Public Class opcReporteOperacionVenta8
    Private Sub opcReporteOperacionVenta8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bsLocales As New BindingSource
        Dim bsProductos As New BindingSource

        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(GridControl1)
        ControlesDevExpress.InitGridControl(GridControl2)

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

        'Se configura el control gridView(gridView2)
        ControlesDevExpress.InitGridView(GridView2)
        ControlesDevExpress.InitGridViewColumn(GridView2, "IDProducto", "IDProducto", 50, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView2, "SELECT", "SELECCION", 50, True, ControlesDevExpress.eGridViewFormato.Check, True)
        ControlesDevExpress.InitGridViewColumn(GridView2, "Producto", "NombreResumido", 320, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        'Filtro por cualquier campo de la tabla local
        With GridView1
            .Columns("RAZONCOMERCIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("RAZONSOCIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("TIPOLOCAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("UBICACION").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("ESTADO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("SUPERVISOR").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("JEFEZONAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With
        'Filtro por el nombre deñ producto de la tabla producto
        With GridView2
            .Columns("NombreResumido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With
        'Se enlasa el binding con la grida
        bsLocales.DataSource = LocalDAO.GetByAllLocal
        GridControl1.DataSource = bsLocales
        bsProductos.DataSource = LocalDAO.GetByAllProducto
        GridControl2.DataSource = bsProductos

        ' Add any initialization after the InitializeComponent() call.
        DateIni.DateTime = DateTime.Today.AddDays(-7)
        DateFin.DateTime = DateTime.Today
    End Sub
    Private Sub reports_productoxDia()

        Dim tipo_documento As String = ImageComboBoxEdit2.EditValue.ToString


        Dim RPT As New rptReporteOperacionVenta8_Opc1
        Dim xContLocal As Integer = 0
        Dim sLista As String = ""
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

        Dim xConProducto As Integer = 0
        Dim sListaProducto As String = ""
        Me.GridView2.PostEditor()
        Me.GridView2.CloseEditor()
        Me.GridView2.UpdateCurrentRow()
        For i As Integer = 0 To GridView2.RowCount - 1
            Dim SELECCIONPRODUCTO As Boolean
            SELECCIONPRODUCTO = If(GridView2.GetRowCellValue(i, "SELECCION").ToString = "False", 0, 1)
            If SELECCIONPRODUCTO Then
                If xConProducto > 0 Then
                    sListaProducto = sListaProducto + ","
                End If
                sListaProducto = sListaProducto + GridView2.GetRowCellValue(i, "IDProducto").ToString
                xConProducto = xConProducto + 1
            End If
        Next

        'Controla los datos ingresados
        'If Not Tools.CampoObligatorio(cbodetallado, Tools.eValidaControl.ComboBoxEdit) Then
        '    Return
        'End If
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        RPT.DataSource = ReportesDAO.ReporteOperacionVenta8_Opc1(sLista, sListaProducto, tipo_documento, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel17.Text = "Lista de Locales"

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()


        If DateIni.EditValue >= DateFin.EditValue Then
            XtraMessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


    End Sub
    Private Sub reports_productoMensual()
        Dim tipo_documento As String = ImageComboBoxEdit2.EditValue.ToString

        Dim RPT As New rptReporteOperacionVenta8_Opc2
        Dim xContLocal As Integer = 0
        Dim sLista As String = ""
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

        Dim xConProducto As Integer = 0
        Dim sListaProducto As String = ""
        Me.GridView2.PostEditor()
        Me.GridView2.CloseEditor()
        Me.GridView2.UpdateCurrentRow()
        For i As Integer = 0 To GridView2.RowCount - 1
            Dim SELECCIONPRODUCTO As Boolean
            SELECCIONPRODUCTO = If(GridView2.GetRowCellValue(i, "SELECCION").ToString = "False", 0, 1)
            If SELECCIONPRODUCTO Then
                If xConProducto > 0 Then
                    sListaProducto = sListaProducto + ","
                End If
                sListaProducto = sListaProducto + GridView2.GetRowCellValue(i, "IDProducto").ToString
                xConProducto = xConProducto + 1
            End If
        Next

        'Controla los datos ingresados
        'If Not Tools.CampoObligatorio(cbodetallado, Tools.eValidaControl.ComboBoxEdit) Then
        '    Return
        'End If
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        RPT.DataSource = ReportesDAO.ReporteOperacionVenta8_Opc2(sLista, sListaProducto, tipo_documento, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel17.Text = "Lista de Locales"

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()


        If DateIni.EditValue >= DateFin.EditValue Then
            XtraMessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
    End Sub
    Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click

        GridView1.ClearColumnsFilter()
        GridView1.FindFilterText = ""
        GridView2.ClearColumnsFilter()
        GridView2.FindFilterText = ""
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        'Controla la Seleccion de un Tipo de Reporte
        If ImageComboBoxEdit1.EditValue = 1 Then
            SplashScreenManager.ShowForm(GetType(WaitForm))
            'Paloteo Diario
            reports_productoxDia()
            SplashScreenManager.CloseForm()

        ElseIf ImageComboBoxEdit1.EditValue = 2 Then
            SplashScreenManager.ShowForm(GetType(WaitForm))
            'Paloteo Mensual
            reports_productoMensual()
            SplashScreenManager.CloseForm()
        Else
            XtraMessageBox.Show("Seleccion algun tipo de Reporte")
        End If

    End Sub


End Class
