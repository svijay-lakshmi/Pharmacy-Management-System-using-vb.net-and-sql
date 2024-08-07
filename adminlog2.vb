Public Class admin_login
    Private users As New Dictionary(Of String, String) From {
        {"Dev", "Dev"},
        {"Jay", "Jay"},
        {"Viju", "Viju"}
    }
    Private Sub inbtn_Click(sender As Object, e As EventArgs) Handles inbtn.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        If AuthenticateUser(username, password) Then
            MessageBox.Show("Login successful!")
            Me.Hide()
            dash5.Show()
        Else
            MessageBox.Show("Invalid username or password. Please try again.")
        End If
        Me.Hide()
        dash5.Show()
    End Sub
    Private Function AuthenticateUser(username As String, password As String) As Boolean
        If users.ContainsKey(username) Then
            If users(username) = password Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        Me.Hide()
        Form1.Show()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class
