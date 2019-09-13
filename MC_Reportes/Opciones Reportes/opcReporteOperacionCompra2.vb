Imports MC_Data
Imports MC_Framework

Public Class opcReporteOperacionCompra2
    Private Sub opcReporteOperacionCompra2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bsLocales As New BindingSource

        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(GridControl1)

        'Se configura el control GridView
        ControlesDevExpress.InitGridView(GridView1)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ID", "IDLOCAL", 50, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SELEC", "SELECCION", 50, True, ControlesDevExpress.eGridViewFormato.Check, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "RAZON COMERCIAL", "RAZONCOMERCIAL", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "RAZON SOCIAL", "RAZONSOCIAL", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "TIPO LOCAL", "TIPOLOCAL", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "UBICACION", "UBICACION", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ESTADO", "ESTADO", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SUPERVISOR", "SUPERVISOR", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "JEFE ZONAL", "JEFEZONAL", 150, True, ControlesDevExpress.eGridViewFormato.Numero, False)

        'Filtro por cualquier campo
        With GridView1
            .Columns("RAZONCOMERCIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("RAZONSOCIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("TIPOLOCAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("UBICACION").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("ESTADO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("SUPERVISOR").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("JEFEZONAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With

        'Se enlace el binding con la grilla
        bsLocales.DataSource = LocalDAO.GetByAllLocal()
        GridControl1.DataSource = bsLocales
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
        SplashScreenManager.ShowForm(GetType(WaitForm))

        Dim RPT As New rptReporteOperacionCompra2
        Dim sLista As String = ""

        'Controla los datos ingresados
        'If Not Tools.CampoObligatorio(cbodetallado, Tools.eValidaControl.ComboBoxEdit) Then
        '    Return
        'End If
        If Convert.ToDateTime(DateIni.Text + " " + TimeIni.Text) >= Convert.ToDateTime(DateFin.Text + " " + TimeFin.Text) Then
            MessageBox.Show("Error en rango de fechas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Me.GridView1.PostEditor()
        Me.GridView1.CloseEditor()
        Me.GridView1.UpdateCurrentRow()

        Dim xContLocal As Integer = 0

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



        RPT.DataSource = ReportesDAO.ReporteOperacionCompra2(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel17.Text = "Lista de Locales"

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()

        SplashScreenManager.CloseForm()
    End Sub
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs)
        If CheckEdit1.Checked Then
            CheckEdit1.Text = "Deseleccionar"
            Tools.MarcaGrilla(GridView1, "SELECCION", True)
        Else
            CheckEdit1.Text = "Seleccionar"
            Tools.MarcaGrilla(GridView1, "SELECCION", False)
        End If
    End Sub

End Class
