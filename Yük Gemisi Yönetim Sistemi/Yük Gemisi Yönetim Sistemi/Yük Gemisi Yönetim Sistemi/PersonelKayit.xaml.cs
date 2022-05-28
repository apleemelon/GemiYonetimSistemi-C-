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
    /// Interaction logic for PersonelKayit.xaml
    /// </summary>
    public partial class PersonelKayit : Window
    {
        public PersonelKayit()
        {
            InitializeComponent();
            kayitgoster();
        }
        static string Constring= ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
        SqlConnection baglanti = new SqlConnection(Constring);

        public void kayitgoster()
        {
            string kayit = "Select* From personel";
            SqlCommand komut = new SqlCommand(kayit,baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            baglanti.Close();
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            personel1 personel = new personel1();
            this.Close();
            personel.ShowDialog();

        }

        private void textBox_silicek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From personel where Ad=@Ad",baglanti);
            komut.Parameters.AddWithValue("@Ad",textBox_silicek.Text);
            komut.ExecuteNonQuery();
            kayitgoster();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");

        }
        
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            PersonelKayit personelkayit= new PersonelKayit();
            this.Close();
            personel1 personel= new personel1();


            if (row_selected != null)
            {
                personel.textBox_adı.Text = row_selected["Ad"].ToString();
                personel.textBox.Text = row_selected["Soyad"].ToString();
                personel.textBox_telefon.Text = row_selected["Telefon"].ToString();
                personel.dogumtarihi.Text = row_selected["dogum_tarihi"].ToString();
                personel.comboBox_gorev.Text = row_selected["gorev"].ToString();
                personel.comboBox_cinsiyet.Text = row_selected["cinsiyet"].ToString();
                personel.textBox_maas.Text = row_selected["maas"].ToString();

            }
            personel.ShowDialog();
        }

        private void textBox_ara_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = textBox_ara.Text;
            cumle = "Select* From personel where ad like '%" + textBox_ara.Text + "%'";
            SqlDataAdapter adptr = new SqlDataAdapter(cumle,baglanti);
            adptr.Fill(tbl);
            dataGrid1.ItemsSource = tbl.DefaultView;
            baglanti.Close();
        }
    }
}
