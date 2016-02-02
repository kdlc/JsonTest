Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        Me.Label1.Text = String.Empty

        request = DirectCast(WebRequest.Create("http://localhost:3000/db"), HttpWebRequest)

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim js As New System.Web.Script.Serialization.JavaScriptSerializer
        Dim myModel As MyModel = js.Deserialize(Of MyModel)(rawresp)

        Me.Label1.Text = myModel.response.Item(0).Status

    End Sub


End Class

Public Class MyModel
    Public Property data As List(Of MyCustomerData)
    Public Property response As List(Of MyResponseData)
End Class

Public Class MyCustomerData
    Public Property CustomerID As Integer
    Public Property Name As String
    Public Property Telephone As String
End Class

Public Class MyResponseData
    Public Property Status As String
End Class


