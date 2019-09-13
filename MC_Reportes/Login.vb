Imports System.Xml
Imports MC_Data
Imports MC_Framework
Imports DevExpress.LookAndFeel
Imports System.Diagnostics
Imports System.IO
Imports System.Configuration

Public Class Login
    'Dim UsuarioBE As New UsuarioBE
    Dim UsuarioDAO As New UsuarioDAO
    Dim LocalDao As New LocalDAO
    Dim Servidor_Central As String
    Dim EstadoActualizacion As Boolean
    'Dim CarpetaXML As String
    ' Dim LocalDao.RutaXML As String
    Public Sub New()
        InitializeComponent()
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.KeyPreview = True

        'Se inicializa los controles generales
        txtusuario.Properties.MaxLength = 15
        txtcontrasena.Properties.MaxLength = 15

        'Se ingresa solo letras, numeros y tres caracteres especiales
        txtusuario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        txtusuario.Properties.Mask.EditMask = "[a-zA-Z0-9_$@]*"
        txtcontrasena.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        txtcontrasena.Properties.Mask.EditMask = "[a-zA-Z0-9_$@]*"
        'Se asocia el evento KeyDown al procedimiento Teclado
        AddHandler Me.KeyDown, AddressOf Me.Teclado
        'CarpetaXML = ConfigurationManager.AppSettings("CarpetaXML")
        ' LocalDao.RutaXML = My.Application.Info.DirectoryPath() + "\" + CarpetaXML
        If Directory.Exists(LocalDao.RutaXML) = False Then
            Directory.CreateDirectory(LocalDao.RutaXML)
        End If
        'Servidor_Central = ConfigurationManager.ConnectionStrings("MC_CENTRAL_ConnectionString").ConnectionString
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(My.Settings.skin)
    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        If (LocalDao.conexionLocal(ServidorCentral)) Then 'Si existe conexion a Central
            TipoConexion = True 'Conexion 97
            If Not Tools.ValidaVersion(3) Then
                EstadoActualizacion = True
                Dim proces As New Process()
                MessageBox.Show("Se ha encontrado una versión mas actualizada del sistema" & Chr(13) & "Se esta procediendo a descargar la actualización", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Try
                    'Se pone la ruta a actualizar en duro porque puede haber errores cuando se instale los programas
                    My.Computer.Network.DownloadFile("https://actualizadores.blob.core.windows.net/reportes/Actualizador.zip", "actualizador.zip", "", "", True, 500, True)
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar, verificar si se tiene conexión a Internet", "Actualizador", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End Try
                proces.StartInfo.FileName = “Actualizador.exe”
                proces.Start()
                Me.Close()
            Else
                SplashScreenManager.ShowForm(GetType(SplashScreen1), True, True)
                MyBase.OnLoad(e)
                Dim dtTablasActualizar As New DataTable
                'If (LocalDao.conexionLocal(ServidorCentral)) Then 'Si existe conexion al local
                dtTablasActualizar = ConexionDAO.Get_Tablas_Actualizar() 'Obtengo las Tablas
                CrearXML(dtTablasActualizar)

                SplashScreenManager.CloseForm()
            End If
        Else
            TipoConexion = False 'Conexion Local
        End If
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Tools.ReadAppSettings("Usuario").Length > 0 Then
            txtusuario.Text = Tools.ReadAppSettings("Usuario")
            'Se activa el check
            chkrecordar.Checked = True
        End If
        'Solo para fines de desarrollo
        txtusuario.Text = "pquispe"
        txtcontrasena.Text = "JM240912"
    End Sub
    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        If Validar() Then
            If chkrecordar.Checked Then
                Tools.SaveAppSettings("Usuario", txtusuario.Text.Trim)
            Else
                Tools.SaveAppSettings("Usuario", "")
            End If
            'Lista Locales
            DesktopMain.Show()
            Me.Close()
        End If
    End Sub
    Private Function Teclado(sender As Object, e As KeyEventArgs) As KeyEventArgs
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F1
                MessageBox.Show("Ayuda no esta disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Select
        Return e
    End Function
    Private Function Validar() As Boolean
        Dim Result As Boolean = False
        Dim xmlFile As XmlReader
        Dim ds As New DataSet
        Dim EstadoUsuario As Boolean = False

        xmlFile = XmlReader.Create(LocalDao.RutaXML + "\MC_USUARIO.xml", New XmlReaderSettings())
        ds.ReadXml(xmlFile)

        Static NumIntentosLogin As Int16 = 0
        'Se carga la entidad
        With UsuarioBE
            .Usuario = txtusuario.Text
            .Contrasena = txtcontrasena.Text
        End With

        'Se valida los campos obligatorios
        If Tools.CampoObligatorio(txtusuario) Then
            If Tools.CampoObligatorio(txtcontrasena) Then
                Result = True
            End If
        End If

        If Result Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If UsuarioBE.Usuario.ToUpper = ds.Tables(0).Rows(i).Item("nombreusuario").ToString.ToUpper And UsuarioBE.Contrasena.ToUpper = ds.Tables(0).Rows(i).Item("contrasena").ToString.ToUpper Then
                    EstadoUsuario = True
                    UsuarioBE.IDUsuario = ds.Tables(0).Rows(i).Item("idusuario")
                    UsuarioBE.Nombres = ds.Tables(0).Rows(i).Item("nombres")
                    UsuarioBE.ApellidoPaterno = ds.Tables(0).Rows(i).Item("apellidopaterno")
                    UsuarioBE.idrol = ds.Tables(0).Rows(i).Item("idrol")
                End If
            Next
            'UsuarioBE = UsuarioDAO.GetByLoginPassword(UsuarioBE.Usuario, UsuarioBE.Contrasena, TipoConexion)
            'Se carga los datos del usuario y Sistema
            If NumIntentosLogin > 3 Then
                MessageBox.Show("Ha superado el numero de intentos de validación del usuario.Contacte con el área de sistemas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Exit()
            End If
            If EstadoUsuario = False Then
                NumIntentosLogin += 1
                txtusuario.ErrorIconAlignment = ErrorIconAlignment.MiddleRight
                txtusuario.ErrorText = "El nombre de usuario y contraseña no existe, intente con otro."
                txtcontrasena.Text = ""
                txtusuario.Focus()
                Result = False
            End If
        End If
        Return Result
    End Function
    Private Sub CrearXML(ByVal dt As DataTable)
        Dim dtDataTablasActualizar As New DataTable
        For i = 0 To dt.Rows.Count - 1
            dtDataTablasActualizar = ConexionDAO.Get_Data_Tabla_Actualizar(dt.Rows(i).Item("Nombre"))
            If dt.Rows(i).Item("Nombre") = "MC_LOCAL" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_LOCAL.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeLocal(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), dtDataTablasActualizar.Rows(j).Item(3), dtDataTablasActualizar.Rows(j).Item(4), dtDataTablasActualizar.Rows(j).Item(5), dtDataTablasActualizar.Rows(j).Item(6), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            End If

            If dt.Rows(i).Item("Nombre") = "MC_USUARIO" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_USUARIO.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeUsuario(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), dtDataTablasActualizar.Rows(j).Item(3), dtDataTablasActualizar.Rows(j).Item(4), dtDataTablasActualizar.Rows(j).Item(5), dtDataTablasActualizar.Rows(j).Item(6), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            End If

            If dt.Rows(i).Item("Nombre") = "MC_USUARIO_LOCAL" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_USUARIO_LOCAL.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeUsuariolocal(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If
            If dt.Rows(i).Item("Nombre") = "MC_ROL" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_ROL.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeRol(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If
            If dt.Rows(i).Item("Nombre") = "MC_MODULO" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_MODULO.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeModulo(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), dtDataTablasActualizar.Rows(j).Item(3), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If
            If dt.Rows(i).Item("Nombre") = "MC_SISTEMA" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_SISTEMA.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeSistema(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If
            If dt.Rows(i).Item("Nombre") = "MC_SUBMODULO" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_SUBMODULO.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeSubModulo(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), dtDataTablasActualizar.Rows(j).Item(3), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If
            If dt.Rows(i).Item("Nombre") = "MC_ACCESOS" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_ACCESOS.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeAccesos(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), dtDataTablasActualizar.Rows(j).Item(3), dtDataTablasActualizar.Rows(j).Item(4), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If
            If dt.Rows(i).Item("Nombre") = "MC_LOCAL_LIST" Then
                Dim writer As New XmlTextWriter(LocalDao.RutaXML + "\MC_LOCAL_LIST.xml", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("Table")
                For j = 0 To dtDataTablasActualizar.Rows.Count - 1
                    Tools.createNodeMC_LOCAL_LIST(dtDataTablasActualizar.Rows(j).Item(0), dtDataTablasActualizar.Rows(j).Item(1), dtDataTablasActualizar.Rows(j).Item(2), dtDataTablasActualizar.Rows(j).Item(3), dtDataTablasActualizar.Rows(j).Item(4), dtDataTablasActualizar.Rows(j).Item(5), dtDataTablasActualizar.Rows(j).Item(6), dtDataTablasActualizar.Rows(j).Item(7), dtDataTablasActualizar.Rows(j).Item(8), dtDataTablasActualizar.Rows(j).Item(9), dtDataTablasActualizar.Rows(j).Item(10), dtDataTablasActualizar.Rows(j).Item(11), dtDataTablasActualizar.Rows(j).Item(12), dtDataTablasActualizar.Rows(j).Item(13), writer)
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
                'CrearXML(dtDataTablasActualizar, dtTablasActualizar.Rows(i).Item("Nombre")) 'evaluar
            End If

            'ConexionDAO.UpdateTabla(dtTablasActualizar.Rows(i).Item("Nombre"))
            SplashScreenManager.Default.SendCommand(SplashScreen1.SplashScreenCommand.SomeCommandId, "Limpiando Datos")
            SplashScreenManager.Default.SendCommand(SplashScreen1.SplashScreenCommand.SomeCommandId, "Cargando Datos " + dt.Rows(i).Item("Nombre"))
        Next
    End Sub
End Class
#Region "CodigoAntiguo"
'Dim query As String
'Dim values As String = ""
'Dim dato As String
'Dim truncate As String
'dtDataTablasActualizar = ConexionDAO.Get_Data_Tabla_Actualizar(dtTablasActualizar.Rows(i).Item("Nombre"))
'dtcolumnas = dtDataTablasActualizar.Columns.Count
''truncate = "truncate table " + dtTablasActualizar.Rows(i).Item("Nombre")
''ConexionDAO.Truncate_Table(truncate)
'ConexionDAO.Set_Data_Tabla_Actualizar(dtTablasActualizar.Rows(i).Item("Nombre"), dtDataTablasActualizar, dtcolumnas)

'For j = 0 To dtDataTablasActualizar.Rows.Count - 1
'    query = ""
'    values = ""
'    'query = "insert " + dtTablasActualizar.Rows(i).Item("Nombre") + " select "
'    For k = 0 To dtcolumnas - 1
'        dato = dtDataTablasActualizar.Rows(j).Item(k)
'        If TypeOf dtDataTablasActualizar.Rows(j).Item(k) Is DateTime Then
'            Dim fecha As DateTime = dato
'            If k + 1 = dtcolumnas Then
'                values = values + "'" + fecha.ToString("yyyy-MM-ddTHH:mm:ss") + "'"
'            Else
'                values = values + "'" + fecha.ToString("yyyy-MM-ddTHH:mm:ss") + "',"
'            End If
'        Else
'            If k + 1 = dtcolumnas Then
'                values = values + "'" + dato + "'"
'            Else
'                values = values + "'" + dato + "',"
'            End If
'        End If

'    Next
'    query = query + values
'    ConexionDAO.Set_Data_Tabla_Actualizar(query)


'Dim xmlFile As XmlReader
'xmlFile = XmlReader.Create("C:\MC_REPORTES\XMLPrueba2.xml", New XmlReaderSettings())
'Dim xmlFile2 As XmlReader
'xmlFile2 = XmlReader.Create("C:\MC_REPORTES\XMLPrueba.xml", New XmlReaderSettings())
'Dim dt As New DataTable
'Dim dtlocales As New DataTable
''dt.ReadXml(xmlFile)

'Dim ds As New DataSet
'ds.ReadXml(xmlFile)
'dt = ds.Tables("Usuarios")

'For i = 0 To dt.Rows.Count - 1
'    MsgBox(dt.Rows(i).Item("nombreusuario"))
'Next

'Private Function CrearXML(ByVal dt As DataTable, ByVal nombretabla As String)
'    Dim dtcolumnas As Integer
'    Dim dtfila As New DataTable
'    Dim writer As New XmlTextWriter("C:\MC_REPORTES\" + nombretabla + ".xml", System.Text.Encoding.UTF8)
'    writer.WriteStartDocument(True)
'    writer.Formatting = Formatting.Indented
'    writer.Indentation = 2
'    writer.WriteStartElement("Table")

'    dtcolumnas = dt.Columns.Count


'    For j = 0 To dt.Rows.Count - 1
'        For k = 0 To dtcolumnas - 1
'            dtfila.Columns.Add(k, GetType(String))
'        Next

'        Tools.createNodeUsuario(dt.Rows(j).Item(0), dt.Rows(j).Item(1), dt.Rows(j).Item(2), dt.Rows(j).Item(3), dt.Rows(j).Item(4), dt.Rows(j).Item(5), dt.Rows(j).Item(6), writer)
'    Next
'    writer.WriteEndElement()
'    writer.WriteEndDocument()
'    writer.Close()
'End Function

#End Region