Imports System.Data.OleDb
Public Class Form4
    Dim yol As String
    Dim aa As Integer
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim baglantı As New OleDbConnection _
            ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='hastane_vt.mdb'")
        Dim adaptor As New OleDbDataAdapter("select * from hastalar", baglantı)
        Dim tablo1 As New DataTable
        Dim dataset1 As New DataSet

        'bağlantılar
        adaptor.Fill(tablo1)
        dataset1.Tables.Add(tablo1)
        BindingSource1.DataSource = dataset1
        BindingSource1.DataMember = dataset1.Tables(0).TableName
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BindingNavigatorMoveFirstItem.PerformClick()
        Dim a As Integer
        a = Val(BindingNavigatorPositionItem.Text)
        TextBox1.Text = DataGridView1.Rows(a - 1).Cells(0).Value.ToString()
        TextBox2.Text = DataGridView1.Rows(a - 1).Cells(1).Value.ToString()
        TextBox3.Text = DataGridView1.Rows(a - 1).Cells(2).Value.ToString()

        Try
            Image.FromFile(DataGridView1.Rows(a).Cells(7).Value.ToString())
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BindingNavigatorMoveLastItem.PerformClick()
        Dim a As Integer
        a = Val(BindingNavigatorPositionItem.Text)

        TextBox4.Text = DataGridView1.Rows(a - 1).Cells(0).Value.ToString()
        TextBox5.Text = DataGridView1.Rows(a - 1).Cells(1).Value.ToString()
        TextBox6.Text = DataGridView1.Rows(a - 1).Cells(2).Value.ToString()

        Try

            Image.FromFile(DataGridView1.Rows(a).Cells(7).Value.ToString())
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim kriter As String
        kriter = "select * from hastalar WHERE hastano=" + TextBox7.Text
        Dim baglantı As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='hastane_vt.mdb'")
        Dim adaptor As New OleDbDataAdapter(kriter, baglantı)
        Dim tablo1 As New DataTable
        Dim dataset1 As New DataSet
        adaptor.Fill(tablo1)
        dataset1.Tables.Add(tablo1)
        BindingSource1.DataSource = dataset1
        BindingSource1.DataMember = dataset1.Tables(0).TableName
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
        Try
            TextBox7.Text = DataGridView1.Rows(0).Cells(0).Value.ToString()
            TextBox8.Text = DataGridView1.Rows(0).Cells(1).Value.ToString()
            TextBox9.Text = DataGridView1.Rows(0).Cells(2).Value.ToString()
            TextBox10.Text = DataGridView1.Rows(0).Cells(3).Value.ToString()
            TextBox11.Text = DataGridView1.Rows(0).Cells(4).Value.ToString()

        Catch ex As Exception
            MsgBox("Aradığınız kayıt bulunamadı")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim baglantı As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='hastane_vt.mdb'")
        Dim adaptor As New OleDbDataAdapter("select * from hastalar", baglantı)
        Dim tablo1 As New DataTable
        Dim dataset1 As New DataSet
        adaptor.Fill(tablo1)
        dataset1.Tables.Add(tablo1)
        BindingSource1.DataSource = dataset1
        BindingSource1.DataMember = dataset1.Tables(0).TableName
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim baglantı2 As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='hastane_vt.mdb'")
        Dim eklekomutu As New OleDbCommand
        baglantı2.Open()
        eklekomutu.Connection = baglantı2

        eklekomutu.CommandText = "delete from hastalar WHERE hastano = " + TextBox12.Text
        MsgBox(eklekomutu.CommandText)
        eklekomutu.ExecuteNonQuery()
        baglantı2.Close()
        Button4.PerformClick()

        TextBox12.Text = ""
    End Sub
End Class