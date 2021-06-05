using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public struct car
        {
            public string nomer { get; set; }

            public string brand { get; set; }

            public int year { get; set; }

            public int cost { get; set; }
        }
        public struct car2
        {
            public string nomer { get; set; }

            public string brand { get; set; }
        }

        private void car_yars_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int year = int.Parse(bd_str.Text);
                string connectionString = @"Server=Asliddin\MSSQLSERVER01;Database=Asliddin;Trusted_Connection=True;";
                string sqlExpression = "SELECT * FROM cartabl";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<car2> cars = new List<car2>();
                    while (reader.Read())
                    {
                        car2 a = new car2();
                        a.nomer = reader.GetValue(0).ToString();
                        a.brand = reader.GetValue(1).ToString();
                        if ((int)reader.GetValue(2) == year)
                            cars.Add(a);
                    }
                    DT.ItemsSource = cars;
                }
            }
            catch (FormatException c)
            {
                MessageBox.Show(c.Message);
            }
            catch (OverflowException c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void load(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = @"Server=Asliddin\MSSQLSERVER01;Database=Asliddin;Trusted_Connection=True;";
                string sqlExpression = "SELECT * FROM cartabl";
                List<car> cars = new List<car>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())

                    {

                        car a = new car();

                        a.nomer = reader.GetValue(0).ToString();

                        a.brand = reader.GetValue(1).ToString();

                        a.year = (int)reader.GetValue(2);

                        a.cost = (int)reader.GetValue(3);

                        cars.Add(a);

                    }

                }
                DT.ItemsSource= cars;
            }
            catch (System.Data.SqlClient.SqlException c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void delet_car(object sender, RoutedEventArgs e)
        {
            try
            {

                int year = int.Parse(bd_str.Text);
                string connectionString = @"Server=Asliddin\MSSQLSERVER01;Database=Asliddin;Trusted_Connection=True;";
                string sqlExpression = $"DELETE FROM cartabl WHERE CONVERT(int,[год выпуска])<{year}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand delet = new SqlCommand(sqlExpression, connection);
                    delet.ExecuteNonQuery();
                    MessageBox.Show("удаление прошло успешно))");
                }
            }
            catch (FormatException c)
            {
                MessageBox.Show(c.Message);
            }
            catch (OverflowException c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void sort(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = @"Server=Asliddin\MSSQLSERVER01;Database=Asliddin;Trusted_Connection=True;";
                string sqlExpression = "SELECT * FROM cartabl ORDER BY марка";
                List<car> cars = new List<car>();
                var carsbrand = new List<string>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())

                    {

                        car a = new car();

                        a.nomer = reader.GetValue(0).ToString();

                        a.brand = reader.GetValue(1).ToString();

                        a.year = (int)reader.GetValue(2);

                        a.cost = (int)reader.GetValue(3);

                        carsbrand.Add(reader.GetValue(1).ToString());
                        cars.Add(a);

                    }

                }



                DT.ItemsSource = cars;
            }
            catch (System.Data.SqlClient.SqlException c)
            {
                MessageBox.Show(c.Message);
            }
        }
    }
}
