Imports MC_Data
Imports MC_Framework

Public Class opciReporteOperacionVenta6
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'Se inicializa los controles
        Me.Text = "REPORTE DE CORTESIAS - " '& SistemaDAO.NombreLocal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = DesktopMain.Icon
        Me.KeyPreview = False

        ' Add any initialization after the InitializeComponent() call.
        Dim bsLocales As New BindingSource

        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(GridControl1)

        'Se configura el control GridView
        ControlesDevExpress.InitGridView(GridView1)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ID", "IdLocal", 50, False, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SELEC", "SELECCION", 50, True, ControlesDevExpress.eGridViewFormato.Check, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "RAZON COMERCIAL", "RazonComercial", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "RAZON SOCIAL", "RazonSocial", 200, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "TIPO LOCAL", "TipoLocal", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "UBICACION", "Ubicacion", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ESTADO", "Estado", 100, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "SUPERVISOR", "Supervisor", 150, True, ControlesDevExpress.eGridViewFormato.Ninguno, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "JEFE ZONAL", "JefeZonal", 150, True, ControlesDevExpress.eGridViewFormato.Numero, False)

        'Filtro por cualquier campo
        With GridView1
            .Columns("RazonComercial").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("RazonSocial").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("TipoLocal").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("Ubicacion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("Estado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("Supervisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns("JefeZonal").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End With

        'Se enlace el binding con la grilla
        bsLocales.DataSource = LocalDAO.GetByAllLocalXMLGrid(UsuarioBE.IDUsuario)
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

        Dim RPT As New rptReporteOperacionVenta6
        Dim sLista As String = ""

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
                sLista = sLista + GridView1.GetRowCellValue(j, "IdLocal").ToString
                xContLocal = xContLocal + 1
            End If
        Next
        RPT.DataSource = ReportesDAO.ReporteOperacionVenta6(sLista, (DateIni.Text + " " + TimeIni.Text), (DateFin.Text + " " + TimeFin.Text))
        RPT.DataMember = "Reporte"

        RPT.XrLabel14.Text = "Reporte desde " + DateIni.Text + " " + TimeIni.Text + " hasta " + DateFin.Text + " " + TimeFin.Text
        RPT.XrLabel17.Text = "Lista de Locales"

        ReporteView.DocumentViewer1.DocumentSource = RPT
        ReporteView.DocumentViewer1.Refresh()
        ReporteView.Show()

        SplashScreenManager.CloseForm()
    End Sub
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