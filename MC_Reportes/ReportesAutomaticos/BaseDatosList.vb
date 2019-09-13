Imports MC_FRAMEWORK
Imports MCRA_DATA
Imports System.ComponentModel

Public Class BaseDatosList
    Dim bsBaseDatos As New BindingSource

    Sub New()

        InitializeComponent()

        'Se inicializa los controles
        Me.Text = "REGISTROS DE BASE DE DATOS"
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True

        'Se inicializa los controles
        ControlesDevExpress.InitRibbonControl(RibbonControl)

        'Se configura el control GridControl
        ControlesDevExpress.InitGridControl(GridControl1)

        'Se configura el control GridView
        ControlesDevExpress.InitGridView(GridView1)
        ControlesDevExpress.InitGridViewColumn(GridView1, "ID", "IDBASEDATOS", 20, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "BASE DE DATOS", "NOMBRE", 250, True)
        ControlesDevExpress.InitGridViewColumn(GridView1, "CONEXION", "CADENACONEXION", 250, True)

        'Se establece la fuente de datos del Binding
        bsBaseDatos.DataSource = BaseDatosDAO.GetBaseDatos

        'Se enlace el binding con la grilla
        Me.GridControl1.DataSource = bsBaseDatos

    End Sub

    Private Sub btnNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick

        'Se estable a cero para registro nuevo
        BaseDatosDAO.IDBaseDatos = 0

        Dim MiForm As New BaseDatosDetails
        MiForm.ShowDialog()

        'Se actualiza el Binding
        bsBaseDatos.DataSource = BaseDatosDAO.GetBaseDatos

    End Sub
    Private Sub btnEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick

        'Se obtiene el ID Seleccionado
        BaseDatosDAO.IDBaseDatos = GridView1.GetFocusedRowCellValue("IDBASEDATOS")

        'Se puede editar solo si el ID es diferente de cero
        If BaseDatosDAO.IDBaseDatos <> 0 Then

            Dim MiForm As New BaseDatosDetails
            MiForm.ShowDialog()

            'Se actualiza el Binding
            bsBaseDatos.DataSource = BaseDatosDAO.GetBaseDatos
        End If

    End Sub
    Private Sub btnEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEliminar.ItemClick

        'Se obtiene el ID Seleccionado
        BaseDatosDAO.IDBaseDatos = GridView1.GetFocusedRowCellValue("IDBASEDATOS")

        'Se puede eliminar, solo si el ID es diferente de cero
        If BaseDatosDAO.IDBaseDatos <> 0 Then
            If MessageBox.Show("Esta seguro de eliminar el registro ID: " & BaseDatosDAO.IDBaseDatos.ToString, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                'Se elimina el registro
                BaseDatosDAO.Delete(BaseDatosDAO.IDBaseDatos)

                'Se actualiza el Binding
                bsBaseDatos.DataSource = BaseDatosDAO.GetBaseDatos
            End If
        End If

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick

        btnEditar.PerformClick()

    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnEditar.PerformClick()
        End If
    End Sub

End Class