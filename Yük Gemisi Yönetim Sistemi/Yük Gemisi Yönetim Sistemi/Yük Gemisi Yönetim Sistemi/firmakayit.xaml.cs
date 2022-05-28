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
    /// Interaction logic for firmakayit.xaml
    /// </summary>
    public partial class firmakayit : Window
        
    {
        public firmakayit()
        {

            InitializeComponent();
            kayitgoster();
            
           
       
        }
        public static string gonderilecekveri;



        static string conString = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
        SqlConnection baglanti = new SqlConnection(conString);
        private void kayitgoster()
        {
            string kayit = "Select* From firma";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.ItemsSource = dt.DefaultView;
            baglanti.Close();
        }
        //yeni
        void Kayıtsil(int numara)
        {
            string sql = "DELETE FROM firma WHERE ad=@ad";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@numara", numara);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        ////////////////////////////////////////////////////////////////////////////
            private void button1_Click(object sender, RoutedEventArgs e)
        {
            seferler seferler = new seferler();
            this.Close();
            seferler.ShowDialog();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
           baglanti.Open();
          
            SqlCommand komut = new SqlCommand("delete from firma where id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", textBox_silicek.Text);
            komut.ExecuteNonQuery();
            kayitgoster();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");


       
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void textBox_silicek_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.Open();
               DataTable tbl = new DataTable();
               string vara, cumle;
               vara = textBox_ara.Text;
               cumle = "Select* From firma where ad like '%" + textBox_ara.Text + "%'";
               SqlDataAdapter adptr = new SqlDataAdapter(cumle, baglanti);
               adptr.Fill(tbl);
            dataGridView1.ItemsSource = tbl.DefaultView;
            baglanti.Close();


         


            //  dataGridView1.DataContext = tbl;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            

        }

        private void dataGridView1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int secilialan = dataGridView1.SelectedCells[0].
        }

        private void dataGridView1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Seçili kayıtı Silmek İstiyor Musunuz ?");
{
                baglanti.Open();
             //   string secili = dataGridView1.CurrentColumn.Cell[1].Value.ToString();
              //  SqlCommand sc = new SqlCommand("delete from tbl_malzemebirimleri where birimadi = @sec", baglanti);
               // sc.Parameters.Add("@sec", secili);
               // sc.ExecuteNonQuery();

              //  MessageBox.Show("seçili kayıt silindi");

               // DataTable tbl = new DataTable();
               // SqlDataAdapter adptr = new SqlDataAdapter("Select * from tbl_malzemebirimleri ", baglanti);
               // adptr.Fill(tbl);

//                dataGridView1.ItemsSource = tbl.DefaultView;
                

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /* try
             {
                 string conString = ("server=DESKTOP-CT568H0; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
                 SqlConnection baglanti = new SqlConnection(conString);
                 if (baglanti.State == ConnectionState.Closed)
                     baglanti.Open();
                 // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                 string kayit = "update firma(ad,serino,iletisim,ulke,urun) values (@ad,@serino,@iletisim,@ulke,@urun)";
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
             }*/

            
         


        }

        private void dataGridView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            firmakayit frmkyt = new firmakayit();
            this.Close();
            seferler sfr = new seferler();
           
            
            if (row_selected!=null)
            {
                sfr.textBox_firmaadı.Text = row_selected["ad"].ToString();
                sfr.textBox_firmaseri.Text = row_selected["serino"].ToString();
                sfr.textBox_firmailetisim.Text = row_selected["iletisim"].ToString();
                sfr.comboBox_country.Text = row_selected["ulke"].ToString();
                //personel.comboBox_cinsiyet.Text = row_selected["cinsiyet"].ToString();
                sfr.textBox_uruncesit.Text = row_selected["urun"].ToString();
            }
            sfr.ShowDialog();

        }
    }
    }
