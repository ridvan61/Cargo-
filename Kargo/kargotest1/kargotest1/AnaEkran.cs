using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace kargotest1
{
    public partial class AnaEkran : Form
    {
        long kargono;
        public AnaEkran()
        {        
           
            InitializeComponent();
            gbUcret.Visible = false;
            txtDesi.Enabled = false;    
            txtBoy.Enabled = false;
            txtAgirlik.Enabled = false;
            txtYukseklik.Enabled = false;
            txtEn.Enabled = false;
            panel6.Visible = false;
            textBox8.Enabled = false;
            tcgon.Enabled = false;
            textBox13.Enabled = false;
            textBox11.Enabled = false;
            textBox10.Enabled = false;
            cmbxilgon.Enabled = false;
            cmboxmahallegon.Enabled = false;
            cmbxilcegon.Enabled = false;
            textBox9.Enabled = false;
            textBox7.Enabled = false;
            tcal.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            cmbxilalici.Enabled = false;
            cmbxilcealici.Enabled = false;
            cmboxmahallealici.Enabled = false;
            textBox6.Enabled = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            label22.Visible = false;
            textBox14.Visible = false;
            label23.Visible = false;
            textBox7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            button4.Visible = false;
            panel2.Visible = false;
            groupBox3.Visible = false;
            label33.Visible = true;
            label34.Visible = true;
            texttcko.Visible = true;
            texttcko.Enabled = false;
            textBox26.Enabled = false;
            textBox26.Visible = true;
            textBox16.Visible = false;
            textBox15.Visible = false;
            label21.Visible = false;
            label24.Visible = false;
            textBox16.Enabled = false;
            textBox15.Enabled = false;
            textBox21.Enabled = false;
            textBox24.Enabled = false;
            textBox23.Enabled = false;
            mcmbxmah.Enabled = false;
            mcmbxilce.Enabled = false;
            mcmbxil.Enabled = false;
            button7.Visible = false;
        }
        SqlConnection baglanti = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True");
        private void AnaEkran_Load(object sender, EventArgs e)
        {
        }
        string gondericiil,alicil,alicilce,gonilce,gonmah,almah;
        string ilgondeger, ilalicideger;
        void ilgetiralici()
        {
            try
            {
                using (var baglanti = new SqlConnection("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Kargo61;Integrated Security=True"))
                {
                    baglanti.Open();
                    string komut = "SELECT * FROM sehir";
                    cmbxilalici.Items.Clear();
                    using (var cmd = new SqlCommand(komut, baglanti))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ilalicideger = dr["sehir_key"].ToString();
                            cmbxilalici.Items.Add(dr["sehir_title"]);
                        }
                    }
                }
                baglanti.Close  ();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void ilgetirgon()
        {
            try
            {
                using (var baglanti = new SqlConnection("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Kargo61;Integrated Security=True"))
                {
                    baglanti.Open();
                    string komut = "SELECT * FROM sehir";
                    cmbxilgon.Items.Clear();
                    using (var cmd = new SqlCommand(komut, baglanti))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ilgondeger = dr["sehir_key"].ToString();
                            cmbxilgon.Items.Add(dr["sehir_title"]);
                        }
                    }
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void milgetir()
        {
            try
            {
                using (var baglanti = new SqlConnection("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Kargo61;Integrated Security=True"))
                {
                    baglanti.Open();
                    string komut = "SELECT * FROM sehir";
                    mcmbxil.Items.Clear();
                    using (var cmd = new SqlCommand(komut, baglanti))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            mcmbxil.Items.Add(dr["sehir_title"]);
                        }
                    }
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void IlceGetiralici()
        {
            try
            {
                baglanti.Open();

                string komut = "select ilce.ilce_title from ilce inner join sehir on ilce.ilce_sehirkey = sehir.sehir_key where sehir_title = @sehirAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@sehirAd", cmbxilalici.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbxilcealici.Items.Add(dr["ilce_title"]);
                   
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void IlceGetirgon()
        {
            try
            {
                baglanti.Open();

                string komut = "select ilce.ilce_title from ilce inner join sehir on ilce.ilce_sehirkey = sehir.sehir_key where sehir_title = @sehirAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@sehirAd", cmbxilgon.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbxilcegon.Items.Add(dr["ilce_title"]);
                   
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void milcegeti()
        {
            try
            {
                baglanti.Open();

                string komut = "select ilce.ilce_title from ilce inner join sehir on ilce.ilce_sehirkey = sehir.sehir_key where sehir_title = @sehirAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@sehirAd", mcmbxil.Text);
                mcmbxilce.Items.Clear();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mcmbxilce.Items.Add(dr["ilce_title"]);

                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void mahallegetiralici()
        {
            try
            {
                baglanti.Open();

                string komut = "select mahalle.mahalle_title from mahalle inner join ilce on mahalle.mahalle_ilcekey = ilce.ilce_key where ilce.ilce_title = @ilceAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@ilceAd", cmbxilcealici.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmboxmahallealici.Items.Add(dr["mahalle_title"]);
                   
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void mahallegetirgon()
        {
            try
            {
                baglanti.Open();

                string komut = "select mahalle.mahalle_title from mahalle inner join ilce on mahalle.mahalle_ilcekey = ilce.ilce_key where ilce.ilce_title = @ilceAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@ilceAd", cmbxilcegon.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmboxmahallegon.Items.Add(dr["mahalle_title"]);
                    
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void mmahgetir()
        {
            try
            {
                baglanti.Open();

                string komut = "select mahalle.mahalle_title from mahalle inner join ilce on mahalle.mahalle_ilcekey = ilce.ilce_key where ilce.ilce_title = @ilceAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@ilceAd", mcmbxilce.Text);
                mcmbxmah.Items.Clear();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mcmbxmah.Items.Add(dr["mahalle_title"]);

                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        float ucret;
        void kargobilgi(string subeid, string gondericiadres, string gondericiad, string alanil, string aliciad, long alicitel, string kargodurumu, DateTime tarih,string odemeturu,float ucret)
        {
            try
            {
                baglanti.Open();
                string sorgu = "insert into kargobilgi(subeid,gondericiadres,gondericiad,alanil,aliciad,alicitel,kargodurumu,Tarih) " +
                    "values(@subeid,@gondericiadres,@gondericiad,@alanil,@aliciad,@alicitel,@kargodurumu,@tarih)";
                SqlCommand kontrol = new SqlCommand(sorgu, baglanti);
                kontrol.Parameters.AddWithValue("@subeid",subeid);
                kontrol.Parameters.AddWithValue("@gondericiadres", gondericiadres);
                kontrol.Parameters.AddWithValue("@gondericiad", gondericiad);
                kontrol.Parameters.AddWithValue("@alanil", alanil);
                kontrol.Parameters.AddWithValue("@aliciad", aliciad);
                kontrol.Parameters.AddWithValue("@alicitel", alicitel);
                kontrol.Parameters.AddWithValue("@kargodurumu", kargodurumu);
                kontrol.Parameters.AddWithValue("@Tarih", Tarih);

                kontrol.ExecuteNonQuery();

                baglanti.Close();


            }
            catch (Exception a)
            { MessageBox.Show(a.Message + "Hata"); }


        }
        void yenisifre(long tcnumara, string sifre)
        {
            try
            {
                baglanti.Open();
                string komut = "update personelbilgi set sifre=@sifre where tcnumara=@tcnumara";
                SqlCommand ekle = new SqlCommand(komut, baglanti);
                ekle.Parameters.AddWithValue("@tcnumara", tcnumara);
                ekle.Parameters.AddWithValue("@sifre", sifre);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Şifre Değişme İşleminiz Başarılı");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "Hata");

            }



        }
        void musteribilgi(long tcnumara, string ad, string mail, long tel, string il, string ilce, string mahalle, string adres)
        {
            if (Tcverikontrolekle(tcnumara))
            {
                MessageBox.Show("Bu TC kimlik numarasına sahip bir kayıt zaten mevcut.", "Hata");
                return; // Eğer TC mevcutsa, işlemi durdur
            }
            try
            {
                baglanti.Open();
                string sorgu = "insert into musteribilgi (tcnumara, ad, mail, tel, il, ilçe, mahalle, adres) " +
                               "values(@tcnumara, @ad, @mail, @tel, @il, @ilçe, @mahalle, @adres)";
                SqlCommand kontrol = new SqlCommand(sorgu, baglanti);

                // Parametreleri doğru şekilde ekle
                kontrol.Parameters.AddWithValue("@tcnumara", tcnumara);
                kontrol.Parameters.AddWithValue("@ad", ad ?? (object)DBNull.Value); // Null kontrolleri yaparak geçerli değeri ekle
                kontrol.Parameters.AddWithValue("@mail", mail ?? (object)DBNull.Value);
                kontrol.Parameters.AddWithValue("@tel", tel);
                kontrol.Parameters.AddWithValue("@il", il ?? (object)DBNull.Value);
                kontrol.Parameters.AddWithValue("@ilçe", ilce ?? (object)DBNull.Value);
                kontrol.Parameters.AddWithValue("@mahalle", mahalle ?? (object)DBNull.Value);
                kontrol.Parameters.AddWithValue("@adres", adres ?? (object)DBNull.Value);

                kontrol.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt İşleminiz Tamamlandı");
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message + " Hata");
            }
        }
        private bool Tcverikontrolekle(long tcnumara)
        {
            bool hata = false;
            string sorgu = "SELECT COUNT(*) FROM musteribilgi WHERE tcnumara = @tcnumara";
            try
            {
                using (SqlConnection conn = new SqlConnection(baglanti.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand kontrol = new SqlCommand(sorgu, conn)) // Use 'conn' instead of 'baglanti'
                    {
                        kontrol.Parameters.AddWithValue("@tcnumara", tcnumara);

                        // Execute the query and get the count of matching records
                        int count = (int)kontrol.ExecuteScalar();

                        if (count > 0)
                        {
                            hata = true; // Same TC exists, return true
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Provide more information on the error
                MessageBox.Show("HATA: " + ex.Message);
            }

            return hata;
        }
        void kargosorgu(long kargono)
        {
            string komut = "select * from kargobilgi where kargono=@kargono";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlCommand ekle = new SqlCommand(komut, conn))
                    {
                        // Parametreyi ekliyoruz
                        ekle.Parameters.AddWithValue("@kargono", kargono);

                        // SqlDataAdapter ile komut kullanarak DataTable'a veri çekme
                        using (SqlDataAdapter da = new SqlDataAdapter(ekle))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt); // DataTable'ı dolduruyoruz
                            dataGridView2.DataSource = dt; // DataGridView'i bağlama
                        }
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Hata");
            }
        }
        private bool mTCkontrolü(string TCtext)
        {
            string tcKimlik = texttcko.Text;
            if (tcKimlik.Length != 11)
            {
               return false;
            }
            // İlk hanesi 0 olamaz
            if (tcKimlik[0] == '0')
            {
                TChatasi.SetError(texttcko, "TC Kimlik numarasının ilk hanesi 0 olamaz.");
                return false;
            }

            // İlk 9 haneyi al
            int[] digits = tcKimlik.Take(9).Select(x => int.Parse(x.ToString())).ToArray();

            // 10. hane kontrolü (tek ve çift hanelerin kontrolü)
            int toplamTek = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int toplamCift = digits[1] + digits[3] + digits[5] + digits[7];
            int hane10 = ((toplamTek * 7) - toplamCift) % 10;

            if (hane10 != int.Parse(tcKimlik[9].ToString()))
            {
                TChatasi.SetError(texttcko, "10.Basamak Hatası.");
                return false;
            }

            // İlk 10 hanenin toplamının mod 10'u 11. haneyi vermeli
            int toplamIlk10 = digits.Sum() + hane10;
            int hane11 = toplamIlk10 % 10;

            if (hane11 != int.Parse(tcKimlik[10].ToString()))
            {
                TChatasi.SetError(texttcko, "11.Basamak Hatası.");
                return false;
            }

            // Eğer tüm kontroller geçildiyse, TC kimlik numarası geçerlidir ve hata temizlenir
            TChatasi.SetError(texttcko, "");
            return true;
        }
        private bool gonTCkontrolü(string TCtext)
        {
            string tcKimlik = tcgon.Text;
            if (tcKimlik.Length != 11)
            {
                return false;
            }
            // İlk hanesi 0 olamaz
            if (tcKimlik[0] == '0')
            {
                TChatasi.SetError(tcgon, "TC Kimlik numarasının ilk hanesi 0 olamaz.");
                return false;
            }

            // İlk 9 haneyi al
            int[] digits = tcKimlik.Take(9).Select(x => int.Parse(x.ToString())).ToArray();

            // 10. hane kontrolü (tek ve çift hanelerin kontrolü)
            int toplamTek = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int toplamCift = digits[1] + digits[3] + digits[5] + digits[7];
            int hane10 = ((toplamTek * 7) - toplamCift) % 10;

            if (hane10 != int.Parse(tcKimlik[9].ToString()))
            {
                TChatasi.SetError(tcgon, "10.Basamak Hatası.");
                return false;
            }

            // İlk 10 hanenin toplamının mod 10'u 11. haneyi vermeli
            int toplamIlk10 = digits.Sum() + hane10;
            int hane11 = toplamIlk10 % 10;

            if (hane11 != int.Parse(tcKimlik[10].ToString()))
            {   
                TChatasi.SetError(tcgon, "11.Basamak Hatası.");
                return false;
            }

            // Eğer tüm kontroller geçildiyse, TC kimlik numarası geçerlidir ve hata temizlenir
            TChatasi.SetError(tcgon, "");
            return true;
        }
        private bool alTCkontrolü(string TCtext)
        {
            string tcKimlik = tcal.Text;
            if (tcKimlik.Length != 11)
            {
                return false;
            }
            // İlk hanesi 0 olamaz
            if (tcKimlik[0] == '0')
            {
                TChatasi.SetError(tcal, "TC Kimlik numarasının ilk hanesi 0 olamaz.");
                return false;
            }

            // İlk 9 haneyi al
            int[] digits = tcKimlik.Take(9).Select(x => int.Parse(x.ToString())).ToArray();

            // 10. hane kontrolü (tek ve çift hanelerin kontrolü)
            int toplamTek = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int toplamCift = digits[1] + digits[3] + digits[5] + digits[7];
            int hane10 = ((toplamTek * 7) - toplamCift) % 10;

            if (hane10 != int.Parse(tcKimlik[9].ToString()))
            {
                TChatasi.SetError(tcal, "10.Basamak Hatası.");
                return false;
            }

            // İlk 10 hanenin toplamının mod 10'u 11. haneyi vermeli
            int toplamIlk10 = digits.Sum() + hane10;
            int hane11 = toplamIlk10 % 10;

            if (hane11 != int.Parse(tcKimlik[10].ToString()))
            {
                TChatasi.SetError(tcal, "11.Basamak Hatası.");
                return false;
            }

            // Eğer tüm kontroller geçildiyse, TC kimlik numarası geçerlidir ve hata temizlenir
            TChatasi.SetError(tcal, "");
            return true;
        }
        void musterigetir(long tcnumara)
        {
            try
            {
                using (var baglanti = new SqlConnection("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Kargo61;Integrated Security=True"))
                {
                    baglanti.Open();

                    // Hem TC hem de Vergi Numarası için sorgu
                    string komut = "SELECT * FROM musteribilgi WHERE tcnumara = @tcnumara";
                    // TextBox'ları ve ComboBox'ları temizle
                    textBox13.Clear();
                    textBox11.Clear();
                    textBox10.Clear();
                    textBox9.Clear();
                    cmbxilgon.Items.Clear();
                    cmbxilcegon.Items.Clear();
                    cmboxmahallegon.Items.Clear();

                    using (var cmd = new SqlCommand(komut, baglanti))
                    {
                        cmd.Parameters.AddWithValue("@tcnumara", tcnumara);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                               if(tcgon.Text=="")
                                {
                                    // Gelen verileri doldur
                                    textBox1.Text = dr["ad"].ToString();
                                    textBox11.Text = dr["tel"].ToString();
                                    textBox10.Text = dr["mail"].ToString();
                                    textBox9.Text = dr["adres"].ToString();

                                    // ComboBox seçimleri
                                    string il = dr["il"].ToString();
                                    string ilce = dr["ilçe"].ToString();
                                    string mah = dr["mahalle"].ToString();

                                    ilgetirgon();
                                    cmbxilgon.SelectedItem = il;

                                    IlceGetirgon();
                                    cmbxilcegon.SelectedItem = ilce;

                                    mahallegetirgon();
                                    cmboxmahallegon.SelectedItem = mah;
                                }
                               else
                                {
                                    // Gelen verileri doldur
                                    textBox13.Text = dr["ad"].ToString();
                                    textBox11.Text = dr["tel"].ToString();
                                    textBox10.Text = dr["mail"].ToString();
                                    textBox9.Text = dr["adres"].ToString();

                                    // ComboBox seçimleri
                                    string il = dr["il"].ToString();
                                    string ilce = dr["ilçe"].ToString();
                                    string mah = dr["mahalle"].ToString();

                                    ilgetirgon();
                                    cmbxilgon.SelectedItem = il;

                                    IlceGetirgon();
                                    cmbxilcegon.SelectedItem = ilce;

                                    mahallegetirgon();
                                    cmboxmahallegon.SelectedItem = mah;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kayıt bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
   
        private void button11_Click(object sender, EventArgs e)
        {


            if (textBox17.Text != Form1.sifreal)
            {
                MessageBox.Show("Şifreyi Doğru GirdiğiniZden emin olun");
                return;
            }
            else if (textBox20.Text != deger)
            {
                MessageBox.Show("Güvenlik Kod Hatalı Girilmiştir");
                return;
            }
            else if (textBox19.Text != textBox18.Text)
            {
                MessageBox.Show("Lütfen Yeni Şifre Birbiriyle Eşleşmiyor");
                return;
            }
            else if (textBox19.Text == textBox17.Text)
            {
                MessageBox.Show("Eski Şifrenizle Yeni Şifreniz Aynı Olamaz");
                return;
            }
            else
            {
                yenisifre(Form1.TCform1, textBox19.Text);

            }
            textBox17.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox20.Clear();
        }
        Random guvenlik = new Random();
        String deger;
        int sigorta, hizli, zarf, degerli, gida, tabanucret,birim;
        void ucretgetir()
        {
            try
            {
                using (var baglanti = new SqlConnection("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Kargo61;Integrated Security=True"))
                {
                    baglanti.Open();
                    string komut = "SELECT * FROM ucretlendirme";
                    using (var cmd = new SqlCommand(komut, baglanti))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sigorta = int.Parse(dr["sigorta"].ToString());
                            hizli = int.Parse(dr["hızlıteslimat"].ToString());
                            zarf = int.Parse(dr["zarf"].ToString());
                            degerli = int.Parse(dr["degerliesya"].ToString());
                           gida = int.Parse(dr["gida"].ToString());
                            tabanucret = int.Parse(dr["tabanucret"].ToString());
                            birim = int.Parse(dr["birim"].ToString());
                        }
                    }
                }
                baglanti.Close();

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gbUcret.Visible = false;
            panel6.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            button4.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
            string kullaniciAdi = Form1.adsoyad;

            personelad.Text = kullaniciAdi;
            personelad.Font = new Font("Arial", 34, FontStyle.Bold);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox17.PasswordChar = '\0';
                textBox18.PasswordChar = '\0';
                textBox19.PasswordChar = '\0';
            }
            else { textBox17.PasswordChar = '*'; textBox18.PasswordChar = '*'; textBox19.PasswordChar = '*'; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gbUcret.Visible = true;
            panel6.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = true;
            groupBox1.Visible = true;
            button4.Visible = true;
            panel2.Visible = false;
            textBox1.Clear();
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox10.Clear();
            textBox11.Clear();
            cmbxilgon.Items.Clear();
            cmbxilcegon.Items.Clear();
            cmboxmahallegon.Items.Clear();
            cmbxilalici.Items.Clear();
            cmbxilcealici.Items.Clear();
            cmboxmahallealici.Items.Clear();
            tcgon.Clear();
            tcal.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox14.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s=new Form1();
            s.ShowDialog();
        }
        string alil, gonil, kargodur, adi, gonadi;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox8.Enabled = true;
                tcgon.Enabled = false;
                textBox13.Enabled = true;
                textBox11.Enabled = true;
                textBox10.Enabled = true;
                cmbxilgon.Enabled = true;
                cmboxmahallegon.Enabled = true;
                cmbxilcegon.Enabled = true;
                textBox9.Enabled = true;
                tcgon.Visible = false;
                label20.Visible = false;
                label11.Visible = true;
                textBox8.Visible = true;
                label19.Visible = false;
                textBox13.Visible = false;
                textBox1.Visible = true;
                label22.Visible = true;
            }
        }

        private void radiobirey_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobirey.Checked)

            {
                tcal.Visible = true;
                label11.Visible = true;
                textBox7.Visible = false;
                label10.Visible = false;
                textBox7.Enabled = false;
                tcal.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                cmbxilalici.Enabled = true;
                cmbxilcealici.Enabled = true;
                cmboxmahallealici.Enabled = true;
                textBox6.Enabled = true;
                textBox14.Visible = false;
                label23.Visible = false;
                label3.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                label1.Visible = true;
            }
        }

        private void radioKurum_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKurum.Checked)
            {
                tcal.Visible = false;
                label1.Visible = false;
                textBox7.Visible = true;
                label10.Visible = true;
                textBox7.Enabled = true;
                tcal.Enabled = false;
                textBox3.Enabled = false;
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                cmbxilalici.Enabled = true;
                cmbxilcealici.Enabled = true;
                cmboxmahallealici.Enabled = true;
                textBox6.Enabled = true;
                textBox14.Visible = true;
                label23.Visible = true;
                label3.Visible = false;
                label2.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void tcgon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // Eğer basılan tuş 0 ise ve TextBox boşsa, girişi engelliyoruz
            if (e.KeyChar == '0' && tcgon.Text.Length == 0 && tcal.Text.Length==0 && texttcko.Text.Length==0)
            {
                e.Handled = true;
            }
            if (tcgon.Text.Length == 11 && !char.IsControl(e.KeyChar) && tcal.Text.Length==11 && texttcko.Text.Length==11)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13) // Enter tuşu
            {
                string numara = !string.IsNullOrEmpty(tcgon.Text) ? tcgon.Text : textBox8.Text;

                if (!string.IsNullOrEmpty(numara))
                {
                    musterigetir(long.Parse(numara)); // TC veya Vergi Numarasını gönder
                }
                else
                {
                    MessageBox.Show("Geçersiz TC veya Vergi numarası!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // Eğer basılan tuş 0 ise ve TextBox boşsa, girişi engelliyoruz
            if (e.KeyChar == '0' && textBox11.Text.Length == 0 && textBox4.Text.Length==0 && textBox24.Text.Length==0)
            {
                e.Handled = true;
            }
            if (textBox11.Text.Length == 10 && !char.IsControl(e.KeyChar) && textBox4.Text.Length==10 && textBox24.Text.Length==10)
            {
                e.Handled = true;
            }
        }

        private void cmbxilalici_SelectedIndexChanged(object sender, EventArgs e)
        {          
            cmbxilcealici.Text = "";
            cmbxilcealici.Items.Clear();
            IlceGetiralici();           
        }

        private void cmbxilcealici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmboxmahallealici.Text = "";
            cmboxmahallealici.Items.Clear();

            mahallegetiralici();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                label33.Visible = true;
                label34.Visible = true;
                texttcko.Visible = true;
                texttcko.Enabled = true;
                textBox26.Enabled = true;
                textBox26.Visible = true;
                textBox16.Visible = false;
                textBox15.Visible = false;
                label21.Visible = false;
                label24.Visible = false;
                textBox16.Enabled = false;
                textBox15.Enabled = false;
                textBox21.Enabled = true;
                textBox24.Enabled = true;
                textBox23.Enabled = true;
                mcmbxmah.Enabled = true;
                mcmbxilce.Enabled = true;
                mcmbxil.Enabled = true;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label33.Visible = false;
                label34.Visible = false;
                texttcko.Visible = false;
                texttcko.Enabled=false;
                textBox26.Enabled = false;
                textBox26.Visible = false;

                textBox16.Visible = true;
            textBox15.Visible = true;
            label21.Visible = true;
            label24.Visible = true;
            textBox16.Enabled = true;
            textBox15.Enabled = true;
            textBox21.Enabled = true;
            textBox24.Enabled = true;
            textBox23.Enabled = true;
            mcmbxmah.Enabled = true;
            mcmbxilce.Enabled = true;
            mcmbxil.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            groupBox3.Visible = true;
            button7.Visible = true;
            groupBox2.Visible = false;
            groupBox1.Visible =false;
            button4.Visible = false;
            panel2.Visible = false;
            gbUcret.Visible = false;
        }

        private void mcmbxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            milcegeti();
        }

        private void mcmbxilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            mmahgetir();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            // E-posta doğrulama deseni
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Ad alanlarının kontrolü
            string ad = string.IsNullOrEmpty(textBox15.Text) ? textBox26.Text : textBox15.Text;
            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Lütfen ad kısmı boş bırakmayınız.");
                return;
            }

            // E-posta adresi kontrolü
            string mail = textBox23.Text;
            if (!Regex.IsMatch(mail, emailPattern))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi girin.");
                return;
            }

            try
            {
                // Telefon numarasını kontrol et
                string tel = textBox24.Text;
                if (tel.Length != 10)
                {
                    MessageBox.Show("Telefon numarasını kontrol edin.");
                    return;
                }

                // ComboBox'lardan seçilen değerleri al
                string il = mcmbxil.SelectedItem?.ToString();
                string ilce = mcmbxilce.SelectedItem?.ToString();
                string mah = mcmbxmah.SelectedItem?.ToString();
                string adres = textBox21.Text;

                // İl, ilçe ve mahalle seçimi yapılmamışsa uyarı ver
                if (string.IsNullOrEmpty(il) || string.IsNullOrEmpty(ilce) || string.IsNullOrEmpty(mah))
                {
                    MessageBox.Show("Lütfen il, ilçe ve mahalle seçiniz.");
                    return;
                }
                long tc;
                if (texttcko.Text=="")
                {
                    tc = long.Parse(textBox16.Text);
                }
                else {  tc = long.Parse(texttcko.Text); }

                if (!long.TryParse(tel, out long tel1))
                {
                    MessageBox.Show("Geçerli bir telefon numarası girin.");
                    return;
                }

                // Musteribilgi fonksiyonunu çağır
                musteribilgi(tc, ad, mail, tel1, il, ilce, mah, adres);

                // Veriler kaydedildikten sonra alanları temizle
                ResetFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        // Veritabanı işlemleri sonrası form alanlarını temizlemek için yardımcı metod
        private void ResetFields()
        {
            texttcko.Clear();
            textBox26.Clear();
            textBox16.Clear();
            textBox15.Clear();
            textBox21.Clear();
            textBox24.Clear();
            textBox23.Clear();
            mcmbxmah.Items.Clear();
            mcmbxilce.Items.Clear();
            mcmbxil.Items.Clear();
        }


        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void texttcko_TextChanged(object sender, EventArgs e)
        {
            string tck = texttcko.Text;
            if (mTCkontrolü(tck))
            { TChatasi.Clear(); }
            else if (tck == "")
            { TChatasi.Clear(); }
        }

        private void texttcko_Leave(object sender, EventArgs e)
        {
            string kont = texttcko.Text;
            if (kont.Length != 11)
            { TChatasi.SetError(texttcko, "11 Hane Olmak Zorunda"); return; }
            else if (kont == "")
            { TChatasi.SetError(texttcko, "Boş Bırakılamaz."); return; }
            else
            { TChatasi.Clear(); }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            milgetir();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            groupBox3.Visible = false;
        }

        private void tcgon_Enter(object sender, EventArgs e)
        {
        }

        private void tcgon_TextChanged(object sender, EventArgs e)
        {
            string tck = tcgon.Text;
            if (gonTCkontrolü(tck))
            { TChatasi.Clear(); }
            else if (tck == "")
            { TChatasi.Clear(); }
        }
        string odemetr;
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            { odemetr = "alıcı ödeme"; txtAgirlik.Enabled = true; txtBoy.Enabled = true;txtEn.Enabled = true;txtYukseklik.Enabled = true; }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            { odemetr = "gönderici ödeme"; txtAgirlik.Enabled = true; txtBoy.Enabled = true; txtEn.Enabled = true; txtYukseklik.Enabled = true; }
        }

        private void tcgon_Leave(object sender, EventArgs e)
        {
            string kont = tcgon.Text;
            if (kont.Length != 11)
            { TChatasi.SetError(tcgon, "11 Hane Olmak Zorunda"); return; }
            else if (kont == "")
            { TChatasi.SetError(tcgon, "Boş Bırakılamaz."); return; }
            else
            { TChatasi.Clear(); }
        }

        private void tcal_Leave(object sender, EventArgs e)
        {
            string kont = tcal.Text;
            if (kont.Length != 11)
            { TChatasi.SetError(tcal, "11 Hane Olmak Zorunda"); return; }
            else if (kont == "")
            { TChatasi.SetError(tcal, "Boş Bırakılamaz."); return; }
            else
            { TChatasi.Clear(); }
        }

        private void tcal_TextChanged(object sender, EventArgs e)
        {
            string tck = tcal.Text;
            if (alTCkontrolü(tck))
            { TChatasi.Clear(); }
            else if (tck == "")
            { TChatasi.Clear(); }
        }

        private void gbUcret_Enter(object sender, EventArgs e)
        {

        }

        private void txtEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ucrethesap_Click(object sender, EventArgs e)
        {
            ucretgetir();
            float tophes;
            if (checkBox6.Checked)
            {
                tophes = zarf;
            }
          
                int en = int.Parse(txtEn.Text);
                int boy = int.Parse(txtBoy.Text);
                int yukseklik = int.Parse(txtYukseklik.Text);
                float desi = (en * boy * yukseklik) / 3000;
                txtDesi.Text = desi.ToString();
                int agırlık = int.Parse(txtAgirlik.Text);
                if (desi < agırlık)
                {
                    tophes = (agırlık * birim) + (1*2 * tabanucret);
                }
                else
                {
                    tophes = (desi * birim) + (1*2 * tabanucret);
                }

                if (checkBox1.Checked)
                {
                    tophes += sigorta;
                }
                if (checkBox5.Checked)
                {
                    tophes += gida;
                }
                if (checkBox3.Checked)
                {
                    tophes += hizli;
                }
                if (checkBox4.Checked)
                {
                    tophes += degerli;
                }

                ucret = tophes;
                lblTutar.Text = tophes.ToString();
            

        }

        private void button8_Click(object sender, EventArgs e)
        {textBox12.Clear();
            panel6.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            button4.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            gbUcret.Visible = false;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter tuşu
            {
                string kargo = textBox12.Text;
                kargosorgu(long.Parse(kargo));
            }
        }

        private void cmbxilcegon_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmboxmahallegon.Text = "";
            cmboxmahallegon.Items.Clear();

            mahallegetirgon();
        }

        private void cmbxilgon_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxilcegon.Text = "";
            cmbxilcegon.Items.Clear();
           
            IlceGetirgon();
            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            ilgetirgon();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            ilgetiralici();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox8.Enabled = false;
                tcgon.Enabled = true;
                textBox13.Enabled = true;
                textBox11.Enabled = true;
                textBox10.Enabled = true;
                cmbxilgon.Enabled = true;
                cmboxmahallegon.Enabled = true;
                cmbxilcegon.Enabled = true;
                textBox9.Enabled = true;
                label11.Visible = false;
                textBox8.Visible = false;
                tcgon.Visible = true;
                label20.Visible = true;
                label19.Visible = true;
                textBox13.Visible = true;
                textBox1.Visible = false;
                label22.Visible = false;
            }
        }

        long tele;
        DateTime Tarih = DateTime.Now;
        private void button4_Click(object sender, EventArgs e)
        {
            // gonil ve alil değerlerini ComboBox'lardan alıyoruz
            // İl kontrolü
            if (cmbxilgon.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir il seçiniz.", "Hata");
                return;
            }
                            
            else { gondericiil = cmbxilgon.SelectedItem.ToString(); }

            // İlçe kontrolü
            if (cmbxilcegon.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ilçe seçiniz.", "Hata");
                return;
            }
            else { gonilce = cmbxilcegon.SelectedItem.ToString(); }

            // Mahalle kontrolü
            if (cmboxmahallegon.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir mahalle seçiniz.", "Hata");
                return;
            }
            else { gonmah = cmboxmahallegon.SelectedItem.ToString(); }

            alicil=cmbxilalici.SelectedItem.ToString();
            alicilce = cmbxilcealici.SelectedItem.ToString();
            almah = cmboxmahallealici.SelectedItem.ToString();
            // Değerleri birleştir
            string gonil = gondericiil + " " +
                           gonilce + " " +
                           gonmah + " " +
                           textBox9.Text;
            alil = alicil + " " +
                alicilce + " " +
                almah+" "+
                textBox6.Text ; // Alıcı il ComboBox'u

            kargodur = "Gönderiniz Alındı";

            if (textBox2.Text == "")
            {
                adi = textBox14.Text;
            }
            else { adi = textBox2.Text +" "+ textBox13.Text; }

            if (textBox13.Text == "")
            {
                gonadi = textBox1.Text;
            }
            else { gonadi = textBox13.Text ; }
            TChatasi.Clear();
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                TChatasi.SetError(textBox4, "Telefon Numarasını Boş Bırakılamaz");
                return;
            }

            else { tele = long.Parse(textBox4.Text); }

            MessageBox.Show("Kargonuz Oluşturuldu");
            string subeid=Form1.subeid;
            kargobilgi(subeid, gonil, gonadi, alil, adi, tele, kargodur, Tarih, odemetr, ucret);

            textBox1.Clear();
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox10.Clear();
            textBox11.Clear();
            cmbxilalici.Items.Clear();
            cmbxilcealici.Items.Clear();
            cmboxmahallealici.Items.Clear();
            tcgon.Clear();
            tcal.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox14.Clear();
            textBox9.Clear();
            cmbxilgon.Items.Clear();
            cmbxilcegon.Items.Clear();
            cmboxmahallegon.Items.Clear();
        }
    }
}
