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
using MySql.Data.MySqlClient;
using System.Data;

namespace Tietovisa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectToMySQL();
        }

        void ConnectToMySQL()
        {
            try
            {
                
                string connectionString = GetConnectionString();
                string mysqlquery = "SELECT * FROM Question;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    MySqlCommand command = new MySqlCommand(mysqlquery, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Content");
                    dgQuestions.DataContext = ds;
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }

        }

        



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saat kysymyksen, johon on neljä vastausta, joista yksi on oikein.");
        }

        static string GetConnectionString()
        {
            /*return Tietovisa.Properties.Settings.Default.dataSource;*/
            /*return @"Data source=mysql.labranet.jamk.fi;Initial Catalog=salesa;user=salesa;password=fyEfchdior3MZlrcjz6U27L0aiNolowl;";*/
            return @"Data source=mysql.labranet.jamk.fi;Initial Catalog=H8510;user=H8510;password=4FCgJB6skri1KocsV08cwkGPbRYzmqWE;"; // Miksi ei toimi appconfigista
        }

    }
}
