Imports System.Management

Public Class UIMain

    Private Function GetProperty(ByVal cls As String, ByVal pprty As String) As String

        Try
            Dim searcher As New ManagementObjectSearcher(
                "root\CIMV2",
                "SELECT * FROM " & cls)

            For Each queryObj As ManagementObject In searcher.Get()

                GetProperty = queryObj(pprty).ToString
            Next

        Catch err As ManagementException
            MessageBox.Show(err.Message)
        End Try

    End Function



    Private Function GetNum(ByVal str As String) As String
        Dim result As String = ""
        For Each c As Char In str
            If Not c = " " Then
                result = result & Asc(c)
            End If

        Next

        GetNum = result

    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim res As String

        res = GetProperty("Win32_PhysicalMedia", "SerialNumber") & GetProperty("Win32_BaseBoard", "Product")
        TextBox1.Text = (res)

        TextBox2.Text = GetNum(res)

        TextBox3.Text = Math.Abs(res.GetHashCode).ToString()
    End Sub
End Class
