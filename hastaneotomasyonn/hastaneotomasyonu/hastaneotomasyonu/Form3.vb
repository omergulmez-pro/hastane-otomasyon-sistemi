Imports System.Data.OleDb
Public Class Form3
    Dim baglanti As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = hastane_vt.mdb")


    Private Sub temizle()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = " "
        ComboBox2.Text = " "

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Üroloji" Then
            ComboBox2.Items.Add("EMRAH MENEK")
            ComboBox2.Items.Add("HASAN YAVUZ")
        ElseIf ComboBox1.Text = "Estetik Cerrahisi" Then
            ComboBox2.Items.Add("SEDANUR ENZİN")
            ComboBox2.Items.Add("BURAK KORKMAZ")
        ElseIf ComboBox1.Text = "Kardiyoloji" Then
            ComboBox2.Items.Add("CİHAT ENZİN")
        ElseIf ComboBox1.Text = "Ortopedi ve Travmotoloji" Then
            ComboBox2.Items.Add("BERAT KORKMAZ")
        ElseIf ComboBox1.Text = "Beyin ve Sinir Cerrahisi" Then
            ComboBox2.Items.Add("MEDİNE ÖNER")
            ComboBox2.Items.Add("İBRAHİM KORKMAZ")
        ElseIf ComboBox1.Text = "Kadın Hastalıkları ve Doğum" Then
            ComboBox2.Items.Add("FATMA BETÜL PALTA")
        ElseIf ComboBox1.Text = "Nöroloji" Then
            ComboBox2.Items.Add("MEHMET ÇOŞKUN")
            ComboBox2.Items.Add("FATMA ÖNER")
        ElseIf ComboBox1.Text = "Çocuk Onkolojisi" Then
            ComboBox2.Items.Add("BURHAN KORKMAZ")
            ComboBox2.Items.Add("BÜŞRA KORKMAZ")
        ElseIf ComboBox1.Text = "Fizyoterapi" Then
            ComboBox2.Items.Add("ÇAĞLANUR ENZİN")
        ElseIf ComboBox1.Text = "Kulak Burun Boğaz" Then
            ComboBox2.Items.Add("ŞEMSETTİN ENZİN")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "") Then
            MsgBox("TC KİMLİK NO kısmını boş bırakamazsınız")
        ElseIf (TextBox2.Text = "") Then
            MsgBox("ADI SOYADI kısmını boş bırakamazsınız")
        Else
            baglanti.Open()
            Dim Komut1 As New OleDbCommand("insert into hastalar(hasta_tc,hasta_adi_soyadi,bolum,doktor,tarih) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + ComboBox1.Text + "','" + ComboBox2.Text + "' ,'" + DateTimePicker1.Text + "')", baglanti)
            Komut1.ExecuteNonQuery()
            MessageBox.Show("Hasta Kayıt Edildi.", "Kayıt")
            temizle()
            baglanti.Close()
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class