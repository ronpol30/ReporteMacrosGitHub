Imports MC_FRAMEWORK
Imports MCRA_DATA
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class EnvioLogDetails
    Dim bsLogEnvios As New BindingSource

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Se inicializa los controles
        Me.Text = "MANTENIMIENTO DE LOG DE ENVIOS"
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True
        Me.Icon = DesktopMenu.Icon

        'Se inicializa los controles
        ControlesDevExpress.InitRibbonControl(RibbonControl)

        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(gvLogEnvios)

        'Se configura el control GridView
        ControlesDevExpress.InitGridView(GridView1, False)
        ControlesDevExpress.InitGridViewColumn(GridView1, "IDLOG", "IDENVIOLOG", 30, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "REPORTE", "NOMBREREPORTE", 100, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "USUARIO", "NOMBREUSUARIO", 100, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "FECHA", "FECHAENVIO", 60, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "HORA", "HORAENVIO", 60, True)



    End Sub

    Private Sub EnvioLogDetails_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Se establece la fuente de datos del Bindding
        bsLogEnvios.DataSource = EnvioDAO.GetByEnviosLog

        'Se enlace el Binding con los controles
        gvLogEnvios.DataSource = bsLogEnvios
        
    End Sub
    Private Sub EnvioLogDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEliminar.ItemClick

        Dim MiForm As New EnvioLogDetailsDelete
        MiForm.ShowDialog()

        'Se establece la fuente de datos del Bindding
        bsLogEnvios.DataSource = EnvioDAO.GetByEnviosLog

    End Sub
    Private Sub btnCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCerrar.ItemClick
        Me.Close()
    End Sub
End Class