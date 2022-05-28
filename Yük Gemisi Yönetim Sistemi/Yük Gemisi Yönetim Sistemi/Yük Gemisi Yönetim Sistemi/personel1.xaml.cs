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
    /// Interaction logic for personel1.xaml
    /// </summary>
    public partial class personel1 : Window
    {
    

        //SqlConnection conn = new SqlConnection("Data Source = DESKTOP-CT568H0; Initial Catalog = yuk_gemisi; Integrated Security = True;");

        public personel1()
        {
            InitializeComponent();
            comboBox_cinsiyet.Items.Add("Erkek");
            comboBox_cinsiyet.Items.Add("Kadın");
            

        //    con.Open();

            comboBox_gorev.Items.Add("Kaptan");
            comboBox_gorev.Items.Add("Birinci Zabit");
            comboBox_gorev.Items.Add("İkinci Zabit ");
            comboBox_gorev.Items.Add("Üçüncü Zabit");
            comboBox_gorev.Items.Add("Baş Makinist");
            comboBox_gorev.Items.Add("İkinci Makinist");
            comboBox_gorev.Items.Add("Üçüncü Makinist");
            comboBox_gorev.Items.Add("Dördüncü Makinist");
            comboBox_gorev.Items.Add("Elektrikçi");
            comboBox_gorev.Items.Add("Güverte Reisi");
            comboBox_gorev.Items.Add("Gemici");
            comboBox_gorev.Items.Add("Makine Lostromosu");
            comboBox_gorev.Items.Add("Fiter");
            comboBox_gorev.Items.Add("Yağcı");
            comboBox_gorev.Items.Add("Aşçı");
            comboBox_gorev.Items.Add("Kamarot");
            comboBox_gorev.Items.Add("Stajyer");
           
     

        }
       

   

            // public string conString = "Data Source=DESKTOP-CT568H0;Initial Catalog=yuk_gemisi;Integrated Security=True";

            void temizle()
        {
            textBox_adı.Text = " ";
            textBox.Text = " ";
            textBox_telefon.Text = " ";
            comboBox_gorev.SelectedIndex = 0;
   
        }


        private void comboBox_gorev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


        }

        private void button_kaydet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string conString = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                SqlConnection baglanti = new SqlConnection(conString);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into personel(Ad,Soyad,Telefon,dogum_tarihi,gorev,maas,Cinsiyet) values (@Ad,@Soyad,@Telefon,@dogum_tarihi,@gorev,@maas,@cinsiyet)";
                // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@Ad", textBox_adı.Text);
                komut.Parameters.AddWithValue("@Soyad", textBox.Text);
                komut.Parameters.AddWithValue("@Telefon", textBox_telefon.Text);
                komut.Parameters.AddWithValue("@dogum_tarihi", dogumtarihi.Text);
                komut.Parameters.AddWithValue("@gorev", comboBox_gorev.Text);  
                komut.Parameters.AddWithValue("@maas", textBox_maas.Text);
                komut.Parameters.AddWithValue("@cinsiyet", comboBox_cinsiyet.Text);
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

      





        private void button1_Click(object sender, RoutedEventArgs e)
        {

            temizle();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            temizle();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            PersonelKayit personelkayit = new PersonelKayit();
            this.Close();
            personelkayit.ShowDialog();
            
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBox_cinsiyet_SelectionChanged()
        {

        }
    }

}
