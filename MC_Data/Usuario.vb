Imports System.Data.SqlClient
Public Class UsuarioBE
    Public Property IDUsuario As Int32
    Public Property Nombres As String
    Public Property ApellidoPaterno As String
    Public Property ApellidoMaterno As String
    Public Property Usuario As String
    Public Property Contrasena As String
    Public Property idrol As String

End Class

Public Class UsuarioDAO
    Public Function GetByLoginPassword(ByVal NombreUsuario As String, ByVal Contrasena As String, ByVal Optional TipoConexion As Boolean = True) As UsuarioBE
        Dim Conexion As String
        If TipoConexion = False Then 'Se Conecta Localmente
            Conexion = ConexionDAO.GetConexion_MC_LOCAL_INFOREST_ConnectionString
        Else
            Conexion = ConexionDAO.GetConexion_MC_CENTRAL
        End If
        Dim cnx As New SqlConnection(Conexion)
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader = Nothing
        Dim UsuarioBE As New UsuarioBE
        Dim Lista As New List(Of String)

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MC_USUARIO_GET_LOGIN"
            .Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 20).Value = NombreUsuario
            .Parameters.Add("@Contrasena", SqlDbType.VarChar, 20).Value = Contrasena
        End With

        Try
            cnx.Open()
            dr = cmd.ExecuteReader


            If dr.HasRows Then
                While dr.Read()
                    With UsuarioBE
                        .IDUsuario = dr.ReadNullAsEmptyString("idusuario")
                        .Nombres = dr.ReadNullAsEmptyString("nombres")
                        .ApellidoPaterno = dr.ReadNullAsEmptyString("apellidopaterno")
                        .ApellidoMaterno = dr.ReadNullAsEmptyString("apellidomaterno")
                        .Usuario = dr.ReadNullAsEmptyString("nombreusuario")
                    End With
                End While

                dr.NextResult()

                ''Se carga la lista de permisos
                'While dr.Read()
                '    Lista.Add(dr("codpermiso"))
                'End While

                ''codigo agregado para obtener los permisos mediando el codigo de usuario


                'UsuarioBE.Permisos = Lista
                dr.Close()
            End If
        Catch ex As Exception
            Throw
        Finally
            cnx.Close()
        End Try
        Return UsuarioBE
    End Function
    Public Function GetUsuarios(Optional IdUsuario As Integer = 0) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_USUARIO_GET_ALL"
            .Parameters.Add("@idusuario", SqlDbType.Int).Value = IdUsuario
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw ex
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Function GetPermisos(ByVal IdUsuario As Integer, ByVal IDSistema As Integer) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCR_ACCESOS_ROL"
            .Parameters.Add("@idusuario", SqlDbType.Int).Value = IdUsuario
            .Parameters.Add("@idsistema", SqlDbType.Int).Value = IDSistema
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw ex
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Function GetModulos(ByVal idrol As Integer, ByVal IDSistema As Integer) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCR_ACCESOS_ROL_MODULO"
            .Parameters.Add("@idrol", SqlDbType.Int).Value = idrol
            .Parameters.Add("@idsistema", SqlDbType.Int).Value = IDSistema
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw ex
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Function GetSubModulos(ByVal idrol As Integer, ByVal IDSistema As Integer) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCR_ACCESOS_ROL_SUBMODULO"
            .Parameters.Add("@idrol", SqlDbType.Int).Value = idrol
            .Parameters.Add("@idsistema", SqlDbType.Int).Value = IDSistema
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw ex
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Function GetModulosXML(ByVal IdUsuario As Integer, ByVal IDSistema As Integer) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dtmodulo As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCR_ACCESOS_ROL_MODULO"
            .Parameters.Add("@idusuario", SqlDbType.Int).Value = IdUsuario
            .Parameters.Add("@idsistema", SqlDbType.Int).Value = IDSistema
        End With

        Try
            cnx.Open()
            dtmodulo.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw ex
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dtmodulo
    End Function
End Class

