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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Yük_Gemisi_Yönetim_Sistemi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        //    SqlConnection sConn = new SqlConnection();
          //  SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
           // SqlDataAdapter sAdp;
          //  DataTable dt;
          //  DataSet ds;
           // scb.DataSource = "@DESKTOP-CT568H0";

        }
       

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            personel1 personel1 = new personel1();
           // MessageBox.Show(personel.Getmessage());
            personel1.ShowDialog();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            gemibakim gemibakim = new gemibakim();
            gemibakim.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            seferler seferler = new seferler();
            seferler.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            seferq seferq = new seferq();
            seferq.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
        //    FirmaKayit firmakayit = new FirmaKayit();
          //  firmakayit.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
