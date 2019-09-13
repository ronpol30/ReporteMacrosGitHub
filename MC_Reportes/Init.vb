Imports MC_Data
Imports System.Configuration
Module Init
    Public ServidorCentral As String = ConfigurationManager.ConnectionStrings("MC_CENTRAL_ConnectionString").ConnectionString
    Public TipoConexion As Boolean
    Public UsuarioBE As New UsuarioBE
    Public UsuarioDao As New UsuarioDAO
    Public EnvioDAO As New EnvioDAO
    Public EnvioBE As New EnvioBE
    Public BaseDatosBE As New BaseDatos.BaseDatosBE
    Public BaseDatosDao As New BaseDatos.BaseDatosDAO

    Public ReportesDao As New ReportesDAO

    Public MensualDAO As New Mensual.MensualDAO
    Public MensualBE As New Mensual.MensualBE

    Public LocalBE As New LocalBE
    Public LocalDAO As New LocalDAO
    ''Variables Globales
    'Public CarpetaXML As String = ConfigurationManager.AppSettings("CarpetaXML")
    'Public RutaXML As String = My.Application.Info.DirectoryPath() + "\" + CarpetaXML

End Module
