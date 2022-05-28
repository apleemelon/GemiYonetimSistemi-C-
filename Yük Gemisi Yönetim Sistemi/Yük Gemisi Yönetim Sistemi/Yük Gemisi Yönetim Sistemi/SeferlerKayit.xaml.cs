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
    /// Interaction logic for SeferlerKayit.xaml
    /// </summary>
    public partial class SeferlerKayit : Window
    {
        public SeferlerKayit()
        {
            InitializeComponent();
            kayitgoster();
        }
        static string Constring = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
        SqlConnection baglanti = new SqlConnection(Constring);

        public void kayitgoster()
        {

            string kayit = "Select* From seferler";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            baglanti.Close();

        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            seferq gemi = new seferq();
            this.Close();
            gemi.ShowDialog();
        }

        private void textBox_silicek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from seferler where baslangıc_yeri=@baslangıc_yeri", baglanti);
            komut.Parameters.AddWithValue("@baslangıc_yeri", textBox_silicek.Text);
            komut.ExecuteNonQuery();
            kayitgoster();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            SeferlerKayit seferkayit= new SeferlerKayit();
            this.Close();
            seferq seferq = new seferq();


            if (row_selected != null)
            {
                seferq.textBox_baslangıcyeri.Text = row_selected["baslangıc_yeri"].ToString();
               seferq.textBox_bitisyeri.Text = row_selected["bitis_yeri"].ToString();
                seferq.kalkıszamanı.Text = row_selected["kalkıs_zamanı"].ToString();
                seferq.variszamani.Text = row_selected["varis_zamanı"].ToString();
                   seferq.comboBox.Text = row_selected["sefer_durumu"].ToString();
                
            }
                seferq.ShowDialog();
        }

        private void textbox_ara_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = textbox_ara.Text;
            cumle = "Select* From seferler where baslangıc_yeri like '%" + textbox_ara.Text + "%'";
            SqlDataAdapter adptr = new SqlDataAdapter(cumle, baglanti);
            adptr.Fill(tbl);
            dataGrid1.ItemsSource = tbl.DefaultView;
            baglanti.Close();



        }
    }
}
