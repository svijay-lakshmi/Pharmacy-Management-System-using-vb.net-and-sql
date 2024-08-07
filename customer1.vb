Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class customer1
    Dim connection As New SqlConnection("Data Source=DESKTOP-KTBHN7P\SQLEXPRESS;Initial Catalog=HC;Integrated Security=True;Encrypt=False")
    Private Sub DisplayddetailsData()
        Try
            Dim query As String = "SELECT * FROM udetail"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DisplayddetailsData()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim command As New SqlCommand("DELETE FROM udetail WHERE c_id = @c_id", connection)
        command.Parameters.AddWithValue("@c_id", TextBox1.Text)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Customer details deleted")
            DisplayddetailsData()
        Else
            MessageBox.Show("Failed to delete Customer details")
        End If
        connection.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        dash5.Show()
    End Sub
End Class