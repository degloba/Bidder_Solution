Public NotInheritable Class CBidder

    Private Shared ReadOnly _bidder As New CBidder()

    Public Shared Function GetInstance() As CBidder
        Return _bidder
    End Function

End Class
