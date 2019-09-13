Public Class EnvioLogDetailsDelete 

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Se inicializa los controles
        Me.Text = "ELIMINACION DE LOG DE ENVIOS"
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True
        Me.Icon = DesktopMenu.Icon

        'Se establece por defecto las fechas
        dtpFechaInicial.EditValue = DateTime.Now
        dtpFechaFinal.EditValue = DateTime.Now

    End Sub

    Private Sub EnvioLogDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
   
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try
            If MessageBox.Show("¿Esta seguro de eliminar el registro del log de envios de reportes?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                EnvioDAO.DeleteLog(dtpFechaInicial.EditValue, dtpFechaFinal.EditValue)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class