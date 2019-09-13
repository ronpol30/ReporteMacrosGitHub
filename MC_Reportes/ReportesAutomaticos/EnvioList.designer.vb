<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioList))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnNuevo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExportarExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExportarPDF = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrevisualizar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEnviar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnLogEnvios = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btnNuevo, Me.btnEditar, Me.btnEliminar, Me.btnExportarExcel, Me.btnExportarPDF, Me.btnPrevisualizar, Me.btnEnviar, Me.btnLogEnvios, Me.BarButtonItem1})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 15
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(704, 143)
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Caption = "Nuevo"
        Me.btnNuevo.Glyph = CType(resources.GetObject("btnNuevo.Glyph"), System.Drawing.Image)
        Me.btnNuevo.Id = 1
        Me.btnNuevo.LargeGlyph = CType(resources.GetObject("btnNuevo.LargeGlyph"), System.Drawing.Image)
        Me.btnNuevo.Name = "btnNuevo"
        '
        'btnEditar
        '
        Me.btnEditar.Caption = "Editar"
        Me.btnEditar.Glyph = CType(resources.GetObject("btnEditar.Glyph"), System.Drawing.Image)
        Me.btnEditar.Id = 2
        Me.btnEditar.LargeGlyph = CType(resources.GetObject("btnEditar.LargeGlyph"), System.Drawing.Image)
        Me.btnEditar.Name = "btnEditar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Caption = "Eliminar"
        Me.btnEliminar.Glyph = CType(resources.GetObject("btnEliminar.Glyph"), System.Drawing.Image)
        Me.btnEliminar.Id = 3
        Me.btnEliminar.LargeGlyph = CType(resources.GetObject("btnEliminar.LargeGlyph"), System.Drawing.Image)
        Me.btnEliminar.Name = "btnEliminar"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Caption = "Archivo Excel"
        Me.btnExportarExcel.Glyph = CType(resources.GetObject("btnExportarExcel.Glyph"), System.Drawing.Image)
        Me.btnExportarExcel.Id = 9
        Me.btnExportarExcel.LargeGlyph = CType(resources.GetObject("btnExportarExcel.LargeGlyph"), System.Drawing.Image)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        '
        'btnExportarPDF
        '
        Me.btnExportarPDF.Caption = "Archivo PDF"
        Me.btnExportarPDF.Glyph = CType(resources.GetObject("btnExportarPDF.Glyph"), System.Drawing.Image)
        Me.btnExportarPDF.Id = 10
        Me.btnExportarPDF.LargeGlyph = CType(resources.GetObject("btnExportarPDF.LargeGlyph"), System.Drawing.Image)
        Me.btnExportarPDF.Name = "btnExportarPDF"
        '
        'btnPrevisualizar
        '
        Me.btnPrevisualizar.Caption = "Previsualizar"
        Me.btnPrevisualizar.Glyph = CType(resources.GetObject("btnPrevisualizar.Glyph"), System.Drawing.Image)
        Me.btnPrevisualizar.Id = 11
        Me.btnPrevisualizar.LargeGlyph = CType(resources.GetObject("btnPrevisualizar.LargeGlyph"), System.Drawing.Image)
        Me.btnPrevisualizar.Name = "btnPrevisualizar"
        '
        'btnEnviar
        '
        Me.btnEnviar.Caption = "Enviar"
        Me.btnEnviar.Glyph = CType(resources.GetObject("btnEnviar.Glyph"), System.Drawing.Image)
        Me.btnEnviar.Id = 12
        Me.btnEnviar.LargeGlyph = CType(resources.GetObject("btnEnviar.LargeGlyph"), System.Drawing.Image)
        Me.btnEnviar.Name = "btnEnviar"
        '
        'btnLogEnvios
        '
        Me.btnLogEnvios.Caption = "Log"
        Me.btnLogEnvios.Description = "Registro de envios"
        Me.btnLogEnvios.Glyph = CType(resources.GetObject("btnLogEnvios.Glyph"), System.Drawing.Image)
        Me.btnLogEnvios.Id = 13
        Me.btnLogEnvios.LargeGlyph = CType(resources.GetObject("btnLogEnvios.LargeGlyph"), System.Drawing.Image)
        Me.btnLogEnvios.Name = "btnLogEnvios"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Cerrar"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 14
        Me.BarButtonItem1.ItemInMenuAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BarButtonItem1.ItemInMenuAppearance.Hovered.Options.UseFont = True
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Maestros"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnNuevo)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnEditar)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnEliminar)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Opciones"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnPrevisualizar)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnEnviar)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnLogEnvios)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Reportes"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "."
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 143)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.RibbonControl
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(704, 396)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'EnvioList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 539)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.RibbonControl)
        Me.Name = "EnvioList"
        Me.Ribbon = Me.RibbonControl
        Me.Text = "Configuración de Envíos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnNuevo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExportarExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExportarPDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPrevisualizar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnEnviar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLogEnvios As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup


End Class
