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
using System.Data.SqlClient;
using System.Data;
namespace Yük_Gemisi_Yönetim_Sistemi
{
    /// <summary>
    /// Interaction logic for seferq.xaml
    /// </summary>
    public partial class seferq : Window
    {
        public seferq()
        {
            InitializeComponent();
            comboBox.Items.Add("Onaylandı");
            comboBox.Items.Add("Onaylanmadı");
        }

        
        public void kayitgoster()
        {
        



        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SeferlerKayit seferkayit = new SeferlerKayit();
            this.Close();
            seferkayit.ShowDialog();
        }

        private void button_kaydetseferq_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string conString= ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                SqlConnection baglanti = new SqlConnection(conString);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into seferler(baslangıc_yeri,bitis_yeri,kalkıs_zamanı,varis_zamanı,sefer_durumu) values (@baslangıc_yeri,@bitis_yeri,@kalkıs_zamanı,@varis_zamanı,@sefer_durumu)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@baslangıc_yeri", textBox_baslangıcyeri.Text);
                komut.Parameters.AddWithValue("@bitis_yeri", textBox_bitisyeri.Text);
                komut.Parameters.AddWithValue("@kalkıs_zamanı", kalkıszamanı.Text);
                komut.Parameters.AddWithValue("@varis_zamanı", variszamani.Text);
                komut.Parameters.AddWithValue("@sefer_durumu", comboBox.Text);
                
                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglanti.Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {

                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
