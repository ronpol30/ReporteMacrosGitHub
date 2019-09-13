<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptReporteOperacionVenta1
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteOperacionVenta1))
        Dim StoredProcQuery1 As DevExpress.DataAccess.Sql.StoredProcQuery = New DevExpress.DataAccess.Sql.StoredProcQuery()
        Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Dim QueryParameter2 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel15, Me.XrLabel3, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel2, Me.XrLabel16})
        Me.Detail.Dpi = 254!
        Me.Detail.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Detail.HeightF = 36.4814!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254!)
        Me.Detail.StylePriority.UseFont = false
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel15
        '
        Me.XrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.tTurno")})
        Me.XrLabel15.Dpi = 254!
        Me.XrLabel15.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(2417.546!, 0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(187.9373!, 36.38334!)
        Me.XrLabel15.StylePriority.UseFont = false
        '
        'XrLabel3
        '
        Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nDescuento", "{0:n2}")})
        Me.XrLabel3.Dpi = 254!
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2266.815!, 0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(150.7305!, 36.38333!)
        Me.XrLabel3.StylePriority.UseFont = false
        Me.XrLabel3.StylePriority.UseTextAlignment = false
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel12
        '
        Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nVenta", "{0:n2}")})
        Me.XrLabel12.Dpi = 254!
        Me.XrLabel12.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(2109.624!, 0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(157.1907!, 36.38334!)
        Me.XrLabel12.StylePriority.UseFont = false
        Me.XrLabel12.StylePriority.UseTextAlignment = false
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel11
        '
        Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nPrecioImpuesto3", "{0:n2}")})
        Me.XrLabel11.Dpi = 254!
        Me.XrLabel11.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(1952.434!, 0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(157.1896!, 36.38334!)
        Me.XrLabel11.StylePriority.UseFont = false
        Me.XrLabel11.StylePriority.UseTextAlignment = false
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel10
        '
        Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nPrecioImpuesto2", "{0:n2}")})
        Me.XrLabel10.Dpi = 254!
        Me.XrLabel10.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(1795.243!, 0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(157.1904!, 36.38334!)
        Me.XrLabel10.StylePriority.UseFont = false
        Me.XrLabel10.StylePriority.UseTextAlignment = false
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel9
        '
        Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nPrecioImpuesto1", "{0:n2}")})
        Me.XrLabel9.Dpi = 254!
        Me.XrLabel9.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(1638.052!, 0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(157.1906!, 36.38334!)
        Me.XrLabel9.StylePriority.UseFont = false
        Me.XrLabel9.StylePriority.UseTextAlignment = false
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel8
        '
        Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nNeto", "{0:n2}")})
        Me.XrLabel8.Dpi = 254!
        Me.XrLabel8.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(1480.862!, 0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(147.1365!, 36.38334!)
        Me.XrLabel8.StylePriority.UseFont = false
        Me.XrLabel8.StylePriority.UseTextAlignment = false
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel7
        '
        Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.tEmpresa")})
        Me.XrLabel7.Dpi = 254!
        Me.XrLabel7.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(861.4832!, 0.09807122!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(619.3787!, 36.38333!)
        Me.XrLabel7.StylePriority.UseFont = false
        '
        'XrLabel6
        '
        Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.tIdentidad")})
        Me.XrLabel6.Dpi = 254!
        Me.XrLabel6.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(662.9995!, 0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(198.4837!, 36.38334!)
        Me.XrLabel6.StylePriority.UseFont = false
        '
        'XrLabel5
        '
        Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.fRegistro", "{0:d/MM/yyyy HH:mm}")})
        Me.XrLabel5.Dpi = 254!
        Me.XrLabel5.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(439.0783!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(223.9211!, 36.38334!)
        Me.XrLabel5.StylePriority.UseFont = false
        '
        'XrLabel4
        '
        Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.Descripcion")})
        Me.XrLabel4.Dpi = 254!
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(254!, 0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(185.0784!, 36.38334!)
        Me.XrLabel4.StylePriority.UseFont = false
        '
        'XrLabel2
        '
        Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.tDocumento")})
        Me.XrLabel2.Dpi = 254!
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(254!, 36.38334!)
        Me.XrLabel2.StylePriority.UseFont = false
        '
        'XrLabel16
        '
        Me.XrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.Estado")})
        Me.XrLabel16.Dpi = 254!
        Me.XrLabel16.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(2605.483!, 0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(154.5164!, 36.38334!)
        Me.XrLabel16.StylePriority.UseFont = false
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrLabel30, Me.XrLabel29, Me.XrLabel28, Me.XrLabel27, Me.XrLabel26, Me.XrLabel25, Me.XrLabel24, Me.XrLabel23, Me.XrLabel22, Me.XrLabel21, Me.XrLabel20, Me.XrLabel19, Me.XrLabel18, Me.XrLabel14, Me.XrPictureBox1, Me.XrLine1, Me.XrLabel1})
        Me.TopMargin.Dpi = 254!
        Me.TopMargin.HeightF = 254!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.Dpi = 254!
        Me.XrPageInfo2.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 67.47445!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(861.4833!, 45.71998!)
        Me.XrPageInfo2.StylePriority.UseFont = false
        '
        'XrLabel30
        '
        Me.XrLabel30.Dpi = 254!
        Me.XrLabel30.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(2605.483!, 187.5134!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(154.5164!, 41.48666!)
        Me.XrLabel30.StylePriority.UseFont = false
        Me.XrLabel30.Text = "Estado"
        '
        'XrLabel29
        '
        Me.XrLabel29.Dpi = 254!
        Me.XrLabel29.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(2417.546!, 187.5134!)
        Me.XrLabel29.Name = "XrLabel29"
        Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel29.SizeF = New System.Drawing.SizeF(154.5168!, 41.48666!)
        Me.XrLabel29.StylePriority.UseFont = false
        Me.XrLabel29.Text = "Turno"
        '
        'XrLabel28
        '
        Me.XrLabel28.Dpi = 254!
        Me.XrLabel28.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(2266.815!, 187.5134!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(150.7307!, 41.48666!)
        Me.XrLabel28.StylePriority.UseFont = false
        Me.XrLabel28.StylePriority.UseTextAlignment = false
        Me.XrLabel28.Text = "Descuento"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel27
        '
        Me.XrLabel27.Dpi = 254!
        Me.XrLabel27.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(2109.624!, 187.5134!)
        Me.XrLabel27.Name = "XrLabel27"
        Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel27.SizeF = New System.Drawing.SizeF(157.1906!, 41.48666!)
        Me.XrLabel27.StylePriority.UseFont = false
        Me.XrLabel27.StylePriority.UseTextAlignment = false
        Me.XrLabel27.Text = "Venta"
        Me.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel26
        '
        Me.XrLabel26.Dpi = 254!
        Me.XrLabel26.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(1952.433!, 187.5134!)
        Me.XrLabel26.Name = "XrLabel26"
        Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel26.SizeF = New System.Drawing.SizeF(157.1906!, 41.48666!)
        Me.XrLabel26.StylePriority.UseFont = false
        Me.XrLabel26.StylePriority.UseTextAlignment = false
        Me.XrLabel26.Text = "Impuesto 3"
        Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel25
        '
        Me.XrLabel25.Dpi = 254!
        Me.XrLabel25.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(1795.243!, 187.5134!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(157.1897!, 41.48666!)
        Me.XrLabel25.StylePriority.UseFont = false
        Me.XrLabel25.StylePriority.UseTextAlignment = false
        Me.XrLabel25.Text = "Impuesto 2"
        Me.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel24
        '
        Me.XrLabel24.Dpi = 254!
        Me.XrLabel24.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(1638.052!, 187.5134!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(157.1906!, 41.48666!)
        Me.XrLabel24.StylePriority.UseFont = false
        Me.XrLabel24.StylePriority.UseTextAlignment = false
        Me.XrLabel24.Text = "Impuesto 1"
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel23
        '
        Me.XrLabel23.Dpi = 254!
        Me.XrLabel23.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(1480.862!, 187.5134!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(157.1899!, 41.48666!)
        Me.XrLabel23.StylePriority.UseFont = false
        Me.XrLabel23.StylePriority.UseTextAlignment = false
        Me.XrLabel23.Text = "Neto"
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel22
        '
        Me.XrLabel22.Dpi = 254!
        Me.XrLabel22.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(861.4832!, 187.5134!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(254!, 41.48666!)
        Me.XrLabel22.StylePriority.UseFont = false
        Me.XrLabel22.Text = "Cliente"
        '
        'XrLabel21
        '
        Me.XrLabel21.Dpi = 254!
        Me.XrLabel21.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(662.9994!, 187.5134!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(198.4839!, 41.48666!)
        Me.XrLabel21.StylePriority.UseFont = false
        Me.XrLabel21.Text = "RUC"
        '
        'XrLabel20
        '
        Me.XrLabel20.Dpi = 254!
        Me.XrLabel20.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(439.0783!, 187.5134!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(223.9211!, 41.48666!)
        Me.XrLabel20.StylePriority.UseFont = false
        Me.XrLabel20.Text = "Fecha"
        '
        'XrLabel19
        '
        Me.XrLabel19.Dpi = 254!
        Me.XrLabel19.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(254.0001!, 187.5134!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(185.0783!, 41.48666!)
        Me.XrLabel19.StylePriority.UseFont = false
        Me.XrLabel19.Text = "Tipo"
        '
        'XrLabel18
        '
        Me.XrLabel18.Dpi = 254!
        Me.XrLabel18.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(0!, 187.5134!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(254!, 41.48666!)
        Me.XrLabel18.StylePriority.UseFont = false
        Me.XrLabel18.Text = "Documento"
        '
        'XrLabel14
        '
        Me.XrLabel14.Dpi = 254!
        Me.XrLabel14.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(0!, 113.1944!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(861.4833!, 44.30891!)
        Me.XrLabel14.StylePriority.UseFont = false
        Me.XrLabel14.Text = "Rango de fechas"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Dpi = 254!
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"),System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(2216.39!, 40.66335!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(530.9097!, 116.84!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLine1
        '
        Me.XrLine1.Dpi = 254!
        Me.XrLine1.LineWidth = 3
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 232.2689!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(2760!, 21.73112!)
        '
        'XrLabel1
        '
        Me.XrLabel1.Dpi = 254!
        Me.XrLabel1.Font = New System.Drawing.Font("Arial Black", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.MediumTurquoise
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(968.7277!, 40.66331!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(861.4833!, 58.42001!)
        Me.XrLabel1.StylePriority.UseFont = false
        Me.XrLabel1.StylePriority.UseForeColor = false
        Me.XrLabel1.StylePriority.UseTextAlignment = false
        Me.XrLabel1.Text = "Reporte de Documentos Detallado"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel31, Me.XrPageInfo1, Me.XrLabel17, Me.XrLine2})
        Me.BottomMargin.Dpi = 254!
        Me.BottomMargin.HeightF = 149!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel31
        '
        Me.XrLabel31.Dpi = 254!
        Me.XrLabel31.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(1268.91!, 35.08887!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(122.4447!, 40.78114!)
        Me.XrLabel31.StylePriority.UseFont = false
        Me.XrLabel31.StylePriority.UseTextAlignment = false
        Me.XrLabel31.Text = "Página"
        Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Dpi = 254!
        Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(1391.355!, 35.08887!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(181.0925!, 40.78115!)
        Me.XrPageInfo1.StylePriority.UseFont = false
        '
        'XrLabel17
        '
        Me.XrLabel17.Dpi = 254!
        Me.XrLabel17.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(0!, 35.08887!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(861.4833!, 40.78112!)
        Me.XrLabel17.StylePriority.UseFont = false
        Me.XrLabel17.Text = "Reporte de Documentos Detallado"
        '
        'XrLine2
        '
        Me.XrLine2.Dpi = 254!
        Me.XrLine2.LineWidth = 3
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(2760!, 22.43666!)
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "localhost_INFORESTConnection 1"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        StoredProcQuery1.Name = "RepMacroscem_ReporteOperacionVenta1"
        QueryParameter1.Name = "@FechaInicial"
        QueryParameter1.Type = GetType(Date)
        QueryParameter1.ValueInfo = "1753-01-01"
        QueryParameter2.Name = "@FechaFinal"
        QueryParameter2.Type = GetType(Date)
        QueryParameter2.ValueInfo = "1753-01-01"
        StoredProcQuery1.Parameters.Add(QueryParameter1)
        StoredProcQuery1.Parameters.Add(QueryParameter2)
        StoredProcQuery1.StoredProcName = "RepMacroscem_ReporteOperacionVenta1"
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {StoredProcQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel37, Me.XrLine3, Me.XrLabel32, Me.XrLabel33, Me.XrLabel34, Me.XrLabel35, Me.XrLabel36, Me.XrLabel13})
        Me.ReportFooter.Dpi = 254!
        Me.ReportFooter.HeightF = 143.1863!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel37
        '
        Me.XrLabel37.Dpi = 254!
        Me.XrLabel37.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(1358.417!, 50.24514!)
        Me.XrLabel37.Name = "XrLabel37"
        Me.XrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel37.SizeF = New System.Drawing.SizeF(122.4447!, 36.38333!)
        Me.XrLabel37.StylePriority.UseFont = false
        Me.XrLabel37.StylePriority.UseTextAlignment = false
        Me.XrLabel37.Text = "Totales"
        Me.XrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLine3
        '
        Me.XrLine3.Dpi = 254!
        Me.XrLine3.LineWidth = 3
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(7.599475E-05!, 16.60261!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(2760!, 22.43666!)
        '
        'XrLabel32
        '
        Me.XrLabel32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nDescuento")})
        Me.XrLabel32.Dpi = 254!
        Me.XrLabel32.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(2266.815!, 50.24514!)
        Me.XrLabel32.Name = "XrLabel32"
        Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel32.SizeF = New System.Drawing.SizeF(150.7305!, 36.38333!)
        Me.XrLabel32.StylePriority.UseFont = false
        Me.XrLabel32.StylePriority.UseTextAlignment = false
        XrSummary1.FormatString = "{0:n2}"
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel32.Summary = XrSummary1
        Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel33
        '
        Me.XrLabel33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nPrecioImpuesto2")})
        Me.XrLabel33.Dpi = 254!
        Me.XrLabel33.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(1795.243!, 50.24514!)
        Me.XrLabel33.Name = "XrLabel33"
        Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel33.SizeF = New System.Drawing.SizeF(157.1904!, 36.38334!)
        Me.XrLabel33.StylePriority.UseFont = false
        Me.XrLabel33.StylePriority.UseTextAlignment = false
        XrSummary2.FormatString = "{0:n2}"
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel33.Summary = XrSummary2
        Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel34
        '
        Me.XrLabel34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nPrecioImpuesto3")})
        Me.XrLabel34.Dpi = 254!
        Me.XrLabel34.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(1952.433!, 50.24514!)
        Me.XrLabel34.Name = "XrLabel34"
        Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel34.SizeF = New System.Drawing.SizeF(157.1906!, 36.38334!)
        Me.XrLabel34.StylePriority.UseFont = false
        Me.XrLabel34.StylePriority.UseTextAlignment = false
        XrSummary3.FormatString = "{0:n2}"
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel34.Summary = XrSummary3
        Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel35
        '
        Me.XrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nVenta")})
        Me.XrLabel35.Dpi = 254!
        Me.XrLabel35.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(2109.624!, 50.24514!)
        Me.XrLabel35.Name = "XrLabel35"
        Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel35.SizeF = New System.Drawing.SizeF(157.1907!, 36.38334!)
        Me.XrLabel35.StylePriority.UseFont = false
        Me.XrLabel35.StylePriority.UseTextAlignment = false
        XrSummary4.FormatString = "{0:n2}"
        XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel35.Summary = XrSummary4
        Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel36
        '
        Me.XrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nPrecioImpuesto1")})
        Me.XrLabel36.Dpi = 254!
        Me.XrLabel36.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(1638.052!, 50.24514!)
        Me.XrLabel36.Name = "XrLabel36"
        Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel36.SizeF = New System.Drawing.SizeF(157.1906!, 36.38334!)
        Me.XrLabel36.StylePriority.UseFont = false
        Me.XrLabel36.StylePriority.UseTextAlignment = false
        XrSummary5.FormatString = "{0:n2}"
        XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel36.Summary = XrSummary5
        Me.XrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel13
        '
        Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RepMacroscem_ReporteOperacionVenta1.nNeto")})
        Me.XrLabel13.Dpi = 254!
        Me.XrLabel13.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(1480.862!, 50.24515!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(157.1899!, 36.38334!)
        Me.XrLabel13.StylePriority.UseFont = false
        Me.XrLabel13.StylePriority.UseTextAlignment = false
        XrSummary6.FormatString = "{0:n2}"
        XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel13.Summary = XrSummary6
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptReporteOperacionVenta1
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.DataMember = "RepMacroscem_ReporteOperacionVenta1"
        Me.DataSource = Me.SqlDataSource1
        Me.Dpi = 254!
        Me.Landscape = true
        Me.Margins = New System.Drawing.Printing.Margins(104, 106, 254, 149)
        Me.PageHeight = 2100
        Me.PageWidth = 2970
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.Version = "15.1"
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
End Class
