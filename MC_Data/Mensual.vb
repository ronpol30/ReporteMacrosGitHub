Public Class Mensual
    Public Class MensualBE
        Property IDMensual As Int32
        Property Nombre As String
    End Class

    Public Class MensualDAO
        Dim Lista As New List(Of MensualBE)

        Public Sub New()

            Lista.Add(New MensualBE With {.IDMensual = 0, .Nombre = "FIN DE MES"})
            For Index = 1 To 31
                Lista.Add(New MensualBE With {.IDMensual = Index, .Nombre = Index.ToString})
            Next

        End Sub

        Public Function GetMensual() As List(Of MensualBE)
            Return Lista
        End Function

    End Class
End Class
