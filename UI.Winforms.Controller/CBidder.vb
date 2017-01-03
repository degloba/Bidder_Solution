Public NotInheritable Class CBidder

    Private Shared ReadOnly _bidder As New CBidder()

    Public Shared Function GetInstance() As CBidder
        Return _bidder
    End Function


    Public Function ObtenirBidder() As IList(Of signevital)

        ' RestFul
        Using client As New Net.WebClient

            Dim content As String = client.DownloadString(String.Format("{0}/{1}/{2}/{3}/{4}/", "url_rest", Nothing, Nothing, Nothing))

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of signeVital))(content)
        End Using

    End Function

End Class
