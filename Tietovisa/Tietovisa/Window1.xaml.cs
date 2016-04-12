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
using Tietovisa;

namespace Tietovisa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private BLAnswer answer1; //Vastaus oliot luodaan jo täällä jotta ne olisi käytettävissä buttosissa.
        private BLAnswer answer2;
        private BLAnswer answer3;
        private BLAnswer answer4;
        int pisteet = 0;
        int lopisteet;
        

        public Window1()
        {
            InitializeComponent();
            ConnectToMySQL();
            
        }

        void ConnectToMySQL()
        {
            try
            {

                string connectionString = GetConnectionString(); //Hakee yhteysloitsun

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    NewQuestion();
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }

        }


        public void NewQuestion()
        {
            try
            {
                string connectionString = GetConnectionString();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    Random rand = new Random();
                    int randquest = rand.Next(0, 16);
                    int random = randquest; //näin saadaan pidettyä randomi-arvo samana yhteen kysymykseen tarvittavan MySQL -kyselyn aikana.


                    string questionquery = "SELECT * FROM Question WHERE QuestionKey=" + random + ";";
                    string answerquery = "SELECT * FROM Answer WHERE Question_QuestionKey=" + random + ";";
                    
                    

                    MySqlCommand qcommand = new MySqlCommand(questionquery, conn);
                    MySqlDataAdapter qadapter = new MySqlDataAdapter(qcommand);
                    DataSet qds = new DataSet();
                    qadapter.Fill(qds, "Content");

                    List<BLQuestion> qlist = new List<BLQuestion>(); //Käytetään linq-kyselyä jotta saadaan täytettyä kysymys ohjelman sisäiseen listaan
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

                    List<BLAnswer> alist = new List<BLAnswer>(); //Käytetään linq-kyselyä jotta saadaan täytettyä listaan kaikki kysymyksen vastaukset
                    foreach (DataRow adr in ads.Tables[0].Rows)
                    {
                        alist.Add(new BLAnswer { Content = Convert.ToString(adr["Content"]), AnswerKey = Convert.ToInt32(adr["AnswerKey"]), Flag = Convert.ToInt32(adr["Flag"]) });
                    }

                    answer1 = alist[0];
                    btnAnswer1.Content = answer1.Content;

                    answer2 = alist[1];
                    btnAnswer2.Content = answer2.Content;

                    answer3 = alist[2];
                    btnAnswer3.Content = answer3.Content;

                    answer4 = alist[3];
                    btnAnswer4.Content = answer4.Content;

                    tbPelaaja.Text = "Pelaaja: "+((MainWindow)System.Windows.Application.Current.MainWindow).uNameBox.Text;
                }


            }

            catch (Exception)
            {
                MessageBox.Show("Jotain tapahtui. Yritä uudelleen!"); //Ohjelmalla on sillon tällöin ongelmia käydessään tämä metodi. Tämä ei kuitenkaan vaikuta pelaamiseen kauheasti.
            }
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            pisteet = 0;
            tbPisteet.Text = "Pisteesi: " + pisteet;
            tbOV.Text = "";
            tbPelaaja.Text = "";
            NewQuestion();
        }

        static string GetConnectionString()
        {
            return @"Data source=mysql.labranet.jamk.fi;Initial Catalog=H8510;user=H8510;password=4FCgJB6skri1KocsV08cwkGPbRYzmqWE;"; // Miksi ei toimi appconfigista?
        }

        private void btnAnswer1_Click(object sender, RoutedEventArgs e) //buttonit vastauksille
        {
            if (answer1.Flag == 1)
            {
                pisteet = pisteet + 1;
                tbPisteet.Text = "Pisteesi: " + pisteet;
                tbOV.Foreground = Brushes.GreenYellow;
                tbOV.Text = "OIKEIN!";
                NewQuestion();
            }
            else
            {
                tbOV.Foreground = Brushes.Red;
                tbOV.Text = "VÄÄRIN! PELI OHI!";
                lopisteet = pisteet;
                pisteet = 0;
                tbPisteet.Text = "Pisteesi: " + lopisteet;
                
            }
        }

        private void btnAnswer2_Click(object sender, RoutedEventArgs e)
        {
            if (answer2.Flag == 1)
            {
                pisteet = pisteet + 1;
                tbPisteet.Text = "Pisteesi: " + pisteet;
                tbOV.Foreground = Brushes.GreenYellow;
                tbOV.Text = "OIKEIN!";
                NewQuestion();
            }
            else
            {
                tbOV.Foreground = Brushes.Red;
                tbOV.Text = "VÄÄRIN! PELI OHI!";
                lopisteet = pisteet;
                pisteet = 0;
                tbPisteet.Text = "Pisteesi: " + lopisteet;
                
            }
        }

        private void btnAnswer3_Click(object sender, RoutedEventArgs e)
        {
            if (answer3.Flag == 1)
            {
                pisteet = pisteet + 1;
                tbPisteet.Text = "Pisteesi: " + pisteet;
                tbOV.Foreground = Brushes.GreenYellow;
                tbOV.Text = "OIKEIN!";
                NewQuestion();
            }
            else
            {
                tbOV.Foreground = Brushes.Red;
                tbOV.Text = "VÄÄRIN! PELI OHI!";
                lopisteet = pisteet;
                pisteet = 0;
                tbPisteet.Text = "Pisteesi: " + lopisteet;
                
            }
        }

        private void btnAnswer4_Click(object sender, RoutedEventArgs e)
        {
            if (answer4.Flag == 1)
            {
                pisteet = pisteet + 1;
                tbPisteet.Text = "Pisteesi: " + pisteet;
                tbOV.Foreground = Brushes.GreenYellow;
                tbOV.Text = "OIKEIN!";
                NewQuestion();
            }
            else
            {
                tbOV.Foreground = Brushes.Red;
                tbOV.Text = "VÄÄRIN! PELI OHI!";
                lopisteet = pisteet;
                pisteet = 0;
                tbPisteet.Text = "Pisteesi: " + pisteet;
                
            }
        }

        private void btnOhje_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vastaa kysymykseen valitsemalla yksi neljästä eri vastausvaihtoehdosta.").ToString();
        }
    }
}
