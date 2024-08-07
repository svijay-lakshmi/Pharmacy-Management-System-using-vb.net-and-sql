
Imports System
Imports System.Data
        Imports System.Data.SqlClient
        Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class delivery
    Dim connection As New SqlConnection("Data Source=DESKTOP-KTBHN7P\SQLEXPRESS;Initial Catalog=HC;Integrated Security=True;Encrypt=False")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("INSERT into del (Cutomer_name, House_no, Street_add, City, Pin_code, Phone_no, Description)" & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')", connection)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Delivery Details saved")
        Else
            MessageBox.Show("Delivery details not saved")
        End If
        connection.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        userb7.Show()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim combinedText As String = TextBox1.Text & " " & TextBox2.Text & " " & TextBox3.Text & " " & TextBox4.Text & " " & TextBox5.Text & " " & TextBox6.Text ' Add more textboxes as needed
        Label9.Text = combinedText
    End Sub
End Class


