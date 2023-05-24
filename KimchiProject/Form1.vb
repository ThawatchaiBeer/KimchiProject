Imports System.Diagnostics.Eventing.Reader
Imports System.Security.Cryptography

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "Kirati" And TextBox2.Text = "12345" Then
            MessageBox.Show("เข้าสู่ระบบสำเร็จ", "การเข้าสู่ระบบ", MessageBoxButtons.OK)
            Form2.Show()
            Me.Hide()
        Else
            MessageBox.Show("Username หรือ Password ไม่ถูกต้อง", "การเข้าสู่ระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If





    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = "Kirati" And TextBox2.Text = "12345" Then
                MessageBox.Show("เข้าสู่ระบบสำเร็จ", "การเข้าสู่ระบบ", MessageBoxButtons.OK)
                Form2.Show()
                Me.Hide()
            Else
                MessageBox.Show("Username หรือ Password ไม่ถูกต้อง", "การเข้าสู่ระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
