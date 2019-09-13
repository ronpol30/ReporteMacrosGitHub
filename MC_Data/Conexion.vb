Imports System.Configuration
Imports System.Data.SqlClient
Public Class ConexionDAO

    Public Shared Function GetConexion_MC_CENTRAL() As String
        Dim strCnx As String = String.Empty
        strCnx = ConfigurationManager.ConnectionStrings("MC_CENTRAL_ConnectionString").ConnectionString
        Return strCnx
    End Function
    Public Shared Function GetConexion_MC_ADRYAN() As String
        Dim strCnx As String = String.Empty
        strCnx = ConfigurationManager.ConnectionStrings("MC_ADRYAN_ConnectionString").ConnectionString
        Return strCnx
    End Function
    Public Shared Function GetConexion_MC_LOCAL_INFOREST_ConnectionString() As String
        Dim strCnx As String = String.Empty
        strCnx = ConfigurationManager.ConnectionStrings("MC_LOCAL_INFOREST_ConnectionString").ConnectionString
        Return strCnx
    End Function
    Public Shared Function GetConexion_MC_LOCAL_ALMACEN_ConnectionString() As String
        Dim strCnx As String = String.Empty
        strCnx = ConfigurationManager.ConnectionStrings("MC_LOCAL_ALMACEN_ConnectionString").ConnectionString
        Return strCnx
    End Function
    Public Shared Function GetConexion_MC_COMPRAS() As String
        Dim strCnx As String = String.Empty
        strCnx = ConfigurationManager.ConnectionStrings("MC_COMPRAS_ConnectionString").ConnectionString
        Return strCnx
    End Function
    Public Shared Function Get_Tablas_Actualizar() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_Get_Tablas_Actualizar"
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)

        Catch ex As Exception
            Throw
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Shared Function Get_Data_Tabla_Actualizar(ByVal TablaActualizar As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_Get_Data_Tabla_Actualizar"
            .Parameters.Add("@TablaActualizar", SqlDbType.NVarChar, 100).Value = TablaActualizar
        End With
        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function

#Region "CodigoAntiguo"
    'Public Shared Function Set_Data_Tabla_Actualizar(ByVal query As String) As DataTable
    '    Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_LOCAL_INFOREST_ConnectionString)
    '    Dim cmd As New SqlCommand
    '    Dim dt As New DataTable

    '    With cmd
    '        .Connection = cnx
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MCRM_Set_Data_Tabla_Actualizar"
    '        .Parameters.Add("@query", SqlDbType.NVarChar, 2000).Value = query
    '    End With

    '    Try
    '        cnx.Open()
    '        dt.Load(cmd.ExecuteReader)

    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        If cnx.State = ConnectionState.Open Then
    '            cnx.Close()
    '        End If
    '    End Try
    '    Return dt
    'End Function
    'Public Shared Function Truncate_Table(ByVal query As String) As DataTable
    '    Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_LOCAL_INFOREST_ConnectionString)
    '    Dim cmd As New SqlCommand
    '    Dim dt As New DataTable

    '    With cmd
    '        .Connection = cnx
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MCRM_Truncate_Table"
    '        .Parameters.Add("@query", SqlDbType.NVarChar, 2000).Value = query
    '    End With

    '    Try
    '        cnx.Open()
    '        dt.Load(cmd.ExecuteReader)

    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        If cnx.State = ConnectionState.Open Then
    '            cnx.Close()
    '        End If
    '    End Try
    '    Return dt
    'End Function
    'Public Shared Function UpdateTabla(ByVal tabla As String) As Boolean
    '    Dim result As Boolean = False
    '    Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_LOCAL_INFOREST_ConnectionString)
    '    cnx.Open()
    '    Dim cmd As New SqlCommand
    '    With cmd
    '        .Connection = cnx
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "MCRM_UPDATE_TABLA"
    '        .Parameters.Add("@tabla", SqlDbType.NVarChar, 100).Value = tabla
    '    End With

    '    Try
    '        cmd.ExecuteNonQuery()
    '        result = True
    '    Catch ex As Exception
    '        result = False
    '    Finally
    '        If cnx.State = ConnectionState.Open Then
    '            cnx.Close()
    '        End If
    '    End Try
    '    Return result
    'End Function
#End Region
End Class
