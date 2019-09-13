Imports System.Data
Imports System.Data.SqlClient
Public Class BaseDatos
    Public Class BaseDatosBE
        Property IDBaseDatos As Int32
        Property Nombre As String
        Property CadenaConexion As String
        Property IDUsuario As Int32
        Property FechaRegistro As DateTime
    End Class

    Public Class BaseDatosDAO
        Property IDBaseDatos As Int32

        Public Function Save(BE As BaseDatosBE) As Int32
            Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
            Dim cmd As New SqlCommand
            Dim Result As Int32 = 0

            With cmd
                .Connection = cnx
                .CommandType = CommandType.StoredProcedure

                If BE.IDBaseDatos = 0 Then
                    .CommandText = "MCRA_BASE_DATOS_INS"
                    .Parameters.Add("@IDBASEDATOS", SqlDbType.Int).Direction = ParameterDirection.Output
                Else
                    .CommandText = "MCRA_BASE_DATOS_UPD"
                    .Parameters.Add("@IDBASEDATOS", SqlDbType.Int).Value = BE.IDBaseDatos
                End If

                With .Parameters
                    .Add("@NOMBRE", SqlDbType.VarChar, 100).Value = BE.Nombre
                    .Add("@CADENACONEXION", SqlDbType.VarChar, 250).Value = BE.CadenaConexion
                    .Add("@FECHAREGISTRO", SqlDbType.DateTime).Value = BE.FechaRegistro
                    .Add("@IDUSUARIO", SqlDbType.Int).Value = BE.IDBaseDatos
                End With
            End With

            Try
                cnx.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    IDBaseDatos = cmd.Parameters("@IDBASEDATOS").Value
                End If
            Catch ex As Exception
                Throw
            Finally
                If cnx.State = ConnectionState.Open Then
                    cnx.Close()
                End If
            End Try

            Return IDBaseDatos
        End Function
        Public Function Delete(ByVal IDBaseDatos As Int32) As Boolean
            Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
            Dim cmd As New SqlCommand
            Dim Result As Boolean = False

            With cmd
                .Connection = cnx
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MCRA_BASE_DATOS_DEL"

                With .Parameters
                    .Add("@IDBASEDATOS", SqlDbType.Int).Value = IDBaseDatos
                End With
            End With

            Try
                cnx.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    Result = True
                End If
            Catch ex As Exception
                Throw
            Finally
                If cnx.State = ConnectionState.Open Then
                    cnx.Close()
                End If
            End Try
            Return Result
        End Function

        Public Function GetBaseDatos() As DataTable
            Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
            Dim cmd As New SqlCommand
            Dim dt As New DataTable

            With cmd
                .Connection = cnx
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MCRA_BASE_DATOS_GET_ALL"
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
        Public Function GetByID(ByVal IDBaseDatos As Int32) As BaseDatosBE
            Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader = Nothing
            Dim BE As New BaseDatosBE

            With cmd
                .Connection = cnx
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MCRA_BASE_DATOS_GET_ID"

                With .Parameters
                    .Add("@IDBASEDATOS", SqlDbType.Int).Value = IDBaseDatos
                End With
            End With

            Try
                cnx.Open()
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    While dr.Read()
                        With BE
                            .IDBaseDatos = dr("IDBASEDATOS")
                            .Nombre = dr("NOMBRE")
                            .CadenaConexion = dr("CADENACONEXION")
                            .FechaRegistro = dr("FECHAREGISTRO")
                            .IDUsuario = dr("IDUSUARIO")
                        End With
                    End While
                    dr.Close()
                End If
            Catch ex As Exception
                Throw
            Finally
                If cnx.State = ConnectionState.Open Then
                    cnx.Close()
                End If
            End Try
            Return BE
        End Function

    End Class

End Class
