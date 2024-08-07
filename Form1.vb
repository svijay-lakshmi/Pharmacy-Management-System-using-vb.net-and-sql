Public Class Form1
    Private Sub userButton_Click(sender As Object, e As EventArgs) Handles userButton.Click
        Me.Hide()
        userlogin3.Show()
    End Sub
    Private Sub adminbtn_Click(sender As Object, e As EventArgs) Handles adminbtn.Click
        Me.Hide()
        admin_login.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result = MessageBox.Show("are you sure you would like to exit?", "logging out",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (result = DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub
End Class
