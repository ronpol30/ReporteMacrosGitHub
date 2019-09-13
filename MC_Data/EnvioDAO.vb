Imports System.Data.SqlClient
Public Class EnvioBE
    Public Property IDEnvio As Int32
    Public Property IDReporte As Int32
    Public Property Nombre As String
    Public Property FechaInicioEnvio As DateTime
    Public Property HoraEnvio As TimeSpan
    Public Property FrecuenciaEnvio As String
    Public Property IntervaloDiaEnvio As String
    Public Property IntervaloHoraInicial As TimeSpan
    Public Property IntervaloHoraFinal As TimeSpan
    Public Property Asunto As String
    Public Property Mensaje As String
    Public Property FormatoReporte As Int16
    Public Property Activo As Int32
    Public Property IDUsuario As Int32
    Public Property FechaRegistro As DateTime
    Public Property UsuarioItems As IList(Of EnvioUsuarioBE)
    Public Property LocalItems As IList(Of EnvioLocalBE)
End Class
Public Class EnvioUsuarioBE
    Public Property IDEnvioUsuario As Int32
    Public Property IDEnvio As Int32
    Public Property IDUsuario As Int32
    ' Public Property IDBasedatos As Int32
    Public Property NombreUsuario As String
    ' Public Property NombreBaseDatos As String
    Public Property CorreoElectronico As String
End Class
Public Class EnvioLocalBE
    Public Property IDEnvioLocal As Int32
    Public Property IDEnvio As Int32
    Public Property IDLocal As Int32
End Class
Public Class EnvioLogBE
    Public Property IDEnvioLog As Int32
    Public Property IDReporte As Int32
    Public Property IDUsuario As Int32
    Public Property FechaEnvio As DateTime
    Public Property HoraEnvio As TimeSpan
End Class

Public Class EnvioDAO
    Public Property IDEnvio As Int32 = 0
    Public Function Save(BE As EnvioBE) As Int32
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim Result As Int32 = 0

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure

            If BE.IDEnvio = 0 Then
                .CommandText = "MCRA_ENVIO_INS"
                .Parameters.Add("@IDENVIO", SqlDbType.Int).Direction = ParameterDirection.Output
            Else
                .CommandText = "MCRA_ENVIO_UPD"
                .Parameters.Add("@IDENVIO", SqlDbType.Int).Value = BE.IDEnvio
            End If

            With .Parameters
                .Add("@IDREPORTE", SqlDbType.Int).Value = BE.IDReporte
                .Add("@FECHAINICIOENVIO", SqlDbType.Date).Value = BE.FechaInicioEnvio
                .Add("@HORAENVIO", SqlDbType.Time).Value = BE.HoraEnvio
                .Add("@FRECUENCIAENVIO", SqlDbType.Char, 1).Value = BE.FrecuenciaEnvio
                .Add("@INTERVALODIAENVIO", SqlDbType.VarChar, 20).Value = BE.IntervaloDiaEnvio
                .Add("@INTERVALOHORAINICIAL", SqlDbType.Time).Value = BE.IntervaloHoraInicial
                .Add("@INTERVALOHORAFINAL", SqlDbType.Time).Value = BE.IntervaloHoraFinal
                .Add("@ASUNTO", SqlDbType.VarChar, 500).Value = BE.Asunto
                .Add("@MENSAJE", SqlDbType.VarChar, -1).Value = BE.Mensaje
                .Add("@FORMATOREPORTE", SqlDbType.Int).Value = BE.FormatoReporte
                .Add("@ACTIVO", SqlDbType.Int).Value = BE.Activo
                .Add("@USUARIOBASEDATOSXML", SqlDbType.Xml).Value = ConvertXMLUsuarioBaseDatos(BE.UsuarioItems)
                .Add("@LOCALXML", SqlDbType.Xml).Value = ConvertXMLLocal(BE.LocalItems)
                .Add("@IDUSUARIO", SqlDbType.Int).Value = BE.IDUsuario
                .Add("@FECHAREGISTRO", SqlDbType.DateTime).Value = BE.FechaRegistro
            End With
        End With

        Try
            cnx.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                IDEnvio = cmd.Parameters("@IDENVIO").Value
            End If
        Catch ex As Exception
            Throw
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try

        Return IDEnvio
    End Function
    Public Function Delete(ByVal IDEnvio As Int32) As Boolean
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim Result As Boolean = False

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_DEL"

            With .Parameters
                .Add("@IDEnvio", SqlDbType.Int).Value = IDEnvio
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

    Public Function SaveLog(BE As EnvioLogBE) As Int32
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim Result As Int32 = 0

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_LOG_INS"

            With .Parameters
                .Add("@IDENVIOLOG", SqlDbType.Int).Direction = ParameterDirection.Output
                .Add("@IDREPORTE", SqlDbType.Int).Value = BE.IDReporte
                .Add("@IDUSUARIO", SqlDbType.Int).Value = BE.IDUsuario
                .Add("@FECHAENVIO", SqlDbType.Date).Value = BE.FechaEnvio
                .Add("@HORAENVIO", SqlDbType.Time).Value = BE.HoraEnvio
            End With
        End With

        Try
            cnx.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Result = cmd.Parameters("@IDENVIOLOG").Value
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
    Public Function DeleteLog(FechaInicial As Date, FechaFinal As Date) As Boolean
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim Result As Boolean = False

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_LOG_DEL"

            With .Parameters
                .Add("@FECHAINICIAL", SqlDbType.Date).Value = FechaInicial
                .Add("@FECHAFINAL", SqlDbType.Date).Value = FechaFinal
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

    Public Function GetByID(ByVal IDEnvio As Int32) As EnvioBE
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader = Nothing
        Dim BE As New EnvioBE

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_GET_ID"

            With .Parameters
                .Add("@IDEnvio", SqlDbType.Int).Value = IDEnvio
            End With
        End With

        Try
            cnx.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read()
                    With BE
                        .IDEnvio = dr("IDEnvio")
                        .IDReporte = dr("IDReporte")
                        .Nombre = dr("Nombre")
                        .FechaInicioEnvio = dr("FechaInicioEnvio")
                        .HoraEnvio = dr("HoraEnvio")
                        .FrecuenciaEnvio = dr("FrecuenciaEnvio")
                        .IntervaloDiaEnvio = dr("IntervaloDiaEnvio")
                        .IntervaloHoraInicial = dr("IntervaloHoraInicial")
                        .IntervaloHoraFinal = dr("IntervaloHoraFinal")
                        .Mensaje = dr("Mensaje")
                        .FormatoReporte = dr("FormatoReporte")
                        .Asunto = dr("Asunto")
                        .Activo = dr("Activo")
                        .IDUsuario = dr("IDUsuario")
                        .FechaRegistro = dr("FechaRegistro")
                    End With
                End While

                dr.NextResult()

                'Se obtiene la lista de Usuarios y base de datos
                If dr.HasRows Then
                    Dim ListaUsuarios As New List(Of EnvioUsuarioBE)
                    Dim EnvioUsuarioBE As EnvioUsuarioBE
                    While dr.Read()

                        EnvioUsuarioBE = New EnvioUsuarioBE
                        With EnvioUsuarioBE
                            .IDEnvio = dr("IDEnvio")
                            .IDUsuario = dr("IDUsuario")
                            '   .IDBasedatos = dr("IDBaseDatos")
                            '   .NombreBaseDatos = dr("NOMBREBASEDATOS")
                            .NombreUsuario = dr("NOMBREUSUARIO")
                            .CorreoElectronico = dr("CORREOELECTRONICO")
                        End With
                        ListaUsuarios.Add(EnvioUsuarioBE)
                    End While
                    BE.UsuarioItems = ListaUsuarios
                End If

                dr.NextResult()

                'Se obtiene la lista de locales
                If dr.HasRows Then
                    Dim ListaLocales As New List(Of EnvioLocalBE)
                    Dim EnvioLocalBE As EnvioLocalBE
                    While dr.Read()

                        EnvioLocalBE = New EnvioLocalBE
                        With EnvioLocalBE
                            .IDEnvio = dr("IDEnvio")
                            .IDLocal = dr("IDLocal")
                        End With
                        ListaLocales.Add(EnvioLocalBE)
                    End While
                    BE.LocalItems = ListaLocales
                End If

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
    Public Function GetByEnvios(ByVal Optional idusuario As Integer = 0) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_GET_ALL"
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
    Public Function GetByEnviosLog() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_LOG_GET_ALL"
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
    Public Function GetByEnviosReportesAutomaticos() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ENVIO_REPORTES"
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


    Public Function ConvertXMLUsuarioBaseDatos(Lista As List(Of EnvioUsuarioBE)) As String

        'Se declara la variable Result como Object, si es cadena no muestra el XML
        Dim Result = New XElement("ITEMS",
                   From item In Lista
                   Select New XElement("ITEM", New XAttribute("IDUsuario", item.IDUsuario))) ', New XAttribute("IDBaseDatos", item.IDBasedatos)))

        Return Result.ToString
    End Function
    Public Function ConvertXMLLocal(Lista As List(Of EnvioLocalBE)) As String

        'Se declara la variable Result como Object, si es cadena no muestra el XML

        Dim Result = New XElement("ITEMS",
                   From item In Lista
                   Select New XElement("ITEM", New XAttribute("IDLocal", item.IDLocal)))
        Return Result.ToString
    End Function
End Class
