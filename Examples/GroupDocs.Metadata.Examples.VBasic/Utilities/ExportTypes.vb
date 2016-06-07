Public NotInheritable Class ExportTypes
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property ToDataSet() As Integer
        Get
            Return 1
        End Get
    End Property
    Public Shared ReadOnly Property ToExcel() As Integer
        Get
            Return 2
        End Get
    End Property
    Public Shared ReadOnly Property ToCSV() As Integer
        Get
            Return 3
        End Get
    End Property
End Class
