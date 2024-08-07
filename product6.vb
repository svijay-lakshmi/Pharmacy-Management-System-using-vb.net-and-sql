Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class product6
    Dim connection As New SqlConnection("Data Source=DESKTOP-KTBHN7P\SQLEXPRESS;Initial Catalog=HC;Integrated Security=True;Encrypt=False")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("INSERT into product (P_ID, product_name, product_price, mfg_date, exp_date, category)" & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')", connection)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Product added")
            DisplaycdetailsData()
        Else
            MessageBox.Show("Product not added")
        End If
        connection.Close()
    End Sub
    Private Sub DisplaycdetailsData()
        Dim adapter As New SqlDataAdapter("SELECT * FROM product", connection)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles edit.Click
        Try
            Dim query As String = "UPDATE product SET P_ID = @P_ID, product_name = @product_name, product_price = @product_price, mfg_date = @mfg_date, exp_date = @exp_date, category = @category WHERE P_ID= @P_ID"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@P_ID", TextBox1.Text)
                command.Parameters.AddWithValue("@product_name", TextBox2.Text)
                command.Parameters.AddWithValue("@product_price", TextBox3.Text)
                command.Parameters.AddWithValue("@mfg_date", TextBox4.Text)
                command.Parameters.AddWithValue("@exp_date", TextBox5.Text)
                command.Parameters.AddWithValue("@category", TextBox6.Text)
                connection.Open()
                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Product updated")
                    DisplaycdetailsData()
                Else
                    MessageBox.Show("Failed to update Product")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = selectedRow.Cells("P_ID").Value.ToString()
            TextBox2.Text = selectedRow.Cells("product_name").Value.ToString()
            TextBox3.Text = selectedRow.Cells("product_price").Value.ToString()
            TextBox4.Text = selectedRow.Cells("mfg_date").Value.ToString()
            TextBox5.Text = selectedRow.Cells("exp_date").Value.ToString()
            TextBox6.Text = selectedRow.Cells("category").Value.ToString()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim command As New SqlCommand("DELETE FROM product WHERE P_ID = @P_ID", connection)
        command.Parameters.AddWithValue("@P_ID", TextBox1.Text)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Product deleted")
            DisplaycdetailsData()
        Else
            MessageBox.Show("Failed to delete Product")
        End If
        connection.Close()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub
    Private Sub exitbtn_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        Me.Hide()
        dash5.Show()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        dash5.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DisplaycdetailsData()
    End Sub
End Class