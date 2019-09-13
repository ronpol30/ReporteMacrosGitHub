<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opcReporteOperacionVenta9
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opcReporteOperacionVenta9))
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DateIni = New DevExpress.XtraEditors.DateEdit()
        Me.DateFin = New DevExpress.XtraEditors.DateEdit()
        Me.TimeFin = New DevExpress.XtraEditors.TimeEdit()
        Me.btnEmitir = New DevExpress.XtraEditors.SimpleButton()
        Me.TimeIni = New DevExpress.XtraEditors.TimeEdit()
        CType(Me.DateIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl5.Location = New System.Drawing.Point(139, 12)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(574, 27)
        Me.LabelControl5.TabIndex = 50
        Me.LabelControl5.Text = "Reporte de Consumo - Articulo"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(45, 104)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(75, 17)
        Me.LabelControl2.TabIndex = 52
        Me.LabelControl2.Text = "Fecha Final :"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(45, 69)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 17)
        Me.LabelControl1.TabIndex = 51
        Me.LabelControl1.Text = "Fecha Inicial :"
        '
        'DateIni
        '
        Me.DateIni.EditValue = New Date(2018, 3, 9, 13, 18, 17, 0)
        Me.DateIni.Location = New System.Drawing.Point(148, 66)
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
        Me.DateIni.Size = New System.Drawing.Size(119, 24)
        Me.DateIni.TabIndex = 53
        '
        'DateFin
        '
        Me.DateFin.EditValue = New Date(2018, 3, 9, 13, 18, 17, 0)
        Me.DateFin.Location = New System.Drawing.Point(148, 101)
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
        Me.DateFin.Size = New System.Drawing.Size(119, 24)
        Me.DateFin.TabIndex = 54
        '
        'TimeFin
        '
        Me.TimeFin.EditValue = New Date(CType(0, Long))
        Me.TimeFin.Location = New System.Drawing.Point(282, 97)
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
        Me.TimeFin.Size = New System.Drawing.Size(88, 24)
        Me.TimeFin.TabIndex = 57
        '
        'btnEmitir
        '
        Me.btnEmitir.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmitir.Appearance.Options.UseFont = True
        Me.btnEmitir.Image = CType(resources.GetObject("btnEmitir.Image"), System.Drawing.Image)
        Me.btnEmitir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnEmitir.Location = New System.Drawing.Point(390, 65)
        Me.btnEmitir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEmitir.Name = "btnEmitir"
        Me.btnEmitir.Size = New System.Drawing.Size(72, 76)
        Me.btnEmitir.TabIndex = 55
        Me.btnEmitir.Text = "Emitir"
        '
        'TimeIni
        '
        Me.TimeIni.EditValue = New Date(CType(0, Long))
        Me.TimeIni.Location = New System.Drawing.Point(282, 62)
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
        Me.TimeIni.Size = New System.Drawing.Size(88, 24)
        Me.TimeIni.TabIndex = 56
        '
        'opcReporteOperacionVenta9
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TimeFin)
        Me.Controls.Add(Me.btnEmitir)
        Me.Controls.Add(Me.TimeIni)
        Me.Controls.Add(Me.DateIni)
        Me.Controls.Add(Me.DateFin)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl5)
        Me.Name = "opcReporteOperacionVenta9"
        Me.Size = New System.Drawing.Size(837, 514)
        CType(Me.DateIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TimeFin As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents btnEmitir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TimeIni As DevExpress.XtraEditors.TimeEdit
End Class
