using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargotest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source = RıDVAN\\SQLEXPRESS; Initial Catalog = Kargo61; Integrated Security = True");
        public static long TCform1;
        public static string sifreal;
        public static string adsoyad;
        public static string pozs;
        public static string subeid;
        void giriskontol(string sifre, long tcnumara)
        {
            try
            {
                baglantı.Open();
                string sorgu = "select*from personelbilgi where @tcnumara=tcnumara and @sifre=sifre";
                SqlCommand kontrol = new SqlCommand(sorgu, baglantı);
                kontrol.Parameters.AddWithValue("@tcnumara", tcnumara);
                kontrol.Parameters.AddWithValue("@sifre", sifre);
                kontrol.ExecuteNonQuery();
                SqlDataReader dr = kontrol.ExecuteReader();

                if (dr.Read())
                {
                    adsoyad = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                    sifreal = sifre;
                    TCform1 = tcnumara;
                    pozs = dr["pozisyon"].ToString();
                    subeid = dr["subeid"].ToString();
                    if(pozs== "Müdür     ")
                    {
                        YöneticiEkran yon = new YöneticiEkran();
                        yon.Show();
                        this.Hide();

                    }
                    else
                    {
                        AnaEkran ana = new AnaEkran();
                        ana.Show();
                        this.Hide();
                    }
                   
                }
                else
                { MessageBox.Show("Bilgileriniz Bulunmamaktadır"); }

                baglantı.Close();
            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message, "Hata");
            }


        }
        private bool TCkontrolü(string TCtext)
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
                TCHatasi.SetError(txt_GonderenTCno, "TC Kimlik numarasının ilk hanesi 0 olamaz.");
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
                TCHatasi.SetError(txt_GonderenTCno, "10.Basamak Hatası.");
                return false;
            }

            // İlk 10 hanenin toplamının mod 10'u 11. haneyi vermeli
            int toplamIlk10 = digits.Sum() + hane10;
            int hane11 = toplamIlk10 % 10;

            if (hane11 != int.Parse(tcKimlik[10].ToString()))
            {
                TCHatasi.SetError(txt_GonderenTCno, "11.Basamak Hatası.");
                return false;
            }

            // Eğer tüm kontroller geçildiyse, TC kimlik numarası geçerlidir ve hata temizlenir
            TCHatasi.SetError(txt_GonderenTCno, "");
            return true;
        }

        private void txt_GonderenTCno_TextChanged(object sender, EventArgs e)
        {
            string tck=txt_GonderenTCno.Text;
            if(TCkontrolü(tck))
            {  TCHatasi.Clear(); }
            else if (tck == "")
            { TCHatasi.Clear(); }

        }
        string sif;
        long tc;
        private void btngiris_Click(object sender, EventArgs e)
        {
            try
            {
                sif = sifre.Text;
                tc = long.Parse(txt_GonderenTCno.Text);

                giriskontol(sif, tc);
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "giriş bilgileriniz hatalı");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sifre.PasswordChar = '\0';
            }
            else { sifre.PasswordChar = '*'; }
        }

        private void txt_GonderenTCno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // Eğer basılan tuş 0 ise ve TextBox boşsa, girişi engelliyoruz
            if (e.KeyChar == '0' && txt_GonderenTCno.Text.Length == 0)
            {
                e.Handled = true;
            }
            if (txt_GonderenTCno.Text.Length == 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_GonderenTCno_Leave(object sender, EventArgs e)
        {
            string kont = txt_GonderenTCno.Text;
            if(kont.Length!=11)
            { TCHatasi.SetError(txt_GonderenTCno,"11 Hane Olmak Zorunda");return; }
            else if(kont=="")
            { TCHatasi.SetError(txt_GonderenTCno, "Boş Bırakılamaz.");return;}
            else
            { TCHatasi.Clear(); }
        }
    }
}
