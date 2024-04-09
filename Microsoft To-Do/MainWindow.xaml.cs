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

namespace Microsoft_To_Do
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn;
        private string id;
        public MainWindow(SqlConnection conn, string id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            WriteNickname();
            WriteKatigories();
            

        }

        private void WriteKatigories()
        {
            SqlCommand cmd = new SqlCommand("select chapter_name,icon from Chapter where id_user="+ id, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Chapter.Items.Add(ReturnList(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Close();
        }


        private void WriteNickname()
        {
            SqlCommand cmd = new SqlCommand("select fio from users where id_user=" + id, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            NickName.Text= reader[0].ToString();
            reader.Close();
        }


        public Grid ReturnList(string Icons, string createZametka )
        {
            Grid grid = new Grid();

            ColumnDefinition column1 = new ColumnDefinition();
            column1.Width = new GridLength(25);
            ColumnDefinition column2 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/images/icons/"+Icons+".png", UriKind.Relative));
            image.SetValue(Grid.ColumnProperty, 0);
            image.Width = 20;
            image.Height = 25;

            TextBlock textBlock = new TextBlock();
            textBlock.SetValue(Grid.ColumnProperty, 1);
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Text = createZametka;

            grid.Children.Add(image);
            grid.Children.Add(textBlock);
            return grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Razdel reader = new Razdel();
            create cr = new create(reader);
            cr.ShowDialog();
            Chapter.Items.Add(ReturnList(reader.IdIcon, reader.Name));


        }



        private void Chapter_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {Stac.Children.Clear();
            string sq= ((TextBlock)((Grid)Chapter.SelectedItem).Children[1]).Text;
            SqlCommand cmd = new SqlCommand($"select description from cases where id_chapter=(select id_chapter from chapter where chapter_name ='{sq}');", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = reader[0];
                checkBox.FontSize = 15;
                Stac.Children.Add(checkBox);
            }
            reader.Close();

        }
    }
}
