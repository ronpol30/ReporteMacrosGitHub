Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Xml
Public Class LocalBE
    Public Property IDLocal As Int32
    Public Property RazonComercial As String
    Public Property RazonSocial As String
    Public Property BDInforest As String
    Public Property BDAlmacen As String
    Public Property Ruc As String
    Public Property Direccion As String
End Class
Public Class LocalDAO
    Dim estadoconexion As Boolean
    'Variables Globales
    Public CarpetaXML As String = ConfigurationManager.AppSettings("CarpetaXML")
    Public RutaXML As String = My.Application.Info.DirectoryPath() + "\" + CarpetaXML
    Public Shared Function GetByAllLocal(ByVal Optional Tipo As Boolean = True) As DataTable
        Dim Conexion As String
        If Tipo = False Then 'Se Conecta Localmente
            Conexion = ConexionDAO.GetConexion_MC_LOCAL_INFOREST_ConnectionString
        Else
            Conexion = ConexionDAO.GetConexion_MC_CENTRAL
        End If
        Dim cnx As New SqlConnection(Conexion)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MC_LOCAL_LIST"
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
    Public Shared Function GetByAllLocalXMLGrid(ByVal Idusuario As Integer) As DataTable
        Dim xmlFile As XmlReader
        Dim xmlFileLocal As XmlReader
        Dim ds As New DataSet
        Dim dslocal As New DataSet
        Dim dtlocales As New DataTable

        With dtlocales.Columns
            .Add("IdLocal", GetType(Integer))
            .Add("RazonComercial", GetType(String))
            .Add("Ruc", GetType(String))
            .Add("RazonSocial", GetType(String))
            .Add("TipoLocal", GetType(String))
            .Add("Ubicacion", GetType(String))
            .Add("Estado", GetType(String))
            .Add("Correo", GetType(String))
            .Add("IpServer", GetType(String))
            .Add("BDInforest", GetType(String))
            .Add("BDAlmacen", GetType(String))
            .Add("Supervisor", GetType(String))
            .Add("JefeZonal", GetType(String))
            .Add("SELECCION", GetType(Boolean))
        End With

        Dim EstadoUsuario As Boolean = False
        xmlFile = XmlReader.Create(My.Application.Info.DirectoryPath() + "\" + ConfigurationManager.AppSettings("CarpetaXML") + "\MC_USUARIO_LOCAL.xml", New XmlReaderSettings())
        ds.ReadXml(xmlFile)

        xmlFileLocal = XmlReader.Create(My.Application.Info.DirectoryPath() + "\" + ConfigurationManager.AppSettings("CarpetaXML") + "\MC_LOCAL_LIST.xml", New XmlReaderSettings())
        dslocal.ReadXml(xmlFileLocal)

        For i = 0 To ds.Tables(0).Rows.Count - 1
            If Idusuario = ds.Tables(0).Rows(i).Item("idusuario") Then
                For j = 0 To dslocal.Tables(0).Rows.Count - 1
                    If dslocal.Tables(0).Rows(j).Item("IDLOCAL") = ds.Tables(0).Rows(i).Item("idlocal") Then
                        dtlocales.Rows.Add(dslocal.Tables(0).Rows(j).Item("IDLOCAL"), dslocal.Tables(0).Rows(j).Item("RAZONCOMERCIAL"), dslocal.Tables(0).Rows(j).Item("RUC"), dslocal.Tables(0).Rows(j).Item("RAZONSOCIAL"), dslocal.Tables(0).Rows(j).Item("TIPOLOCAL"), dslocal.Tables(0).Rows(j).Item("UBICACION"), dslocal.Tables(0).Rows(j).Item("ESTADO"), dslocal.Tables(0).Rows(j).Item("CORREO"), dslocal.Tables(0).Rows(j).Item("IPSERVER"), dslocal.Tables(0).Rows(j).Item("BDINFOREST"), dslocal.Tables(0).Rows(j).Item("BDALMACEN"), dslocal.Tables(0).Rows(j).Item("SUPERVISOR"), dslocal.Tables(0).Rows(j).Item("JEFEZONAL"), dslocal.Tables(0).Rows(j).Item("SELECCION"))
                    End If
                Next
            End If
        Next
        Return dtlocales
    End Function
    Public Shared Function GetByAllLocalXML(ByVal Idusuario As Integer) As DataTable
        Dim xmlFile As XmlReader
        Dim xmlFileLocal As XmlReader
        Dim ds As New DataSet
        Dim dslocal As New DataSet
        Dim dtlocales As New DataTable

        dtlocales.Columns.Add("IdLocal", GetType(Integer))
        dtlocales.Columns.Add("IpServer", GetType(String))
        dtlocales.Columns.Add("RazonComercial", GetType(String))
        dtlocales.Columns.Add("bdinforest", GetType(String))
        dtlocales.Columns.Add("bdalmacen", GetType(String))
        Dim EstadoUsuario As Boolean = False
        xmlFile = XmlReader.Create(My.Application.Info.DirectoryPath() + "\" + ConfigurationManager.AppSettings("CarpetaXML") + "\MC_USUARIO_LOCAL.xml", New XmlReaderSettings())
        ds.ReadXml(xmlFile)
        xmlFileLocal = XmlReader.Create(My.Application.Info.DirectoryPath() + "\" + ConfigurationManager.AppSettings("CarpetaXML") + "\MC_LOCAL.xml", New XmlReaderSettings())
        dslocal.ReadXml(xmlFileLocal)


        For i = 0 To ds.Tables(0).Rows.Count - 1
            If Idusuario = ds.Tables(0).Rows(i).Item("idusuario") Then
                For j = 0 To dslocal.Tables(0).Rows.Count - 1
                    If dslocal.Tables(0).Rows(j).Item("IdLocal") = ds.Tables(0).Rows(i).Item("idlocal") Then
                        dtlocales.Rows.Add(dslocal.Tables(0).Rows(j).Item("IdLocal"), dslocal.Tables(0).Rows(j).Item("IpServer"), dslocal.Tables(0).Rows(j).Item("RazonComercial"), dslocal.Tables(0).Rows(j).Item("bdinforest"), dslocal.Tables(0).Rows(j).Item("bdalmacen"))
                    End If
                Next
            End If
        Next
        Return dtlocales
    End Function
    Public Shared Function GetByAllProducto() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MC_PRODUCTO_LIST"
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
    Public Shared Function GetByAllArticulo() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MC_ARTICULO_LIST"
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
    Public Shared Function GetByAllLocalRecursos() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MC_LOCAL_LIST"
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
    Public Function conexionLocal(ByRef Conexion As String) As Boolean
        Try
            Dim cnx As New SqlConnection
            cnx = New SqlConnection(Conexion)
            cnx.Open()
            estadoconexion = True
            cnx.Close()
        Catch ex As Exception
            estadoconexion = False
        End Try
        Return (estadoconexion)
    End Function
    Public Shared Function GetLocales(ByVal Optional idusuario As Integer = 0) As List(Of LocalBE)
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader = Nothing
        Dim Lista As New List(Of LocalBE)
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_LOCAL_GET_ALL"
            .Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = idusuario
        End With

        Try
            cnx.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                Dim BE As LocalBE
                While dr.Read()
                    BE = New LocalBE

                    With BE
                        .IDLocal = dr("IDLOCAL")
                        .RazonComercial = dr("RAZONCOMERCIAL")
                    End With

                    Lista.Add(BE)
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
        Return Lista
    End Function
    Public Shared Function GetClientes(ByVal Conexion As String) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_CLIENTE_LIST"
        End With
        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw New Exception("Reporte " & vbCrLf & ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Shared Function GetTipoDocumento(ByVal Conexion As String) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_TIPO_DOCUMENTO_LIST"
        End With
        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw New Exception("Reporte " & vbCrLf & ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Shared Function GetEstadoDocumento(ByVal Conexion As String) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_ESTADO_DOCUMENTO_LIST"
        End With
        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw New Exception("Reporte " & vbCrLf & ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Shared Function GetTipoPago(ByVal Conexion As String) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_TIPO_PAGO_LIST"
        End With
        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw New Exception("Reporte " & vbCrLf & ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Shared Function GetCaja(ByVal Conexion As String) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_CAJA_LIST"
        End With
        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            Throw New Exception("Reporte " & vbCrLf & ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
End Class

