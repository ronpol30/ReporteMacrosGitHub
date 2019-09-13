Imports MC_Data
Imports MC_Framework
Imports DevExpress.XtraNavBar
Imports DevExpress.LookAndFeel
Imports System.Globalization
Imports DevExpress.XtraBars.Ribbon
Public Class DesktopMain
    Public Sub New()
        'Se configura la cultura de la aplicacion
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-PE")
        'Se carga el skin por defecto
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(Tools.ReadAppSettings("Skin"))

        'Se actualiza la fuente de la aplicacion
        'DevExpress.Utils.AppearanceObject.DefaultFont = New Font(Tools.ReadAppSettings("FuenteName"), Convert.ToSingle(Tools.ReadAppSettings("FuenteSize")), CType(Tools.ReadAppSettings("FuenteStyle"), System.Drawing.FontStyle))
        LookAndFeelHelper.ForceDefaultLookAndFeelChanged()

        ' This call is required by the designer.
        InitializeComponent()

        'Se configura el formulario
        Me.KeyPreview = True
        Me.WindowState = FormWindowState.Maximized
        Me.Text = "Reportes Macroscem"
        Me.RibbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always

        'Se carga los valores de la barra de estado
        btnUsuario.Caption = UsuarioBE.Nombres & " " & UsuarioBE.ApellidoPaterno & " (" & UsuarioBE.Nombres & ")"
        btncomputadora.Caption = My.Computer.Name
        btnEmpresa.Caption = "Macroscem Consultores"
        btnFechaHora.Caption = DateTime.Now
        'Emulo entidad con dt
        'Dim dtmodulo As New DataTable
        Dim dtsubmodulos As New DataTable
        'dtmodulo = UsuarioDao.GetModulos(UsuarioBE.idrol, 3)
        dtsubmodulos = UsuarioDao.GetSubModulos(UsuarioBE.idrol, 3)
        'ActivaBotones(dtmodulo, dtsubmodulos) 'Activa Opciones dependiendo de los accesos

        ControlesDevExpress.InitRibbonControl(RibbonControl)
        Dim ControlNavBar As New NavBarControl()
        Me.Controls.Add(ControlNavBar)
        ControlNavBar.BeginUpdate()
        ControlesDevExpress.InitNavBar(ControlNavBar)
        ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"Operaciones Ventas", "Documentos Detallado", "Ventas Agrupado", "Anulaciones", "Resumen de Documentos", "Cortesias", "Liquidacion Cajero", "Registro de Ventas"}, My.Resources.Asistencia, dtsubmodulos)
        'ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"Operaciones Ventas", "Documentos Detallado", "Ventas Agrupado", "Anulaciones", "Resumen de Documentos", "Cuentas x Cobrar", "Cortesias", "Liquidacion Cajero", "Paloteo Produccion-Cortesia", "Consumo del Personal", "Registro de Ventas"}, My.Resources.Asistencia, dtsubmodulos)
        ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"Operaciones Compras", "Compras de Articulos", "Registro de Compras"}, My.Resources.Financial_32x32, dtsubmodulos)
        'ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"Operaciones Compras", "Compras de Articulos", "Compras Egresos por Dia", "Recetas por Articulo", "Registro de Compras"}, My.Resources.Financial_32x32, dtsubmodulos)
        ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"RecursosHumanos Marcaciones", "Asistencias"}, My.Resources.Cube_32x32, dtsubmodulos)
        ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"Reportes Automaticos", "Reportes Automaticos"}, My.Resources.NewMail_32x32, dtsubmodulos)
        ControlesDevExpress.InitNavBarMenuDesactiva(ControlNavBar, {"Contabilidad", "Inventario Permanente Unidades", "Inventario Permanente Valorizado"}, My.Resources.Contabilidad, dtsubmodulos)
        AddHandler ControlNavBar.LinkClicked, AddressOf DesktopMain_LinkClicked
        ControlNavBar.EndUpdate()

        'Se inicia el timer
        Timer1.Interval = 6000 '1500
        Timer1.Start()
    End Sub
    Private Sub DesktopMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Se refresca el formulario Desktop
            Me.Update()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DesktopMain_LinkClicked(ByVal sender As Object, ByVal e As NavBarLinkEventArgs)
        If e.Link.Caption = "" Then
        Else
            Select Case e.Link.Caption.ToString.ToUpper
                Case "DOCUMENTOS DETALLADO" : OpenFormulario("opciReporteOperacionVenta1")
                Case "VENTAS AGRUPADO" : OpenFormulario("opciReporteOperacionVenta2")
                Case "ANULACIONES" : OpenFormulario("opciReporteOperacionVenta3")
                Case "RESUMEN DE DOCUMENTOS" : OpenFormulario("opciReporteOperacionVenta4")
                Case "CUENTAS X COBRAR" : OpenFormulario("opciReporteOperacionVenta5")
                Case "CORTESIAS" : OpenFormulario("opciReporteOperacionVenta6")
                Case "LIQUIDACION CAJERO" : OpenFormulario("opciReporteOperacionVenta7")
                Case "PALOTEO PRODUCCION-CORTESIA" ': OpenFormulario("ConceptoMovimientoCtaCteList")
                Case "CONSUMO DEL PERSONAL" ': OpenFormulario("BancoProveedorCuentaList")
                Case "COMPRAS DE ARTICULOS" : OpenFormulario("opciReporteOperacionCompra1")
                Case "COMPRAS EGRESOS POR DIA"  'OpenFormulario("ConsultaDocumentoVentaList")
                Case "RECETAS POR ARTICULO"  'OpenFormulario("ConsultaPedidosList")
                Case "ASISTENCIAS" : OpenFormulario("opciReporteRRHH1")
                Case "REPORTES AUTOMATICOS" : OpenFormulario("ReporteAutomaticoConfiguracion")
                Case "REGISTRO DE VENTAS" : OpenFormulario("opciReporteOperacionVenta11")
                Case "REGISTRO DE COMPRAS" : OpenFormulario("opciReporteOperacionCompra4")
                Case "REGISTRO INVENTARIO PERMANENTE UNIDADES" : OpenFormulario("opciReporteContabilidad1")
            End Select
        End If
    End Sub
    Private Sub DesktopMain_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCerrar.ItemClick, btnFuente.ItemClick
        Try
            Select Case e.Item.Caption
                Case "Fuente" : Fuente()
                Case "Salir del programa" : Salir()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub OpenFormulario(NombreFormulario As String)
        Dim obj As Object
        Dim NombreAssembly As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name()

        'Se busca el formulario. Si no existe se crea la instancia, caso contrario solo se activa. 
        If Me.MdiChildren.ToList.Find(Function(Item) Item.Name = NombreFormulario) Is Nothing Then
            obj = Activator.CreateInstance(Type.GetType(NombreAssembly + "." + NombreFormulario))
            obj.MdiParent = Me
            obj.Name = NombreFormulario
            obj.WindowState = FormWindowState.Maximized
            obj.Show()
        Else
            For Each objForms In Me.MdiChildren
                If objForms.Name = NombreFormulario Then
                    objForms.WindowState = FormWindowState.Maximized
                    objForms.Show()
                End If
            Next
        End If

    End Sub
    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Se muestra la fecha y hora cada 15 segundos
        btnFechaHora.Caption = DateTime.Now

    End Sub
    Private Sub rgbiSkins_GalleryItemClick(sender As Object, e As GalleryItemClickEventArgs) Handles rgbiSkins.GalleryItemClick

        Try
            'Se registra el skin que selecciona el usuario
            Tools.SaveAppSettings("Skin", e.Item.Caption)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Salir()
        If MessageBox.Show("¿Esta seguro de salir del programa?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
    Public Sub Fuente()
        Try
            'Se cambia la fuente de la aplicacion
            If FontDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                'Se actualiza la fuente de la aplicacion
                DevExpress.Utils.AppearanceObject.DefaultFont = New Font(FontDialog1.Font.Name, FontDialog1.Font.Size, FontDialog1.Font.Style)

                'Se reinicia estilo de la fuente
                LookAndFeelHelper.ForceDefaultLookAndFeelChanged()

                'Se registra la configuracion de la fuente
                Tools.SaveAppSettings("FuenteName", FontDialog1.Font.Name)
                Tools.SaveAppSettings("FuenteSize", FontDialog1.Font.Size)
                Tools.SaveAppSettings("FuenteStyle", FontDialog1.Font.Style)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUsuario_ItemClick(sender As Object, e As EventArgs) Handles btnUsuario.ItemClick

        If MessageBox.Show("¿Desea cerrar la sesión de usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then

            'Se cierra los formulario abiertos
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next

            'Se cierra la sesion de usuario y se reinicia la aplicacion
            Application.Restart()
        End If
    End Sub
    Private Sub DesktopMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub ActivaBotonesold(dtmodulos As DataTable, dtsubmodulos As DataTable)
#Region "Metodo1 Roles"
        'Se inicializa el Ribbon
        ControlesDevExpress.InitRibbonControl(RibbonControl)
        Dim MODULO(100) As String
        Dim SUBMODULO(100) As String
        Dim max As Integer = 0
        Dim ControlNavBarDinamico As New NavBarControl()
        Me.Controls.Add(ControlNavBarDinamico)
        ControlNavBarDinamico.BeginUpdate()
        ControlesDevExpress.InitNavBar(ControlNavBarDinamico)
        For i = 0 To dtmodulos.Rows.Count - 1
            MODULO(i) = dtmodulos.Rows.Item(i)("Modulo")
            If TipoConexion = False And MODULO(i) = "Reportes Automaticos" Then
            Else
                max = 0
                For j = 0 To dtsubmodulos.Rows.Count - 1
                    If dtmodulos.Rows.Item(i)("IDMODULO") = dtsubmodulos.Rows.Item(j)("IDMODULO") Then
                        SUBMODULO(max) = dtsubmodulos.Rows.Item(j)("SubModulo")
                        max = max + 1
                    End If
                    If j + 1 = dtsubmodulos.Rows.Count Then 'Crea el NavBar Con Items
                        ControlesDevExpress.InitNavBarMenu(ControlNavBarDinamico,
                       {MODULO(i), SUBMODULO(0), SUBMODULO(1), SUBMODULO(2), SUBMODULO(3), SUBMODULO(4), SUBMODULO(5), SUBMODULO(6), SUBMODULO(7), SUBMODULO(8), SUBMODULO(9), SUBMODULO(10), SUBMODULO(11), SUBMODULO(12), SUBMODULO(13), SUBMODULO(14), SUBMODULO(15), SUBMODULO(16), SUBMODULO(17), SUBMODULO(18), SUBMODULO(19), SUBMODULO(20)},
                       If(dtmodulos.Rows.Item(i)("Modulo") = "RecursosHumanos Marcaciones", My.Resources.Asistencia, (If(dtmodulos.Rows.Item(i)("Modulo") = "Operaciones Ventas", My.Resources.ControlInterno24, My.Resources.Calendario16))))
                    End If
                Next
                Array.Clear(SUBMODULO, 0, SUBMODULO.Length)
            End If
        Next
        ControlNavBarDinamico.EndUpdate()
        AddHandler ControlNavBarDinamico.LinkClicked, AddressOf DesktopMain_LinkClicked
#End Region
    End Sub
    Private Sub ActivaBotones(dtmodulos As DataTable, dtsubmodulos As DataTable)
#Region "Metodo1 Roles"
        'Se inicializa el Ribbon
        ControlesDevExpress.InitRibbonControl(RibbonControl)
        Dim SUBMODULO(dtsubmodulos.Rows.Count + 1) As String
        Dim ROW As Integer

        Dim ControlNavBarDinamico As New NavBarControl()
        Me.Controls.Add(ControlNavBarDinamico)
        ControlNavBarDinamico.BeginUpdate()
        ControlesDevExpress.InitNavBar(ControlNavBarDinamico)

        For j = 0 To dtmodulos.Rows.Count - 1 'Obtengo los modulos
            ROW = 0
            For i = 0 To dtsubmodulos.Rows.Count - 1
                SUBMODULO(0) = dtmodulos.Rows.Item(j)(1).ToString.ToUpper
                If dtmodulos.Rows.Item(j)("IDMODULO") = dtsubmodulos.Rows.Item(i)("IDMODULO") Then
                    ROW = ROW + 1
                    SUBMODULO(ROW) = dtsubmodulos.Rows.Item(i)(5)
                End If
            Next
            ControlesDevExpress.InitNavBarMenu(ControlNavBarDinamico, SUBMODULO,
                                               If(dtmodulos.Rows.Item(j)("Modulo") = "RecursosHumanos Marcaciones", My.Resources.Asistencia,
                                               (If(dtmodulos.Rows.Item(j)("Modulo") = "Operaciones Ventas", My.Resources.Financial_32x32,
                                               (If(dtmodulos.Rows.Item(j)("Modulo") = "Reportes Automaticos", My.Resources.NewMail_32x32, My.Resources.Cube_32x32))))))
            Array.Clear(SUBMODULO, 0, SUBMODULO.Length)
        Next
        ControlNavBarDinamico.EndUpdate()
        AddHandler ControlNavBarDinamico.LinkClicked, AddressOf DesktopMain_LinkClicked
#End Region
    End Sub
End Class
