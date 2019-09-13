Imports MC_FRAMEWORK
Imports MCRA_DATA
Imports DevExpress.XtraEditors

Public Class BaseDatosDetails
    Dim BaseDatosBE As New BaseDatoBE

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Se inicializa los controles
        Me.Text = "MANTENIMIENTO DE BASE DE DATOS"
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True

        Me.txtIDBaseDatos.Enabled = False
        Me.txtNombre.Properties.MaxLength = 100
        Me.txtCadenaConexion.Properties.MaxLength = 250

        'Se inicializa los controles
        ControlesDevExpress.InitRibbonControl(RibbonControl)

    End Sub

    Private Sub BaseDatosDetails_Load(sender As Object, e As EventArgs) Handles Me.Load

        If BaseDatosDAO.IDBaseDatos = 0 Then
            txtIDBaseDatos.Text = 0
        Else
            'Se carga la entidad
            BaseDatosBE = BaseDatosDAO.GetByID(BaseDatosDAO.IDBaseDatos)

            With BaseDatosBE
                txtIDBaseDatos.Text = .IDBaseDatos
                txtNombre.Text = .Nombre
                txtCadenaConexion.Text = .CadenaConexion
            End With
        End If

    End Sub
    Private Sub BaseDatosDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGuardar.ItemClick, btnGuardarCerrar.ItemClick

        Try
            If Validar() Then

                'Se guarda el registro
                BaseDatosDAO.Save(BaseDatosBE)

                'Se recupera el ID autogenerado
                txtIDBaseDatos.Text = BaseDatosDAO.IDBaseDatos

                'Si el boton es Guardar y Cerrar, entonces se cierra el formulario
                If e.Item.Caption = "Guardar y Cerrar" Then
                    Me.Close()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnProbarConexion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProbarConexion.ItemClick
        Dim cnx As New System.Data.SqlClient.SqlConnection

        Try
            If Validar() Then
                cnx.ConnectionString = BaseDatosBE.CadenaConexion
                cnx.Open()
                MessageBox.Show("La conexión fue exitosa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If

        End Try

    End Sub
    Private Sub btnCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCerrar.ItemClick
        Me.Close()
    End Sub

    Private Sub Control_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating, txtCadenaConexion.Validating
        With CType(sender, TextEdit)
            If .Text = "" Then
                .ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                .ErrorText = "El campo es obligatorio"
            End If
        End With
    End Sub
   
    Private Function Validar() As Boolean
        Dim Result As Boolean = False

        'Si no existe mensajes de error, entonces los controles estan validados
        If String.IsNullOrEmpty(txtNombre.ErrorText) AndAlso String.IsNullOrEmpty(txtCadenaConexion.ErrorText) Then

            'Se carga la entidad
            With BaseDatosBE
                .IDBaseDatos = txtIDBaseDatos.Text
                .Nombre = txtNombre.Text.ToString.Trim
                .CadenaConexion = txtCadenaConexion.Text.ToString.Trim
                .IDUsuario = 1
                .FechaRegistro = DateTime.Now
            End With

            Result = True
        Else
            MessageBox.Show("Es necesario ingresar los valores requeridos, antes de guardar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return Result
    End Function

    
End Class