Public Class know
    Private Sub know_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Assuming you have a Label named label1 on your form
        Label2.AutoSize = False
        Label2.Size = New Size(300, 200) ' Adjust the size as needed
        ' Label1.Multiline = True
        Label2.Text = "Welcome to Health Care Pharmacy, where your health is our priority. As a trusted healthcare provider in the community, we are dedicated to delivering excellence in pharmaceutical care. At Health Care Pharmacy, our knowledgeable and friendly staff are committed to providing personalized service and expert advice to meet your healthcare needs. From prescription medications to over-the-counter remedies, we offer a comprehensive range of pharmaceutical products to help you maintain your well-being. Additionally, we provide specialized services such as medication counseling, immunizations, and health screenings to support your health journey. Visit us today and experience the difference at Health Care Pharmacy."

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        userb7.Show()
    End Sub


End Class