<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class opcReporteOperacionCompra2
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opcReporteOperacionCompra2))
        Me.TimeFin = New DevExpress.XtraEditors.TimeEdit()
        Me.TimeIni = New DevExpress.XtraEditors.TimeEdit()
        Me.btnEmitir = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DateFin = New DevExpress.XtraEditors.DateEdit()
        Me.DateIni = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.TimeFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimeFin
        '
        Me.TimeFin.EditValue = New Date(CType(0, Long))
        Me.TimeFin.Location = New System.Drawing.Point(223, 103)
        Me.TimeFin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TimeFin.Name = "TimeFin"
        Me.TimeFin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TimeFin.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeFin.Properties.Appearance.Options.UseFont = True
        Me.TimeFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeFin.Properties.DisplayFormat.FormatString = "t"
        Me.TimeFin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.TimeFin.Properties.EditFormat.FormatString = "t"
        Me.TimeFin.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TimeFin.Properties.Mask.EditMask = "t"
        Me.TimeFin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.TimeFin.Size = New System.Drawing.Size(100, 24)
        Me.TimeFin.TabIndex = 47
        '
        'TimeIni
        '
        Me.TimeIni.EditValue = New Date(CType(0, Long))
        Me.TimeIni.Location = New System.Drawing.Point(223, 75)
        Me.TimeIni.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TimeIni.Name = "TimeIni"
        Me.TimeIni.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TimeIni.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIni.Properties.Appearance.Options.UseFont = True
        Me.TimeIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeIni.Properties.DisplayFormat.FormatString = "t"
        Me.TimeIni.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.TimeIni.Properties.EditFormat.FormatString = "t"
        Me.TimeIni.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TimeIni.Properties.Mask.EditMask = "t"
        Me.TimeIni.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.TimeIni.Size = New System.Drawing.Size(100, 24)
        Me.TimeIni.TabIndex = 45
        '
        'btnEmitir
        '
        Me.btnEmitir.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmitir.Appearance.Options.UseFont = True
        Me.btnEmitir.Image = CType(resources.GetObject("btnEmitir.Image"), System.Drawing.Image)
        Me.btnEmitir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEmitir.Location = New System.Drawing.Point(465, 71)
        Me.btnEmitir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEmitir.Name = "btnEmitir"
        Me.btnEmitir.Size = New System.Drawing.Size(68, 56)
        Me.btnEmitir.TabIndex = 49
        Me.btnEmitir.Text = "Emitir"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl5.Location = New System.Drawing.Point(66, 27)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(512, 27)
        Me.LabelControl5.TabIndex = 50
        Me.LabelControl5.Text = "Reporte de Egresos por Dia"
        '
        'DateFin
        '
        Me.DateFin.EditValue = New Date(2018, 3, 9, 13, 18, 17, 0)
        Me.DateFin.Location = New System.Drawing.Point(90, 103)
        Me.DateFin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateFin.Name = "DateFin"
        Me.DateFin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateFin.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateFin.Properties.Appearance.Options.UseFont = True
        Me.DateFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFin.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DateFin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DateFin.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateFin.Size = New System.Drawing.Size(129, 24)
        Me.DateFin.TabIndex = 46
        '
        'DateIni
        '
        Me.DateIni.EditValue = New Date(2018, 3, 9, 13, 18, 17, 0)
        Me.DateIni.Location = New System.Drawing.Point(90, 75)
        Me.DateIni.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateIni.Name = "DateIni"
        Me.DateIni.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateIni.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateIni.Properties.Appearance.Options.UseFont = True
        Me.DateIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateIni.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DateIni.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DateIni.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateIni.Size = New System.Drawing.Size(129, 24)
        Me.DateIni.TabIndex = 44
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(14, 131)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(966, 371)
        Me.GridControl1.TabIndex = 60
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Location = New System.Drawing.Point(52, 525)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(180, 120)
        Me.LayoutControl1.TabIndex = 61
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(180, 120)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(14, 507)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Seleccionar"
        Me.CheckEdit1.Size = New System.Drawing.Size(589, 19)
        Me.CheckEdit1.StyleController = Me.LayoutControl1
        Me.CheckEdit1.TabIndex = 4
        '
        'opcReporteOperacionCompra2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CheckEdit1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnEmitir)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TimeFin)
        Me.Controls.Add(Me.DateIni)
        Me.Controls.Add(Me.DateFin)
        Me.Controls.Add(Me.TimeIni)
        Me.Name = "opcReporteOperacionCompra2"
        Me.Size = New System.Drawing.Size(1060, 558)
        CType(Me.TimeFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TimeFin As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents TimeIni As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents btnEmitir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class
