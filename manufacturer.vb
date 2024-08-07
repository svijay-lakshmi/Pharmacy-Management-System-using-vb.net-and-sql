Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class manufacturer
    Dim connection As New SqlConnection("Data Source=DESKTOP-KTBHN7P\SQLEXPRESS;Initial Catalog=HC;Integrated Security=True;Encrypt=False")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("INSERT into manu (Company_ID, Company_Nmae, Contact_No, Address)" & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')", connection)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Manufacturer details added")
            DisplaycdetailsData()
        Else
            MessageBox.Show("Manufacturer details  not added")
        End If
        connection.Close()
    End Sub
    Private Sub DisplaycdetailsData()
        Dim adapter As New SqlDataAdapter("SELECT * FROM manu", connection)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub
    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click
        Try
            Dim query As String = "UPDATE manu SET Company_ID = @Company_ID, Company_Name = @Company_Name, Contact_No = @Contact_No, Address = @Address WHERE Company_ID= @Company_ID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Company_ID", TextBox1.Text)
                command.Parameters.AddWithValue("@Company_Nmae", TextBox2.Text)
                command.Parameters.AddWithValue("@Contact_No", TextBox3.Text)
                command.Parameters.AddWithValue("@Address", TextBox4.Text)
                connection.Open()
                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Manufacturer details updated")
                    DisplaycdetailsData()
                Else
                    MessageBox.Show("Failed to update Manufacturer")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = selectedRow.Cells("Company_ID").Value.ToString()
            TextBox2.Text = selectedRow.Cells("Company_Nmae").Value.ToString()
            TextBox3.Text = selectedRow.Cells("Contact_No").Value.ToString()
            TextBox4.Text = selectedRow.Cells("Address").Value.ToString()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim command As New SqlCommand("DELETE FROM manu WHERE Company_ID = @Company_ID", connection)
        command.Parameters.AddWithValue("@Company_ID", TextBox1.Text)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Manufacturer details deleted")
            DisplaycdetailsData()
        Else
            MessageBox.Show("Failed to delete Manufacturer details")
        End If
        connection.Close()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        dash5.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DisplaycdetailsData()
    End Sub
End Class