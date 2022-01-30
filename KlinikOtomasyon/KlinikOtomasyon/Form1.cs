using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KlinikOtomasyon
{
    public partial class Form1 : Form
    {
        string cinsiyet = "Erkek";
        string gelenHastaTC, gelenHekimTC, randevunoreferans;
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-G9CEIOG\\MSSQLS;Initial Catalog=KlinikOtomasyon;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void randevulistegetir()
        {
            randevuliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from RandevuTablo", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["RandevuNo"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HastaTC"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["DoktorAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["TedaviTuru"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["Saat"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["Tarih"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["RandevuNotu"].ToString().TrimEnd());
                randevuliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void hastalistegetir()
        {
            hastaliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from HastaTablo", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HastaTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HastaAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaAdres"].ToString().TrimEnd());
                hastaliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void doktorlistegetir()
        {
            hekimliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * from HekimTablo", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HekimTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HekimAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimAdres"].ToString().TrimEnd());
                hekimliste.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void randevuallistegetir()
        {
            Rhastaliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from HastaTablo", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HastaTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HastaAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaAdres"].ToString().TrimEnd());
                Rhastaliste.Items.Add(ekle);

            }

            baglanti.Close();

            ////////////////////////////////////////////////////
            Rhekimliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt1 = new SqlCommand("Select * from HekimTablo", baglanti);
            SqlDataReader oku1 = kmt1.ExecuteReader();

            while (oku1.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku1["HekimTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku1["HekimAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku1["HekimSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku1["HekimCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku1["HekimDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku1["HekimTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku1["HekimEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku1["HekimAdres"].ToString().TrimEnd());
                Rhekimliste.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void hastalistetemizle()
        {
            hastalistetcbox.Clear();
            hastalisteadbox.Clear();
            hastalistesoyadbox.Clear();
            hastalistedtarihbox.Value = DateTime.Now;
            hastalistetelnobox.Clear();
            hastalistepostabox.Clear();
            hastalisteadresbox.Clear();
            hastalistesilbtn.Enabled = false;


        }

        private void hekimlistetemizle()
        {
            hekimlistetcbox.Clear();
            hekimlisteadbox.Clear();
            hekimlistesoyadbox.Clear();
            hekimlistedtarihbox.Value = DateTime.Now;
            hekimlistetelnobox.Clear();
            hekimlistepostabox.Clear();
            hekimlisteadresbox.Clear();
            hekimlistesil.Enabled = false;
        }

        private void hastaekletemizle()
        {
            hastatctbox.Clear();
            hastaadtbox.Clear();
            hastasoyadtbox.Clear();
            hastadtarihtbox.Value = DateTime.Now;
            hastatelefontbox.Clear();
            hastaepostatbox.Clear();
            hastaadrestbox.Clear();
        }

        private void hekimekletemizle()
        {
            hekimtctbox.Clear();
            hekimadtbox.Clear();
            hekimsoyadtbox.Clear();
            hekimdtarihtbox.Value = DateTime.Now;
            hekimteltbox.Clear();
            hekimpostatbox.Clear();
            hekimadrestbox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into HastaTablo(HastaTC,HastaAd,HastaSoyad,HastaCinsiyet,HastaDogumTarihi,HastaTelefon,HastaEposta,HastaAdres) values('" + hastatctbox.Text.ToString() + "','" + hastaadtbox.Text.ToString() + "','" + hastasoyadtbox.Text.ToString() + "','" + cinsiyet + "','" + hastadtarihtbox.Value.ToString("yyyy-MM-dd") + "','" + hastatelefontbox.Text.ToString() + "','" + hastaepostatbox.Text.ToString() + "','" + hastaadrestbox.Text.ToString() + "')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hasta Başarıyla Kaydedildi!");
            hastaekletemizle();
        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Erkek";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Kadın";
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                hastalistegetir();
            }
            if (tabControl1.SelectedIndex == 4)
            {
                doktorlistegetir();
            }
            if (tabControl1.SelectedIndex == 5)
            {
                randevuallistegetir();
            }
            if (tabControl1.SelectedIndex == 0)
            {
                randevulistegetir();
            }
        }

        private void hastaliste_DoubleClick(object sender, EventArgs e)
        {
            hastalistetcbox.Text = hastaliste.SelectedItems[0].SubItems[0].Text;
            gelenHastaTC = hastalistetcbox.Text;
            hastalisteadbox.Text = hastaliste.SelectedItems[0].SubItems[1].Text;
            hastalistesoyadbox.Text = hastaliste.SelectedItems[0].SubItems[2].Text;
            string ckontrol = hastaliste.SelectedItems[0].SubItems[3].Text;
            if (ckontrol == "Erkek") { rbErkek.Select(); cinsiyet = "Erkek"; }
            else { rbKadın.Select(); cinsiyet = "Kadın"; }
            hastalistedtarihbox.Text = hastaliste.SelectedItems[0].SubItems[4].Text;
            hastalistetelnobox.Text = hastaliste.SelectedItems[0].SubItems[5].Text;
            hastalistepostabox.Text = hastaliste.SelectedItems[0].SubItems[6].Text;
            hastalisteadresbox.Text = hastaliste.SelectedItems[0].SubItems[7].Text;
            hastalistesilbtn.Enabled = true;
        }

        private void doktorkaydet_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into HekimTablo(HekimTC,HekimAd,HekimSoyad,HekimCinsiyet,HekimDogumTarihi,HekimTelefon,HekimEposta,HekimAdres) values('" + hekimtctbox.Text.ToString() + "','" + hekimadtbox.Text.ToString() + "','" + hekimsoyadtbox.Text.ToString() + "','" + cinsiyet + "','" + hekimdtarihtbox.Value.ToString("yyyy-MM-dd") + "','" + hekimteltbox.Text.ToString() + "','" + hekimpostatbox.Text.ToString() + "','" + hekimadrestbox.Text.ToString() + "')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hekim Başarıyla Kaydedildi!");
            hekimekletemizle();
        }

        private void hekimradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Erkek";
        }

        private void hekimradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Kadın";
        }

        private void hastalisteguncelle_Click(object sender, EventArgs e)
        {
            if (rbErkek.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            else
            {
                cinsiyet = "Kadın";
            }
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Update HastaTablo set HastaTC='" + hastalistetcbox.Text.ToString() + "',HastaAd='" + hastalisteadbox.Text.ToString() + "',HastaSoyad='" + hastalistesoyadbox.Text.ToString() + "',HastaCinsiyet='" + cinsiyet + "',HastaDogumTarihi='" + hastalistedtarihbox.Value.ToString("yyyy-MM-dd") + "',HastaTelefon='" + hastalistetelnobox.Text.ToString() + "',HastaEposta='" + hastalistepostabox.Text.ToString() + "',HastaAdres='" + hastalisteadresbox.Text.ToString() + "' where HastaTC='" + gelenHastaTC + "'", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hastalistegetir();
            hastalistetemizle();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Delete from HastaTablo where HastaTC='" + gelenHastaTC + "'", baglanti);
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hastalistegetir();
                hastalistetemizle();

            }
        }

        private void hastalisteara_TextChanged(object sender, EventArgs e)
        {
            hastaliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from HastaTablo where HastaTC like '" + hastalisteara.Text + "%' ", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HastaTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HastaAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaAdres"].ToString().TrimEnd());
                hastaliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastaekletemizle();
        }

        private void randevualhastaara_TextChanged(object sender, EventArgs e)
        {
            Rhastaliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from HastaTablo where HastaTC like '" + randevualhastaara.Text + "%' ", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HastaTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HastaAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaAdres"].ToString().TrimEnd());
                Rhastaliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void randevualhekimara_TextChanged(object sender, EventArgs e)
        {
            Rhekimliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from HekimTablo where HekimTC like '" + randevualhekimara.Text + "%' ", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HekimTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HekimAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimAdres"].ToString().TrimEnd());
                Rhekimliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hekimekletemizle();
        }

        private void hekimliste_DoubleClick(object sender, EventArgs e)
        {
            hekimlistetcbox.Text = hekimliste.SelectedItems[0].SubItems[0].Text;
            gelenHekimTC = hekimlistetcbox.Text;
            hekimlisteadbox.Text = hekimliste.SelectedItems[0].SubItems[1].Text;
            hekimlistesoyadbox.Text = hekimliste.SelectedItems[0].SubItems[2].Text;
            string ckontrol = hekimliste.SelectedItems[0].SubItems[3].Text;
            if (ckontrol == "Erkek") { rbhekimerkek.Select(); cinsiyet = "Erkek"; }
            else { rbhekimkadin.Select(); cinsiyet = "Kadın"; }
            hekimlistedtarihbox.Text = hekimliste.SelectedItems[0].SubItems[4].Text;
            hekimlistetelnobox.Text = hekimliste.SelectedItems[0].SubItems[5].Text;
            hekimlistepostabox.Text = hekimliste.SelectedItems[0].SubItems[6].Text;
            hekimlisteadresbox.Text = hekimliste.SelectedItems[0].SubItems[7].Text;
            hekimlistesil.Enabled = true;
        }

        private void hekimlistesiguncelle_Click(object sender, EventArgs e)
        {
            
            if (rbhekimerkek.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            else
            {
                cinsiyet = "Kadın";
            }
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Update HekimTablo set HekimTC='" + hekimlistetcbox.Text.ToString() + "',HekimAd='" + hekimlisteadbox.Text.ToString() + "',HekimSoyad='" + hekimlistesoyadbox.Text.ToString() + "',HekimCinsiyet='" + cinsiyet + "',HekimDogumTarihi='" + hekimlistedtarihbox.Value.ToString("yyyy-MM-dd") + "',HekimTelefon='" + hekimlistetelnobox.Text.ToString() + "',HekimEposta='" + hekimlistepostabox.Text.ToString() + "',HekimAdres='" + hekimlisteadresbox.Text.ToString() + "' where HekimTC='" + gelenHekimTC + "'", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            doktorlistegetir();
            hekimlistetemizle();
        
        }

        private void hekimlistesil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Delete from HekimTablo where HekimTC='" + gelenHekimTC + "'", baglanti);
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doktorlistegetir();
                hekimlistetemizle();
            }

        }

        private void hekimlisteara_TextChanged(object sender, EventArgs e)
        {
            hekimliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from HekimTablo where HekimTC like '" + hekimlisteara.Text + "%' ", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HekimTC"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HekimAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimSoyad"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimCinsiyet"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimDogumTarihi"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimTelefon"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimEposta"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HekimAdres"].ToString().TrimEnd());
                hekimliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void Rhastaliste_DoubleClick(object sender, EventArgs e)
        {
            randevuhastatc.Text = Rhastaliste.SelectedItems[0].SubItems[0].Text;
            randevuhastaadsoyad.Text = Rhastaliste.SelectedItems[0].SubItems[1].Text + " " + Rhastaliste.SelectedItems[0].SubItems[2].Text;
        }

        private void Rhekimliste_DoubleClick(object sender, EventArgs e)
        {

            randevuhekimad.Text = Rhekimliste.SelectedItems[0].SubItems[1].Text + " " + Rhekimliste.SelectedItems[0].SubItems[2].Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into RandevuTablo(HastaTC,HastaAd,DoktorAd,TedaviTuru,Saat,Tarih,RandevuNotu) values('" + randevuhastatc.Text.ToString() + "','" + randevuhastaadsoyad.Text.ToString() + "','" + randevuhekimad.Text.ToString() + "','" + randevutedavituru.Text.ToString() + "','" + randevusaat.Text.ToString() + "','" + randevutarih.Value.ToString("yyyy-MM-dd") + "','" + randevunotu.Text.ToString() + "')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu Başarıyla Kaydedildi!");
            randevuhastatc.Text = "-";
            randevuhastaadsoyad.Text = "-";
            randevuhekimad.Text = "-";
            randevutedavituru.Text = "";
            randevusaat.Text = "";
            randevutarih.Value = DateTime.Now;
            randevunotu.Clear();
        
        }

        private void randevutcara_TextChanged(object sender, EventArgs e)
        {
            randevuliste.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select *from RandevuTablo where HastaTC like '" + randevutcara.Text + "%' ", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["RandevuNo"].ToString().TrimEnd();
                ekle.SubItems.Add(oku["HastaTC"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["HastaAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["DoktorAd"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["TedaviTuru"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["Saat"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["Tarih"].ToString().TrimEnd());
                ekle.SubItems.Add(oku["RandevuNotu"].ToString().TrimEnd());
                randevuliste.Items.Add(ekle);

            }

            baglanti.Close();
        }

        private void randevusil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Bu kaydı silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("Delete from RandevuTablo where RandevuNo='" + randevunoreferans + "'", baglanti);
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Randevu Başarılı Bir Şekilde Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                randevulistegetir();
            }
        }

        private void randevuliste_Click(object sender, EventArgs e)
        {
             randevunoreferans = randevuliste.SelectedItems[0].SubItems[0].Text;
        }
    }
}
