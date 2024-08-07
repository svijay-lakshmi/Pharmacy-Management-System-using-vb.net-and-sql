Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class feedback
    Dim connection As New SqlConnection("Data Source=DESKTOP-KTBHN7P\SQLEXPRESS;Initial Catalog=HC;Integrated Security=True;Encrypt=False")
    Dim Timestamp As DateTime = DateTime.Now
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        userb7.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        Radiobutton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("INSERT INTO feedback (Availabity_of_products, Offers_on_products, Customer_services, Delivery_services, Customer_Suggestions, Rating, Timestamp, username) VALUES (@Availabity_of_products, @Offers_on_products, @Customer_services, @Delivery_services, @Customer_Suggestions, @Rating, @Timestamp, @username)", connection)
        command.Parameters.AddWithValue("@Availabity_of_products", TextBox1.Text)
        command.Parameters.AddWithValue("@Offers_on_products", TextBox2.Text)
        command.Parameters.AddWithValue("@Customer_services", TextBox3.Text)
        command.Parameters.AddWithValue("@Delivery_services", TextBox4.Text)
        command.Parameters.AddWithValue("@Customer_Suggestions", TextBox5.Text)
        command.Parameters.AddWithValue("@Rating", GetRating())
        command.Parameters.AddWithValue("@Timestamp", Timestamp)
        command.Parameters.AddWithValue("@username", TextBox6.Text) ' Replace with the actual username
        Try
            connection.Open()
            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Feedback added. Thank you.")
            Else
                MessageBox.Show("Feedback not added.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub
    Private Function GetRating() As Integer
        If Radiobutton1.Checked Then
            Return 5
        ElseIf RadioButton2.Checked Then
            Return 4
        ElseIf RadioButton3.Checked Then
            Return 3
        ElseIf RadioButton4.Checked Then
            Return 1
        Else
            Return 0 ' Default rating if none selected
        End If
    End Function
End Class