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
using System.Windows.Shapes;

namespace Microsoft_To_Do
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    
    
    public partial class Vhod : Window
    {
        private SqlConnection conn;
        public Vhod()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=3205EC07\SQLEXPRESS ; Initial Catalog=ToDo; Integrated Security=SSPI;");
            conn.Open();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           SqlCommand sqlcom = new SqlCommand("select id_user from users where login = " + Log.Text + " and password = " + Pass.Text + ";",conn);
           SqlDataReader reader = sqlcom.ExecuteReader();
            if (reader.Read())
            {
                var id = reader[0].ToString();
                reader.Close();
                MainWindow mainWindow= new MainWindow(conn, id);
                mainWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }


        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
