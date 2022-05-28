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
    /// Interaction logic for GemiKayit.xaml
    /// </summary>
    public partial class GemiKayit : Window
    {
        public GemiKayit()
        {
            InitializeComponent();
            kayitgoster();
        }
        static string Constring = ("server=DESKTOP-H303PVF; Initial Catalog=yuk_gemisi;Integrated Security=SSPI");
        SqlConnection baglanti = new SqlConnection(Constring);
        private void kayitgoster()
        {
            string kayit = "Select* From ship";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            baglanti.Close();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            gemibakim gemi = new gemibakim();
            this.Close();
            gemi.ShowDialog();
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from ship where gemiadi=@gemiadi", baglanti);
            komut.Parameters.AddWithValue("@gemiadi", textBox_silicek.Text);
            komut.ExecuteNonQuery();
            kayitgoster();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            GemiKayit frmkyt = new GemiKayit();
            this.Close();
            gemibakim gb = new gemibakim();


            if (row_selected != null)
            {
                gb.textBox_gemiadı.Text = row_selected["gemiadi"].ToString();
               gb.textBox_serino.Text = row_selected["gemiserino"].ToString();
                gb.bakimtarihi.Text= row_selected["gemibakimtarih"].ToString();
               gb.erzakteslim.Text = row_selected["erzakteslim"].ToString();
                gb.temizliktarih.Text = row_selected["temizliktarih"].ToString();
            }
            gb.ShowDialog();

        }

        private void textBox_silicek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox_ara_TextChanged(object sender, TextChangedEventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara = textbox_ara.Text;
            cumle = "Select*From ship where gemiadi like '%" + textbox_ara.Text + "%'";
            SqlDataAdapter adptr = new SqlDataAdapter(cumle, baglanti);
            adptr.Fill(tbl);
            dataGrid1.ItemsSource = tbl.DefaultView;
            baglanti.Close();
        }
    }
}
