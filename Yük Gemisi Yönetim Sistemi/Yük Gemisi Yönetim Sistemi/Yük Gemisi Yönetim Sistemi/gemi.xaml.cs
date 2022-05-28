using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Yük_Gemisi_Yönetim_Sistemi
{
    /// <summary>
    /// Interaction logic for gemibakim.xaml
    /// </summary>
    public partial class gemibakim : Window
    {
        public gemibakim()
        {
            InitializeComponent();

            string conString = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
            SqlConnection baglanti = new SqlConnection(conString);

        }

        

        void temizle()
        {
            textBox_gemiadı.Clear();
            textBox_serino.Clear();
            

        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            temizle();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            temizle();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string conString = ("server=DESKTOP-CT568H0; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                SqlConnection baglanti = new SqlConnection(conString);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into ship (gemiadi,gemiserino,gemibakimtarih,erzakteslim,temizliktarih) values (@gemiadi,@gemiserino,@gemibakimtarih,@erzakteslim,@temizliktarih)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@gemiadi", textBox_gemiadı.Text);
                komut.Parameters.AddWithValue("@gemiserino", textBox_serino.Text);
                komut.Parameters.AddWithValue("@gemibakimtarih", bakimtarihi.Text);
                komut.Parameters.AddWithValue("@erzakteslim", erzakteslim.Text);
                komut.Parameters.AddWithValue("@temizliktarih", temizliktarih.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
                textBox_gemiadı.Clear();
                textBox_serino.Clear();
                textBox_gemiadı.Focus();            
            }


            }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            GemiKayit gk = new GemiKayit();
            this.Close();
            gk.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox_serino_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox_serino.MaxLength = 5;
        }
    }
}
