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
                
                Random rand = new Random();
                int randquest = rand.Next(0, 16);
                int random = randquest;
                
                string connectionString = GetConnectionString();
                string questionquery = "SELECT * FROM Question WHERE QuestionKey="+random+";";
                string answerquery = "SELECT * FROM Answer WHERE Question_QuestionKey="+random+";";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    
                    MySqlCommand qcommand = new MySqlCommand(questionquery, conn);
                    MySqlDataAdapter qadapter = new MySqlDataAdapter(qcommand);
                    DataSet qds = new DataSet();
                    qadapter.Fill(qds, "Content");

                    List<BLQuestion> qlist = new List<BLQuestion>();
                    foreach (DataRow qdr in qds.Tables[0].Rows)
                    {
                        qlist.Add(new BLQuestion { Content = Convert.ToString(qdr["Content"]), QuestionKey = Convert.ToInt32(qdr["QuestionKey"]) });
                    }

                    BLQuestion question1 = new BLQuestion();
                    question1 = qlist[0];
                    tbQuestions.Text = question1.Content;

                    
                    MySqlCommand acommand = new MySqlCommand(answerquery, conn);
                    MySqlDataAdapter aadapter = new MySqlDataAdapter(acommand);
                    DataSet ads = new DataSet();
                    aadapter.Fill(ads, "Content");

                    List<BLAnswer> alist = new List<BLAnswer>();
                    foreach (DataRow adr in ads.Tables[0].Rows)
                    {
                        alist.Add(new BLAnswer { Content = Convert.ToString(adr["Content"]), AnswerKey = Convert.ToInt32(adr["AnswerKey"]), Flag = Convert.ToInt32(adr["Flag"]) });
                    }

                    BLAnswer answer1 = new BLAnswer();
                    answer1 = alist[0];
                    btnAnswer1.Content = answer1.Content;

                    BLAnswer answer2 = new BLAnswer();
                    answer2 = alist[1];
                    btnAnswer2.Content = answer2.Content;

                    BLAnswer answer3 = new BLAnswer();
                    answer3 = alist[2];
                    btnAnswer3.Content = answer3.Content;

                    BLAnswer answer4 = new BLAnswer();
                    answer4 = alist[3];
                    btnAnswer4.Content = answer4.Content;

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
