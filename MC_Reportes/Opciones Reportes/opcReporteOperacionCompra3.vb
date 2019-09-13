Imports MC_Data
Imports MC_Framework
Imports DevExpress.XtraEditors
Public Class opcReporteOperacionCompra3
    Dim codLocal() As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Dim bsLocales As New BindingSource
        Dim bsArticulo As New BindingSource

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
        ControlesDevExpress.InitGridViewColumn(GridView2, "IDArticulo", "IDArticulo", 50, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView2, "SELECT", "SELECCION", 50, True, ControlesDevExpress.eGridViewFormato.Check, True)
        ControlesDevExpress.InitGridViewColumn(GridView2, "FAMILIA", "nomFamilia", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView2, "SUB FAMILIA", "nomSubFamila", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView2, "ARTICULO", "nonArticulo", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
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
            .Columns("nomFamilia").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("nomSubFamila").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("nonArticulo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With
        'Se enlasa el binding con la grida
        bsLocales.DataSource = LocalDAO.GetByAllLocal
        GridControl1.DataSource = bsLocales

        bsArticulo.DataSource = LocalDAO.GetByAllArticulo
        GridControl2.DataSource = bsArticulo

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Private Sub btnEmitir_Click(sender As Object, e As EventArgs)


    'End Sub

    Private Sub btnEmitir_Click_1(sender As Object, e As EventArgs) Handles btnEmitir.Click
        Dim RPT As New rptReporteOperacionCompra3
        Dim xContLocal As Integer = 0
        GridView1.ClearColumnsFilter()
        GridView1.FindFilterText = ""
        GridView2.ClearColumnsFilter()
        GridView2.FindFilterText = ""
        ''GridView1.ClearColumnsFilter()
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

        Dim sConArticulo As Integer = 0
        Dim sListaArticulo As String = ""
        Me.GridView2.PostEditor()
        Me.GridView2.CloseEditor()
        Me.GridView2.UpdateCurrentRow()
        For i As Integer = 0 To GridView2.RowCount - 1
            Dim SELECCIONARTICULO As Boolean
            SELECCIONARTICULO = If(GridView2.GetRowCellValue(i, "SELECCION").ToString = "False", 0, 1)
            If SELECCIONARTICULO Then
                If sConArticulo > 0 Then
                    sListaArticulo = sListaArticulo + ","
                End If
                sListaArticulo = sListaArticulo + GridView2.GetRowCellValue(i, "IDArticulo").ToString
                sConArticulo = sConArticulo + 1
            End If
        Next
        'Controla los datos ingresados
        'If Not Tools.CampoObligatorio(cbodetallado, Tools.eValidaControl.ComboBoxEdit) Then
        '    Return


        RPT.DataSource = ReportesDAO.ReporteOperacionCompra3(sLista, sListaArticulo)
        RPT.DataMember = "Reporte"

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()

    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked Then
            CheckEdit2.Text = "Deseleccionar"
            Tools.MarcaGrilla(GridView1, "SELECCION", True)
        Else
            CheckEdit2.Text = "Seleccionar"
            Tools.MarcaGrilla(GridView1, "SELECCION", False)
        End If
    End Sub

End Class
