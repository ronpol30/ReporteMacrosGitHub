Imports System.Text
Imports MC_Framework
Imports System.Data.SqlClient
Imports System.Configuration
Imports DevExpress.XtraReports.UI
Public Class ReporteBE
    Property IDReporte As Int32
    Property Nombre As String
    Property ParametroFechas As Boolean
    Property ParametroHoras As Boolean
    Property ParametroLocales As Boolean

    Public Class UsuarioBaseDatos
        Property IDUsuario As Int32
        Property IDBaseDatos As Int32
    End Class
    Public Class ArchivoTXT
        Property Cabecera As String
        Property Detalle As String
    End Class
    Property ItemsUsuarioBaseDatos As List(Of UsuarioBaseDatos)
    End Class
Public Class ReportesDAO
    Property IDLocal As Int32
    Property CadenaConexion As String
    Property FechaInicial As Date
    Property FechaFinal As Date
    Property HoraInicial As TimeSpan
    Property HoraFinal As TimeSpan
    Property Locales As String
    Property DataReporte As DataTable
    Property NombreReporte As String
    Public Shared Function ReporteOperacionVenta1(ByVal NombreBD As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection("Data Source=192.168.6.99;Initial Catalog=" & NombreBD & ";User ID=desarrollo;Password=sistemas")
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RepMacroscem_ReporteOperacionVenta1"
            With .Parameters
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta2(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta2"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta2_Opc1(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta2_Opc1"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta2_Opc2(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta2_Opc2"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta3_Opc1(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta3_Opc1"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta3_Opc2(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta3_Opc2"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta4(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta4"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta5(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal cboTipo_documento As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta5"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
                .Add("@estadodocumento", SqlDbType.VarChar, 2).Value = cboTipo_documento
            End With
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
    Public Shared Function ReporteOperacionVenta5_Opc1(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta5_Opc1"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta5_Opc2(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta5_Opc2"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta5_Opc3(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta5_Opc3"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta5_Opc4(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta5_Opc4"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta5_Opc5(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta5_Opc5"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta6(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta6"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta7_GetDataLocales(ByVal Conexion As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal OpcionPeriodo As Integer, ByVal Turno As String, ByVal OpcionUsuario As String) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_LIQUIDACION_CAJERO"
            With .Parameters
                .Add("@opcionperiodo", SqlDbType.Int).Value = OpcionPeriodo
                .Add("@turno", SqlDbType.VarChar, 10).Value = Turno
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
                .Add("@opcionusuario", SqlDbType.VarChar, 100).Value = OpcionUsuario
            End With
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
    Public Shared Function ReporteOperacionVenta11(ByVal Conexion As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal opcioncliente As Boolean, ByVal opciondocumento As Boolean,
                                                   ByVal opcionestado As Boolean, ByVal opcionpago As Boolean, ByVal opcioncaja As Boolean, ByVal tIdentidad As String, ByVal ttipodocumento As String,
                                                   ByVal testadodocumento As String, ByVal ttipopago As String, ByVal tcaja As String, ByVal opciontiporeporte As Integer) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_REGISTRO_VENTAS"
            .CommandTimeout = 0
            With .Parameters
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
                .Add("@opcioncliente", SqlDbType.Bit).Value = opcioncliente
                .Add("@opciondocumentos", SqlDbType.Bit).Value = opciondocumento
                .Add("@opcionestado", SqlDbType.Bit).Value = opcionestado
                .Add("@opcionpago", SqlDbType.Bit).Value = opcionpago
                .Add("@opcioncaja", SqlDbType.Bit).Value = opcioncaja
                .Add("@tIdentidad", SqlDbType.VarChar, 15).Value = tIdentidad
                .Add("@ttipodocumento", SqlDbType.VarChar, 2).Value = ttipodocumento
                .Add("@testadodocumento", SqlDbType.VarChar, 2).Value = testadodocumento
                .Add("@ttipopago", SqlDbType.VarChar, 2).Value = ttipopago
                .Add("@tcaja", SqlDbType.VarChar, 3).Value = tcaja
                .Add("@opciontiporeporte", SqlDbType.Int).Value = opciontiporeporte
            End With
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
    Public Shared Function ReporteOperacionVenta11_Opc1(ByVal Conexion As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal opcioncliente As Boolean, ByVal opciondocumento As Boolean,
                                                   ByVal opcionestado As Boolean, ByVal opcionpago As Boolean, ByVal opcioncaja As Boolean, ByVal tIdentidad As String, ByVal ttipodocumento As String,
                                                   ByVal testadodocumento As String, ByVal ttipopago As String, ByVal tcaja As String,
                                                   ByVal opciontiporeporte As Integer, ByVal opcionpagoenabled As Boolean) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_REGISTRO_VENTAS"
            .CommandTimeout = 0
            With .Parameters
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
                .Add("@opcioncliente", SqlDbType.Bit).Value = opcioncliente
                .Add("@opciondocumentos", SqlDbType.Bit).Value = opciondocumento
                .Add("@opcionestado", SqlDbType.Bit).Value = opcionestado
                .Add("@opcionpago", SqlDbType.Bit).Value = opcionpago
                .Add("@opcioncaja", SqlDbType.Bit).Value = opcioncaja
                .Add("@tIdentidad", SqlDbType.VarChar, 15).Value = tIdentidad
                .Add("@ttipodocumento", SqlDbType.VarChar, 2).Value = ttipodocumento
                .Add("@testadodocumento", SqlDbType.VarChar, 2).Value = testadodocumento
                .Add("@ttipopago", SqlDbType.VarChar, 2).Value = ttipopago
                .Add("@tcaja", SqlDbType.VarChar, 3).Value = tcaja
                .Add("@opciontiporeporte", SqlDbType.Int).Value = opciontiporeporte
                .Add("@opcionpagoenabled", SqlDbType.Bit).Value = opcionpagoenabled
            End With
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
    Public Shared Function ReporteOperacionVenta11_Opc2(ByVal Conexion As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal opcioncliente As Boolean, ByVal opciondocumento As Boolean,
                                                   ByVal opcionestado As Boolean, ByVal opcionpago As Boolean, ByVal opcioncaja As Boolean, ByVal tIdentidad As String, ByVal ttipodocumento As String,
                                                   ByVal testadodocumento As String, ByVal ttipopago As String, ByVal tcaja As String,
                                                   ByVal opciontiporeporte As Integer) As DataTable
        Dim ConexionLocal As String = "Data Source=" + Conexion + ";Initial Catalog=INFOREST;User ID=desarrollo;Password=sistemas"
        Dim cnx As New SqlConnection(ConexionLocal)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_REGISTRO_VENTAS"
            .CommandTimeout = 0
            With .Parameters
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
                .Add("@opcioncliente", SqlDbType.Bit).Value = opcioncliente
                .Add("@opciondocumentos", SqlDbType.Bit).Value = opciondocumento
                .Add("@opcionestado", SqlDbType.Bit).Value = opcionestado
                .Add("@opcionpago", SqlDbType.Bit).Value = opcionpago
                .Add("@opcioncaja", SqlDbType.Bit).Value = opcioncaja
                .Add("@tIdentidad", SqlDbType.VarChar, 15).Value = tIdentidad
                .Add("@ttipodocumento", SqlDbType.VarChar, 2).Value = ttipodocumento
                .Add("@testadodocumento", SqlDbType.VarChar, 2).Value = testadodocumento
                .Add("@ttipopago", SqlDbType.VarChar, 2).Value = ttipopago
                .Add("@tcaja", SqlDbType.VarChar, 3).Value = tcaja
                .Add("@opciontiporeporte", SqlDbType.Int).Value = opciontiporeporte
            End With
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
    Public Shared Function ReporteOperacionVenta7(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta6"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta8_Opc1(ByVal ListaLocal As String, ByVal ListaProducto As String, ByVal tipo_documento As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta8_Opc1"
            With .Parameters
                .Add("@ListaLocal", SqlDbType.VarChar).Value = ListaLocal
                .Add("@ListaProducto", SqlDbType.VarChar).Value = ListaProducto
                .Add("@tiporeporte", SqlDbType.Char, 1).Value = tipo_documento
                .Add("@FechaInicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@FechaFinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta8_Opc2(ByVal ListaLocal As String, ByVal ListaProducto As String, ByVal tipo_documento As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta8_Opc2"
            With .Parameters
                .Add("@ListaLocal", SqlDbType.VarChar).Value = ListaLocal
                .Add("@ListaProducto", SqlDbType.VarChar).Value = ListaProducto
                .Add("@tiporeporte", SqlDbType.Char, 1).Value = tipo_documento
                .Add("@FechaInicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@FechaFinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionCompra1(ByVal ListaLocal As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_COMPRAS)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_ReporteOperacionCompra1"
            .CommandTimeout = 0
            With .Parameters
                .Add("@ListaLocal", SqlDbType.VarChar).Value = ListaLocal
                '.Add("@ListaArticulo", SqlDbType.VarChar).Value = ListaArticulo
                .Add("@FechaInicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@FechaFinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionCompra2(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionCompra2"
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionCompra3(ByVal Lista As String, ByVal ListaArticulos As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionCompra3"
            .CommandTimeout = 0
            With .Parameters
                .Add("@ListaLocal", SqlDbType.VarChar).Value = Lista
                .Add("@ListaArticulos", SqlDbType.VarChar).Value = ListaArticulos
            End With
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
    Public Shared Function ReporteOperacionCompra4(ByVal idlocal As Integer, ByVal idmes As Integer) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_COMPRAS)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_ReporteOperacionCompra4"
            .CommandTimeout = 0
            With .Parameters
                .Add("@idmes", SqlDbType.Int).Value = idmes
                .Add("@idlocal", SqlDbType.Int).Value = idlocal
            End With
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
    Public Shared Function ReporteContabilidad1(ByVal BDALMACEN As String, ByVal anio As String, ByVal mes As String, ByVal ruc As String, ByVal periodo As String, ByVal razonsocial As String, ByVal establecimiento As String, ByVal direccion As String) As DataTable
        Dim cnx As New SqlConnection("Data Source=192.168.6.98;Initial Catalog=" + BDALMACEN + ";User ID=desarrollo;Password=sistemas")
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_CONTABLE_TXT_UNIDADES_REPORTE"
            .CommandTimeout = 0
            With .Parameters
                .Add("@anio", SqlDbType.VarChar, 4).Value = anio
                .Add("@mes", SqlDbType.VarChar, 2).Value = mes
                .Add("@ruc", SqlDbType.VarChar, 11).Value = ruc
                .Add("@periodo", SqlDbType.VarChar, 20).Value = periodo
                .Add("@razonsocial", SqlDbType.VarChar, 100).Value = razonsocial
                .Add("@establecimiento", SqlDbType.VarChar, 100).Value = establecimiento
                .Add("@direccion", SqlDbType.VarChar, 500).Value = direccion
            End With
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
    Public Shared Function ReporteOperacionVenta10_Opc1(ByVal Lista As String, ByVal fechainiacial As String, ByVal fechafinal As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta10_Opc1"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainiacial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta10_Opc2(ByVal Lista As String, ByVal fechainiacial As String, ByVal fechafinal As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta10_Opc2"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainiacial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta10_Opc3(ByVal Lista As String, ByVal fechainiacial As String, ByVal fechafinal As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta10_Opc3"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainiacial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta10_Opc4(ByVal Lista As String, ByVal fechainiacial As String, ByVal fechafinal As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta10_Opc4"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainiacial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteOperacionVenta10_Opc5(ByVal Lista As String, ByVal fechainiacial As String, ByVal fechafinal As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_UneBD_ReporteOperacionVenta10_Opc5"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainiacial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteRRHH1(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_ADRYAN)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_ReporteRRHH1"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
            End With
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
    Public Shared Function ReporteRRHH1_opc1(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal Listarelojes As String) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_ADRYAN)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_ReporteRRHH1_opc1"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@fechainicial", SqlDbType.DateTime).Value = fechainicial
                .Add("@fechafinal", SqlDbType.DateTime).Value = fechafinal
                .Add("@ListaRelojes", SqlDbType.VarChar).Value = Listarelojes
            End With
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
    Public Shared Function ReporteRRHH1_opc2(ByVal Lista As String, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal XML As DataTable) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_ADRYAN)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_ReporteRRHH1_opc2"
            .CommandTimeout = 0
            With .Parameters
                .Add("@Lista", SqlDbType.VarChar).Value = Lista
                .Add("@FECHAINICIAL", SqlDbType.DateTime).Value = fechainicial
                .Add("@FECHAFINAL", SqlDbType.DateTime).Value = fechafinal
                .Add("@XML", SqlDbType.VarChar).Value = Tools.ConvertXMLLocalesBaseDatos(XML)
            End With
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
    Public Function GetListarMesContable() As DataTable
        'Dim cnx As New SqlConnection(CadenaConexion)
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_COMPRAS)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_LISTAR_MES_CONTABLE"
            .CommandTimeout = 0
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            ' Throw ex
            MsgBox(ex.ToString)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function


    Public Function GetByReportes() As List(Of ReporteBE)
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader = Nothing

        Dim Lista As New List(Of ReporteBE)

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_REPORTE_GET_ALL"
        End With

        Try
            cnx.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                Dim BE As ReporteBE
                While dr.Read()
                    BE = New ReporteBE

                    With BE
                        .IDReporte = dr("IDReporte")
                        .Nombre = dr("Nombre")
                        .ParametroFechas = dr("ParametroFechas")
                        .ParametroHoras = dr("ParametroHoras")
                        .ParametroLocales = dr("ParametroLocales")
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
    Public Function GetGeneraReportes(EnvioBE As EnvioBE) As XtraReport
        Dim EnvioDAO As New EnvioDAO
        Dim BaseDatosDAO As New BaseDatos.BaseDatosDAO
        Dim BaseDatosBE As New BaseDatos.BaseDatosBE

        'Se obtiene la fecha inicial del reporte, dependiendo si es Diaria, Semanal o Mensual
        Select Case EnvioBE.FrecuenciaEnvio
            Case "D"
                FechaInicial = DateTime.Now.Date
                FechaFinal = DateTime.Now.Date.AddDays(1)
                HoraInicial = EnvioBE.IntervaloHoraInicial
                HoraFinal = EnvioBE.IntervaloHoraFinal
            Case "S"
                If DateTime.Now.Date.DayOfWeek = EnvioBE.IntervaloDiaEnvio Then
                    FechaInicial = DateTime.Now.Date.AddDays(-7)
                    FechaFinal = FechaInicial.Date.AddDays(7)
                    HoraInicial = EnvioBE.IntervaloHoraInicial
                    HoraFinal = EnvioBE.IntervaloHoraFinal
                End If
            Case "M"
                If DateTime.Now.Date.Day = EnvioBE.IntervaloDiaEnvio Then
                    FechaInicial = DateTime.Now.Date
                    FechaFinal = FechaInicial.Date.AddDays(1)
                End If
        End Select

        'Se establece los locales en formato XML
        Locales = EnvioDAO.ConvertXMLLocal(EnvioBE.LocalItems)

        'Se obtiene la cadena de conexion
        'BaseDatosBE = BaseDatosDAO.GetByID(EnvioBE.UsuarioItems(0).IDBasedatos)
        'CadenaConexion = BaseDatosBE.CadenaConexion

        '  BaseDatosBE = BaseDatosDAO.GetByID(IDBaseDatos)
        CadenaConexion = BaseDatosBE.CadenaConexion

        'Se instancia la clase del reporte y se carga la plantilla
        Dim MiReporte As XtraReport = Nothing

        'Se genera el datatable del reporte y se retorna para la visualizacion
        Select Case EnvioBE.IDReporte
            Case 1
                MiReporte = XtraReport.FromFile(ConfigurationManager.AppSettings("CarpetaReportesPlantillas") & "ReporteDemo.repx", True)
                'Se establece la fuente de datos
                MiReporte.DataSource = ReporteDemo()
                MiReporte.DataMember = "MCRA_REPORTE_DEMO"
            Case 2
                MiReporte = XtraReport.FromFile(ConfigurationManager.AppSettings("CarpetaReportesPlantillas") & "ReporteVentas.repx", True)
                MiReporte.DataSource = ReporteDemo() 'ReporteDemoVenta("")
                MiReporte.DataMember = "MCRA_REPORTE_DEMO"
            Case 3
                MiReporte = XtraReport.FromFile(ConfigurationManager.AppSettings("CarpetaReportesPlantillas") & "ReporteCortesias.repx", True)
                MiReporte.DataSource = ReporteCortesias()
                MiReporte.DataMember = "MCRA_REPORTE_CORTESIAS"
            Case 4
                MiReporte = XtraReport.FromFile(ConfigurationManager.AppSettings("CarpetaReportesPlantillas") & "ReporteEgresos.repx", True)
                MiReporte.DataSource = ReporteEgresos()
                MiReporte.DataMember = "MCRA_REPORTE_EGRESOS"
            Case 5
                MiReporte = XtraReport.FromFile(ConfigurationManager.AppSettings("CarpetaReportesPlantillas") & "ReporteEgresos.repx", True)
                MiReporte.DataSource = ReporteEgresos()
                MiReporte.DataMember = "MCRA_REPORTE_EGRESOS"
        End Select

        'Se establece los valores de los parametros
        'MiReporte.Parameters("RangoIntervalo").Value = ToString("desde") ' "Desde " & Me.FechaInicial & " - " & Me.HoraInicial.ToString & " Hasta " & Me.FechaFinal & " - " & Me.HoraFinal.ToString
        'MiReporte.Parameters("Usuario").Value = ErrorToString("Usuario:") '& EnvioBE.UsuarioItems(0).NombreUsuario

        'Se crea el documento
        MiReporte.CreateDocument()
        Return MiReporte
    End Function
    Private Function ReporteDemo() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_REPORTE_DEMO"
            .Parameters.Add("@FECHAINICIAL", SqlDbType.Date).Value = FechaInicial
            .Parameters.Add("@FECHAFINAL", SqlDbType.Date).Value = FechaFinal
            .Parameters.Add("@HORAINICIAL", SqlDbType.Time).Value = HoraInicial
            .Parameters.Add("@HORAFINAL", SqlDbType.Time).Value = HoraFinal
            .Parameters.Add("@LOCALES", SqlDbType.Xml).Value = Locales
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
    'Reporte demo Ventas 
    Private Function ReporteDemoVenta(ByVal NombreBD As String) As DataTable
        Dim cnx As New SqlConnection("Data Source=192.168.6.99;Initial Catalog=" & NombreBD & ";User ID=desarrollo;Password=sistemas")
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_ReporteVentas_Pruebas"
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
    Private Function ReporteCortesias() As DataTable
        'Dim cnx As New SqlConnection(CadenaConexion)
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_REPORTE_CORTESIAS"
            .CommandTimeout = 0
            .Parameters.Add("@FECHAINICIAL", SqlDbType.Date).Value = FechaInicial
            .Parameters.Add("@FECHAFINAL", SqlDbType.Date).Value = FechaFinal
            .Parameters.Add("@HORAINICIAL", SqlDbType.Time).Value = HoraInicial
            .Parameters.Add("@HORAFINAL", SqlDbType.Time).Value = HoraFinal
            .Parameters.Add("@LOCALES", SqlDbType.Xml).Value = Locales
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            ' Throw ex
            MsgBox(ex.ToString)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Private Function ReporteEgresos() As DataTable
        'Dim cnx As New SqlConnection(CadenaConexion)
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRA_REPORTE_EGRESOS"
            .CommandTimeout = 0
            .Parameters.Add("@FECHAINICIAL", SqlDbType.Date).Value = FechaInicial
            .Parameters.Add("@FECHAFINAL", SqlDbType.Date).Value = FechaFinal
            .Parameters.Add("@HORAINICIAL", SqlDbType.Time).Value = HoraInicial
            .Parameters.Add("@HORAFINAL", SqlDbType.Time).Value = HoraFinal
            .Parameters.Add("@LOCALES", SqlDbType.Xml).Value = Locales
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
        Catch ex As Exception
            ' Throw ex
            MsgBox(ex.ToString)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return dt
    End Function
    Public Function MCRM_REPORTE_INVENTARIO_PERMANENTE_TXT_NOMBRE(ByVal ruc As String, ByVal anio As String, ByVal mes As String, ByVal bdalmacen As String) As String
        Dim Nombre As New StringBuilder
        Dim cnx As New SqlConnection("Data Source=192.168.6.98;Initial Catalog=" + bdalmacen + ";User ID=desarrollo;Password=sistemas")
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        If mes < 10 Then
            mes = "0" + mes
        End If
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_CONTABLE_TXT_UNIDADES_CABECERA"
            .CommandTimeout = 0
            With .Parameters
                .Add("@ruc", SqlDbType.VarChar, 11).Value = ruc
                .Add("@anio", SqlDbType.VarChar, 4).Value = anio
                .Add("@mes", SqlDbType.VarChar, 2).Value = mes
            End With
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
            For Each dr As DataRow In dt.Rows
                Nombre.Append(dr(0))
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return Nombre.ToString
    End Function
    Public Function MCRM_REPORTE_INVENTARIO_PERMANENTE_TXT(ByVal mes As String, ByVal anio As String, ByVal BDALMACEN As String) As String
        Dim Detalle As New StringBuilder
        Dim cnx As New SqlConnection("Data Source=192.168.6.98;Initial Catalog=" + BDALMACEN + ";User ID=desarrollo;Password=sistemas")
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        If mes < 10 Then
            mes = "0" + mes
        End If
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_CONTABLE_TXT_UNIDADES_DETALLE"
            .CommandTimeout = 0
            With .Parameters
                .Add("@mes", SqlDbType.VarChar, 2).Value = mes
                .Add("@anio", SqlDbType.VarChar, 4).Value = anio
            End With
        End With

        Try
            cnx.Open()
            dt.Load(cmd.ExecuteReader)
            For Each dr As DataRow In dt.Rows
                Detalle.AppendLine(dr(0))
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        End Try
        Return Detalle.ToString
    End Function
    Public Shared Function MCCDC_ARTICULO_GET_ALL() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_COMPRAS)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCCDC_ARTICULO_GET_ALL"
            .CommandTimeout = 0
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
    Public Shared Function MCRM_LOCAL_LIST_CONTABLE_DETALLE(ByVal idlocal As Integer) As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_LOCAL_LIST_CONTABLE_DETALLE"
            .CommandTimeout = 0
            With .Parameters
                .Add("@idlocal", SqlDbType.Int).Value = idlocal
            End With
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
    Public Shared Function MCRM_MES_CONTABLE_LIST() As DataTable
        Dim cnx As New SqlConnection(ConexionDAO.GetConexion_MC_CENTRAL)
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        With cmd
            .Connection = cnx
            .CommandType = CommandType.StoredProcedure
            .CommandText = "MCRM_MES_CONTABLE_LIST"
            .CommandTimeout = 0
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
