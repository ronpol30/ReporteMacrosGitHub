<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesktopMain
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnUsuario = New DevExpress.XtraBars.BarButtonItem()
        Me.btncomputadora = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFechaHora = New DevExpress.XtraBars.BarButtonItem()
        Me.btLocal = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCerrar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFuente = New DevExpress.XtraBars.BarButtonItem()
        Me.rgbiSkins = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.btnEmpresa = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btnUsuario, Me.btncomputadora, Me.btnFechaHora, Me.btLocal, Me.btnCerrar, Me.btnFuente, Me.rgbiSkins, Me.btnEmpresa})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 9
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.Size = New System.Drawing.Size(701, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'btnUsuario
        '
        Me.btnUsuario.Caption = "Usuario"
        Me.btnUsuario.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnUsuario.Glyph = Global.MC_Reportes.My.Resources.Resources.Usuario16
        Me.btnUsuario.Id = 1
        Me.btnUsuario.Name = "btnUsuario"
        '
        'btncomputadora
        '
        Me.btncomputadora.Caption = "Computadora"
        Me.btncomputadora.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btncomputadora.Glyph = Global.MC_Reportes.My.Resources.Resources.Estacion16
        Me.btncomputadora.Id = 2
        Me.btncomputadora.Name = "btncomputadora"
        '
        'btnFechaHora
        '
        Me.btnFechaHora.Caption = "FechaHora"
        Me.btnFechaHora.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnFechaHora.Glyph = Global.MC_Reportes.My.Resources.Resources.Calendario16
        Me.btnFechaHora.Id = 3
        Me.btnFechaHora.Name = "btnFechaHora"
        '
        'btLocal
        '
        Me.btLocal.Caption = "Local"
        Me.btLocal.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btLocal.Glyph = Global.MC_Reportes.My.Resources.Resources.Local16
        Me.btLocal.Id = 4
        Me.btLocal.Name = "btLocal"
        '
        'btnCerrar
        '
        Me.btnCerrar.Caption = "Salir del programa"
        Me.btnCerrar.Id = 5
        Me.btnCerrar.LargeGlyph = Global.MC_Reportes.My.Resources.Resources.close_32x32
        Me.btnCerrar.Name = "btnCerrar"
        '
        'btnFuente
        '
        Me.btnFuente.Caption = "Fuente"
        Me.btnFuente.Id = 6
        Me.btnFuente.LargeGlyph = Global.MC_Reportes.My.Resources.Resources.Fuente32
        Me.btnFuente.Name = "btnFuente"
        '
        'rgbiSkins
        '
        Me.rgbiSkins.Caption = "SkinRibbonGalleryBarItem1"
        Me.rgbiSkins.Id = 7
        Me.rgbiSkins.Name = "rgbiSkins"
        '
        'btnEmpresa
        '
        Me.btnEmpresa.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnEmpresa.Caption = "Empresa"
        Me.btnEmpresa.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnEmpresa.Id = 8
        Me.btnEmpresa.Name = "btnEmpresa"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Sistema"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnCerrar)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rgbiSkins)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnFuente)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Operaciones"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.btnUsuario)
        Me.RibbonStatusBar.ItemLinks.Add(Me.btncomputadora)
        Me.RibbonStatusBar.ItemLinks.Add(Me.btLocal)
        Me.RibbonStatusBar.ItemLinks.Add(Me.btnFechaHora)
        Me.RibbonStatusBar.ItemLinks.Add(Me.btnEmpresa)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 468)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(701, 31)
        '
        'Timer1
        '
        '
        'DesktopMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 499)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IsMdiContainer = True
        Me.Name = "DesktopMain"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "DesktopMain"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents btnUsuario As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btncomputadora As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFechaHora As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btLocal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCerrar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFuente As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rgbiSkins As DevExpress.XtraBars.SkinRibbonGalleryBarItem
    Friend WithEvents btnEmpresa As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents Timer1 As Timer
End Class
