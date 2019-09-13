Imports MC_Data
Imports DevExpress.XtraReports.UI
Public Class ReportViewerRA
    Dim EnvioBE As New EnvioBE
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Se inicializa los controles
        Me.Text = "VISTA PRELIMINAR"
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True

        'Se oculta los botones del visor de reporte
        RibbonControl1.ShowToolbarCustomizeItem = False
        RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        PrintPreviewRibbonPageGroup1.Visible = False
        PrintPreviewRibbonPageGroup6.Visible = False
    End Sub

    Private Sub ReportViewerRA_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ReportViewerRA_Load(sender As Object, e As EventArgs) Handles Me.Load
        '   Try
        'Se obtiene la Entidad del envio
        EnvioBE = EnvioDAO.GetByID(EnvioDAO.IDEnvio)

        'Se valida que exista usuarios asignados al reporte
        If EnvioBE.UsuarioItems Is Nothing Then
            Throw New Exception("El reporte no tiene usuarios asignados, no se puede visualizar.")
        End If

        'Se valida que exista un minimo de un local
        If EnvioBE.LocalItems Is Nothing Then
            Throw New Exception("El reporte no tiene locales asignados, no se puede visualizar.")
        End If

        'Se genera el reporte, solo se muestra el primer usuario
        Dim MiReporte As XtraReport
        MiReporte = ReportesDao.GetGeneraReportes(EnvioBE)
        '  MiReporte.CreateDocument()
        ' MiReporte.ShowPreview()
        'Se muestra el reporte
        DocumentViewer1.DocumentSource = MiReporte

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End Try
    End Sub
End Class