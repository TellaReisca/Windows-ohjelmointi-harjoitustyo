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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Tietovisa
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Window1 : Window 
    {
        public Window1()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (uNameBox.Text.Length == 0)
            {
                MessageBox.Show("Enter an username");
                uNameBox.Focus();
            }
            else
            {
                string username = uNameBox.Text;
                string password = passwordBox.Password;
            }
            try
            {
                string myConnection = "Data source=mysql.labranet.jamk.fi;Initial Catalog=H8510;user=H8510;password=4FCgJB6skri1KocsV08cwkGPbRYzmqWE;";
                MySqlConnection con = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("SELECT * FROM User WHERE Name='" + this.uNameBox.Text + "' and Password='" + this.passwordBox.Password + "' ;", con);

                MySqlDataReader myReader;
                con.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Correct username and password!");
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password ... access denied!");
                }
                else
                {
                    MessageBox.Show("Wrong username and password... Try again! ");
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
