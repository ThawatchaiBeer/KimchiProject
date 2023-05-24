Imports System.IO
Imports System.Data.OleDb
Imports System.Diagnostics.PerformanceData
Imports System.Security.Authentication.ExtendedProtection

Public Class Form2
    Dim ds As New DataSet()
    Dim ConnStr As String
    Dim cmd As OleDb.OleDbCommand
    Dim conn As New OleDb.OleDbConnection
    Dim Str As String
    Dim da As New OleDbDataAdapter
    Dim SqlqryCard As String
    Dim DtNow As DateTime = Date.Now
    Dim c As Integer = 0
    Dim pic As String
    Dim ID1 As String
    Dim Name1 As String
    Dim Price1 As String
    Dim ID As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KimchiDataSet.Sale' table. You can move, or remove it, as needed.
        Me.SaleTableAdapter2.Fill(Me.KimchiDataSet1.Sale)

        ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Kimchi\Kimchi.accdb"

        With conn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = ConnStr
            .Open()
        End With

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        ds.Clear()
        SqlqryCard = "SELECT * FROM Kimchi Where ID ='" & txtsearch.Text & "'"
        da = New OleDbDataAdapter(SqlqryCard, conn)
        da.Fill(ds, "qryCard")

        If ds.Tables("qryCard").Rows.Count > 0 Then


            txtsearch.Visible = True
            ID1 = ds.Tables("qryCard").Rows(0).Item("ID").ToString

            TextBox2.Text = ID1

            TextBox2.Visible = True
            Name1 = ds.Tables("qryCard").Rows(0).Item("Name").ToString
            TextBox2.Text = Name1

            TextBox3.Visible = True
            Price1 = ds.Tables("qryCard").Rows(0).Item("Price").ToString
            TextBox3.Text = Price1


            PictureBox1.Visible = True
            pic = ds.Tables("qryCard").Rows(0).Item("pic").ToString
            PictureBox1.ImageLocation = pic

        Else
            ds.Clear()
        End If

        If e.KeyCode = Keys.Enter Then
            If txtsearch.Text = "" Then
                MsgBox("กรุณากรอกไอดีกิมจิ")
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaleBindingSource.AddNew()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaleBindingSource.EndEdit()
        SaleTableAdapter2.Update(KimchiDataSet1.Sale)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaleBindingSource.RemoveCurrent()
        SaleBindingSource.EndEdit()
        SaleTableAdapter2.Update(KimchiDataSet1.Sale)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaleBindingSource.EndEdit()
        SaleTableAdapter2.Update(KimchiDataSet1.Sale)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged

    End Sub
End Class