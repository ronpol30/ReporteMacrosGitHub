Imports System
Imports DevExpress.XtraReports.UI
' ... 

Public Class XtraReport1
    Private Sub XrLabel3_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        Dim s As String = (e.PageIndex + 1).ToString()

        ' Change the label's text and bookmark to reflect the page number. 
        CType(sender, XRLabel).Bookmark += s
        CType(sender, XRLabel).Text += s
    End Sub
End Class