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
using System.IO;
using System.Data;
using System.Data.SqlClient;




namespace Yük_Gemisi_Yönetim_Sistemi
{
    /// <summary>
    /// Interaction logic for seferler.xaml
    /// </summary>
    public partial class seferler : Window
    {
        public seferler()
        {
            InitializeComponent();
            string KitapDosyaAdi = "ülkeler.txt";
            string[] Kitaplar = System.IO.File.ReadAllLines(KitapDosyaAdi);
            foreach (var kitap in Kitaplar)
            {
                comboBox_country.Items.Add(kitap);

                string conString = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                SqlConnection baglanti = new SqlConnection(conString);

                textBox_firmaadı.Text = firmakayit.gonderilecekveri;
            }



        }

        void temiz()
        {
            textBox_firmaadı.Text = " ";
            textBox_firmaseri.Text = " ";
            textBox_firmailetisim.Text = " ";
            comboBox_country.SelectedIndex = 0;
            textBox_uruncesit.Text = " ";
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            /* string[] Kitaplar = System.IO.File.ReadAllLines(KitapDosyaAdi);
              foreach (var kitap in Kitaplar)
              {
                  comboBox_country.Items.Add(kitap);
              }*/

        }





        private void comboBox_country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_firmatemizle_Click(object sender, RoutedEventArgs e)
        {
            temiz();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_firmakaydet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string conString = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                SqlConnection baglanti = new SqlConnection(conString);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into firma(ad,serino,iletisim,ulke,urun) values (@ad,@serino,@iletisim,@ulke,@urun)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@ad", textBox_firmaadı.Text);
                komut.Parameters.AddWithValue("@serino", textBox_firmaseri.Text);
                komut.Parameters.AddWithValue("@iletisim", textBox_firmailetisim.Text);
                komut.Parameters.AddWithValue("@ulke", comboBox_country.Text);
                komut.Parameters.AddWithValue("@urun", textBox_uruncesit.Text);
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
            textBox_firmaadı.Clear();
            textBox_firmaseri.Clear();
            textBox_firmailetisim.Clear();
            textBox_uruncesit.Clear();
            textBox_firmaadı.Focus();


        }

        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // kayitgoster();

            //  FirmaKayit firmakayit = new FirmaKayit();
            // firmakayit.ShowDialog();

            firmakayit firmakayit = new firmakayit();
            this.Close();
            firmakayit.ShowDialog();





        }
        private void kayitgoster()
        {

            /*    string conString = ("server=DESKTOP-CT568H0; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                SqlConnection baglanti = new SqlConnection(conString);
                baglanti.Open();
                string kayit = "Select*From firma";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGrid3.ItemsSource = dt.DefaultView;*/



        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //   MainWindow anamenü = new MainWindow();
            this.Close();
            // anamenü.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox_firmaadı_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }



        private void textBox_firmaseri_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void textBox_firmaseri_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //  e.Handled = !IsValid(((TextBox)sender).Text + e.Text);

        }
        // public static bool IsValid(string str)
        //{
        //   int i;
        //  return int.TryParse(str, out i) && i >= 0 && i <= 99999;
        // }

        private void textBox_firmailetisim_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //           e.Handled = !IsValid1(((TextBox)sender).Text + e.Text);
        }

        private void textBox_firmaseri_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            textBox_firmaseri.MaxLength = 5;
        }

        private void textBox_firmailetisim_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox_firmailetisim.MaxLength = 11;
        }

        private void textBox_firmaadı_TextChanged(object sender, TextChangedEventArgs e)
        {
            //  textBox_firmaadı.Text = textBox_firmaadı.Text.ToUpper();


            
        }

        
           

        


    }

    //  public static bool IsValid1(string str)
    //    {
    //        int i;
    // return int.TryParse(str, out i) && i >= 0 && i <= 999999;
    //}
}

