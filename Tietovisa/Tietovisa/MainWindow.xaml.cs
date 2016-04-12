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
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (uNameBox.Text.Length == 0)
            {
                tbLogin.Foreground = Brushes.Aquamarine;
                tbLogin.Text = "Please enter an username and a password";
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
                string keyQuery = "SELECT UserKey FROM User WHERE Name'" + uNameBox.Text + "';";
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
                    tbLogin.Foreground = Brushes.YellowGreen;
                    tbLogin.Text = "Correct username and password!";
                    Window1 secondary = new Window1();
                    secondary.ShowDialog();
                    
                }
                else if (count > 1)
                {
                    tbLogin.Foreground = Brushes.Red;
                    tbLogin.Text = "Duplicate username and password ... Access denied!";
                    
                }
                else
                {
                    tbLogin.Foreground = Brushes.Red;
                    tbLogin.Text = "Wrong username and password ... Access denied!";
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (uNameBox.Text.Length == 0)
            {
                MessageBox.Show("Enter an username");
                uNameBox.Focus();
            }
            else
            {
                string registername = registerBox.Text;
                string registerpassword = passwordRegBox.Password;
            }
            try
            {
                string myConnection = "Data source=mysql.labranet.jamk.fi;Initial Catalog=H8510;user=H8510;password=4FCgJB6skri1KocsV08cwkGPbRYzmqWE;";
                MySqlConnection con = new MySqlConnection(myConnection);

                MySqlCommand InsertCommand = new MySqlCommand("insert into User(Name, Password) values ('" + this.registerBox.Text + "','" + this.passwordRegBox.Password + "');", con);//insert into User(Name, Password) values ('Arska','sala1');

                MySqlDataReader myReader;
                con.Open();
                myReader = InsertCommand.ExecuteReader();
                MessageBox.Show("Rekisteröinti onnistui!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}

