using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для create.xaml
    /// </summary>
    public partial class create : Window
    {
        Razdel razdel;
        public create(Razdel razdel)
        {
            InitializeComponent();
            this.razdel = razdel;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            razdel.Name= createZametka.Text;
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "5";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "1";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "2";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "3";
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "4";
        }

    }
}
