Imports System.Data.SqlClient
Imports MC_Framework
Public Class EmpleadoDao
    Public Shared Function GetByAllEmpleados(ByVal idusuario As Integer) As DataTable
        'Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_ADRYAN)
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MR_Lista_Trabajadores_Adryan"
            .Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario
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
    Public Shared Function GetByAllListaLocalesMarcacion() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_ADRYAN)
        'Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_LISTA_LOCALES_MARCACION"
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
    Public Shared Function GetByAllEmpleadosAsistencia(FechaInicial As Date, FechaFinal As Date, XMLEmpleados As DataTable) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_ADRYAN)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MR_Reporte_Asistencia_Adryan"
            .Parameters.Add("@FECHAINICIAL", SqlDbType.Date).Value = FechaInicial
            .Parameters.Add("@FECHAFINAL", SqlDbType.Date).Value = FechaFinal
            .Parameters.Add("@XMLEMPLEADO", SqlDbType.NVarChar, 100000).Value = Tools.ConvertXMLLocalesBaseDatos(XMLEmpleados)
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
End Class
