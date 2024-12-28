using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace kargotest1
{
    public partial class YöneticiEkran : Form
    {
        public YöneticiEkran()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel3.Visible = false;
            panel1.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }
        void personelek(long TcNumara, string Ad, string Soyad, string mail, string tel, string pozisyon, string Sifre,string subeid)
        {
            if (Tcverikontrolekle(TcNumara))
            {
                MessageBox.Show("Bu TC kimlik numarasına sahip bir kayıt zaten mevcut.", "Hata");
                return; // Eğer TC mevcutsa, işlemi durdur
            }
            string kayit = "INSERT INTO personelbilgi(tcnumara,ad,soyad,mail,tel,pozisyon,sifre,subeid) VALUES(@TcNumara,@Ad,@Soyad,@mail,@tel,@pozisyon,@Sifre,@subeid)";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlCommand ekle = new SqlCommand(kayit, conn))
                    {
                        ekle.Parameters.AddWithValue("@tcnumara", TcNumara);
                        ekle.Parameters.AddWithValue("@ad", Ad);
                        ekle.Parameters.AddWithValue("@soyad", Soyad);
                        ekle.Parameters.AddWithValue("@mail", mail);
                        ekle.Parameters.AddWithValue("@tel", tel);
                        ekle.Parameters.AddWithValue("@pozisyon", pozisyon);
                        ekle.Parameters.AddWithValue("@sifre", Sifre);
                        ekle.Parameters.AddWithValue("@subeid",subeid);
                        ekle.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kayıt İşleminiz Tamamlandı");
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Hata");
            }
        }
        
        private bool Tcverikontrolsil(long tcnumara)
        {
            bool hata = false;

            try
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True")) // Bağlantı dizisini uygun şekilde değiştirin.
                {
                    baglanti.Open();
                    string sorgu = "SELECT COUNT(*) FROM personelbilgi WHERE tcnumara = @tcnumara";

                    using (SqlCommand kontrol = new SqlCommand(sorgu, baglanti))
                    {
                        kontrol.Parameters.Add("@tcnumara", SqlDbType.BigInt).Value = tcnumara;

                        // Veritabanında eşleşen TC var mı kontrol edelim
                        int count = (int)kontrol.ExecuteScalar();
                        if (count != 1)
                        {
                            hata = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " HATA");
            }

            return hata;
        }

        private bool Tcverikontrolekle(long tcnumara)
        {
            bool hata = false;
            string sorgu = "SELECT COUNT(*) FROM personelbilgi WHERE tcnumara = @tcnumara";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Kargo61;Integrated Security=True"))
                {
                    conn.Open();
                    using (SqlCommand kontrol = new SqlCommand(sorgu, conn))
                    {
                        kontrol.Parameters.Add("@tcnumara", SqlDbType.BigInt).Value = tcnumara;
                        int count = (int)kontrol.ExecuteScalar();
                        if (count > 0)
                        {
                            hata = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " HATA");
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
        private DataTable yazdirilacakVeri = new DataTable();
        private PrintDocument printDocument = new PrintDocument();

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Font tanımlama
                Font font = new Font("Arial", 10);
                float y = e.MarginBounds.Top; // Başlangıç yüksekliği
                float x = e.MarginBounds.Left; // Başlangıç genişliği

                // Tablo başlıklarını yazdır
                foreach (DataColumn column in yazdirilacakVeri.Columns)
                {
                    e.Graphics.DrawString(column.ColumnName, font, Brushes.Black, x, y); // Başlık yazdır
                    x += 150; // Sütunlar arası mesafe
                }
                y += 30; // Bir satır aşağıya geç

                // Tabloyu veri ile doldur
                foreach (DataRow row in yazdirilacakVeri.Rows)
                {
                    x = e.MarginBounds.Left; // Her yeni satıra başlarken sola dön
                    foreach (var cell in row.ItemArray)
                    {
                        e.Graphics.DrawString(cell.ToString(), font, Brushes.Black, x, y); // Hücreyi yazdır
                        x += 150; // Sütunlar arası mesafe
                    }
                    y += 30; // Bir satır aşağıya geç
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }
        private void YazdirRapor()
        {
            try
            {
                // PrintDocument için PrintPage olayını bağla
                printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

                // Yazdırma önizleme penceresi aç
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument;
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }
        void raporgunluk()
        {
            string sorgu = "SELECT * FROM kargobilgi WHERE tarih >= DATEADD(DAY, -1, GETDATE())";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sorgu, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // DataGridView'i bağlama
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Hata");
            }

        }
        void raporhafta()
        {
            string sorgu = "SELECT * FROM kargobilgi WHERE tarih >= DATEADD(DAY, -7, GETDATE())";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sorgu, conn))
                    {  
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // DataGridView'i bağlama
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Hata");
            }

        }
        void raporaylik()
        {
            string sorgu = "SELECT * FROM kargobilgi WHERE tarih >= DATEADD(DAY, -30, GETDATE())";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sorgu, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // DataGridView'i bağlama
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Hata");
            }

        }
        void rapor3aylik()
        {
            string sorgu = "SELECT * FROM kargobilgi WHERE tarih >= DATEADD(DAY, -90, GETDATE())";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sorgu, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // DataGridView'i bağlama
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Hata");
            }

        }
        void personelsil(long tcnumara)
        {
            if (Tcverikontrolsil(tcnumara))
            {
                MessageBox.Show("Bu TC Kimliğe ait bir Personel Bulunmamaktadır...");
                return;
            }

            string komut = "DELETE FROM personelbilgi WHERE tcnumara = @tcnumara";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlCommand kontrol = new SqlCommand(komut, conn))
                    {
                        kontrol.Parameters.AddWithValue("@tcnumara", tcnumara);
                        kontrol.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Silme İşleminiz Tamamlandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "HATA");
            }
        }

        void yenisifre(long tcnumara, string sifre)
        {
            try
            {
              string komut = "update personelbilgi set sifre=@sifre where tcnumara=@tcnumara";

                using (SqlConnection conn = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True"))
                {
                    conn.Open();
                    using (SqlCommand ekle = new SqlCommand(komut, conn))
                    {
                        ekle.Parameters.AddWithValue("@tcnumara", tcnumara);
                        ekle.Parameters.AddWithValue("@sifre", sifre);
                        ekle.ExecuteNonQuery();
                                              
                    }
                }
                MessageBox.Show("Şifre Değişme İşleminiz Başarılı");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "Hata");

            }



        }
        private bool TCkontrolüperekle(string TCtext)
        {
            string tcKimlik = txt_GonderenTCno.Text;

            // TC kimlik numarası 11 haneli olmalı ve sadece sayılardan oluşmalı
            if (tcKimlik.Length != 11)
            {
                 return false;
            }

            // İlk hanesi 0 olamaz
            if (tcKimlik[0] == '0')
            {
                TChatasi.SetError(txt_GonderenTCno, "TC Kimlik numarasının ilk hanesi 0 olamaz.");
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
                TChatasi.SetError(txt_GonderenTCno, "10.Basamak Hatası.");
                return false;
            }

            // İlk 10 hanenin toplamının mod 10'u 11. haneyi vermeli
            int toplamIlk10 = digits.Sum() + hane10;
            int hane11 = toplamIlk10 % 10;

            if (hane11 != int.Parse(tcKimlik[10].ToString()))
            {
                TChatasi.SetError(txt_GonderenTCno, "11.Basamak Hatası.");
                return false;
            }

            // Eğer tüm kontroller geçildiyse, TC kimlik numarası geçerlidir ve hata temizlenir
            TChatasi.SetError(txt_GonderenTCno, "");
            return true;
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
        private bool TCkontrolüpersilme(string TCtext)
        {
            string tcKimlik = textBox15.Text;

            // İlk hanesi 0 olamaz
            if (tcKimlik[0] == '0')
            {
                TChatasi.SetError(textBox15, "TC Kimlik numarasının ilk hanesi 0 olamaz.");
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
                TChatasi.SetError(textBox15, "10.Basamak Hatası.");
                return false;
            }

            // İlk 10 hanenin toplamının mod 10'u 11. haneyi vermeli
            int toplamIlk10 = digits.Sum() + hane10;
            int hane11 = toplamIlk10 % 10;

            if (hane11 != int.Parse(tcKimlik[10].ToString()))
            {
                TChatasi.SetError(textBox15, "11.Basamak Hatası.");
                return false;
            }

            // Eğer tüm kontroller geçildiyse, TC kimlik numarası geçerlidir ve hata temizlenir
            TChatasi.SetError(textBox15, "");
            return true;
        }
        Random guvenlik=new Random();
        String deger;
        private void button1_Click(object sender, EventArgs e)
        {
            textsil();
            panel6.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
            string kullaniciAdi = Form1.adsoyad;
            panel5.Visible = false;
            personelad.Text = kullaniciAdi;
            personelad.Font = new Font("Arial", 34, FontStyle.Bold);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            int guvenlikKodu = guvenlik.Next(10000, 100000);
            deger = guvenlikKodu.ToString();
            label41.Text = deger;          
            textBox17.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox20.Clear();
        }

        private void YöneticiEkran_Load(object sender, EventArgs e)
        {   }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaEkran anaEkran = new AnaEkran();
            anaEkran.Show();
            textsil();
        }
       
        long tckim;
        private void button9_Click(object sender, EventArgs e)
        {
            tckim = long.Parse(textBox15.Text);
            if (!TCkontrolüpersilme(tckim.ToString()))
            {
                return;
            }


            // Kullanıcının girdiği güvenlik kodu
            string guvenkodtext = textBox16.Text;

            // Kullanıcının T.C. kimlik numarasını alalım
            if (tckim.ToString() == " ")
            {
                TChatasi.SetError(textBox15, "Boş Bırakmayınız");
            }

            // Girilen güvenlik kodunu rastgele üretilen güvenlik kodu ile karşılaştıralım
            if (guvenkodtext == deger)
            {
                personelsil(tckim);  // T.C. kimlik numarasına göre silme işlemi yapılır
                textBox16.Clear();
                textBox15.Clear();
            }
            else
            {
                MessageBox.Show("Güvenlik Kod Hatası");  // Güvenlik kodu hatalı ise mesaj gösterilir
                int kod=guvenlik.Next(10000, 100000);
                deger = kod.ToString();
                label41.Text = deger;
                textBox16.Clear();
                return;
            }


        }
      
        string ad, soyad, mail, tel, pozisyon, sifre;

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // Eğer basılan tuş 0 ise ve TextBox boşsa, girişi engelliyoruz
            if (e.KeyChar == '0' && textBoxtel.Text.Length == 0 )
            {
                e.Handled = true;
            }
            if (textBoxtel.Text.Length == 10 && !char.IsControl(e.KeyChar)&& textBox1.Text.Length==12 )
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textsil();
            panel6.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
            panel3.Visible = true;
            panel2.Visible=false;
                               // Eğer gizli ise görünür yap
            textBoxad.Clear();
            textBoxsoyad.Clear();
            textBoxmail.Clear();
            textBoxtel.Clear();
            comboBoxpozisyon.Items.Clear();
            txtsifre.Clear();
            textBox16.Clear();
            textBox15.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textsil();
            int guvenlikKodu = guvenlik.Next(10000, 100000);
            deger = guvenlikKodu.ToString();
            label37.Text = guvenlikKodu.ToString();           // Label'a bu sayıyı yaz
            label37.Visible = true;
            panel6.Visible = false;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible=false;
            panel5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textsil();
            panel6.Visible = false;
            panel1.Visible=false;
            panel2.Visible=false;
            panel3.Visible=false;
            panel5.Visible=true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textsil();
            panel6.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked)
            {
                rapor3aylik();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                raporhafta();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                raporaylik();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            { raporgunluk();}
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter tuşu
            {
                string kargo=textBox1.Text;
                kargosorgu(long.Parse(kargo));               
            }
        }

        private void txt_GonderenTCno_Leave(object sender, EventArgs e)
        {
            string kont = txt_GonderenTCno.Text;
            if (kont.Length != 11)
            { TChatasi.SetError(txt_GonderenTCno, "11 Hane Olmak Zorunda"); return; }
            else if (kont == "")
            { TChatasi.SetError(txt_GonderenTCno, "Boş Bırakılamaz."); return; }
            else
            { TChatasi.Clear(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textsil();
            this.Close();
        }

        private void btnyazdir_Click(object sender, EventArgs e)
        {
            try
            {
                // Yazdırılacak veri seçilen rapora göre alınır
                if (radioButton1.Checked) // Günlük rapor
                {
                    raporgunluk();
                }
                else if (radioButton2.Checked) // Haftalık rapor
                {
                    raporhafta();
                }
                else if (radioButton3.Checked) // Aylık rapor
                {
                    raporaylik();
                }
                else if (radioButton4.Checked) // 3 Aylık rapor
                {
                    rapor3aylik();
                }

                // DataGridView'deki veriyi al
                yazdirilacakVeri = (DataTable)dataGridView1.DataSource;

                // Yazdırma fonksiyonunu çağır
                YazdirRapor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }

        private void txt_GonderenTCno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // Eğer basılan tuş 0 ise ve TextBox boşsa, girişi engelliyoruz
            if (e.KeyChar == '0' && txt_GonderenTCno.Text.Length == 0)
            {
                e.Handled = true;
            }
            if(txt_GonderenTCno.Text.Length==11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       
        private void txt_GonderenTCno_TextChanged(object sender, EventArgs e)
        {
            string tc = txt_GonderenTCno.Text;
            if (TCkontrolüperekle(tc))
            {
                TChatasi.Clear();
            }
            else if (tc == "")
            {
                TChatasi.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtsifre.PasswordChar = '\0';
            }
            else { txtsifre.PasswordChar = '*'; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string tck = txt_GonderenTCno.Text;
            if (!TCkontrolüperekle(tck))
            {
                return;
            }

            string ad = textBoxad.Text;

            if (string.IsNullOrWhiteSpace(textBoxad.Text))
            {
                MessageBox.Show("Ad alanı boş bırakılamaz.");
                return;
            }
            string soyad = textBoxsoyad.Text;


            if (string.IsNullOrWhiteSpace(textBoxsoyad.Text))
            {
                MessageBox.Show("Soyad alanı boş bırakılamaz.");
                return;
            }
            string email = textBoxmail.Text;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi girin.");
                return;
            }

            try
            {
                ad = textBoxad.Text;
                soyad = textBoxsoyad.Text;
                mail = textBoxmail.Text;
                tel = textBoxtel.Text;
                pozisyon = comboBoxpozisyon.Text;
                sifre = txtsifre.Text;

                if (tel[0] != 5 && tel.Length != 10)
                {
                    MessageBox.Show("Telefon Numarasını Kontrol edin");
                }
                //hata yok ise
                else
                {
                    string subeid=Form1.subeid;
                    long tc = long.Parse(txt_GonderenTCno.Text);
                    personelek(tc, ad, soyad, mail, tel, pozisyon, sifre,subeid);
                    textBoxad.Clear();
                    textBoxsoyad.Clear();
                    textBoxmail.Clear();
                    textBoxtel.Clear();
                    comboBoxpozisyon.Items.Clear();
                    txtsifre.Clear();
                    txt_GonderenTCno.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void textsil()
        {
            textBox1.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBoxad.Clear();
            textBoxmail.Clear();
            textBoxtel.Clear();
            
        }

    }
}
