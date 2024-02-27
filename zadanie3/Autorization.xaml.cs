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

namespace zadanie3
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        Trade2Entities db = Trade2Entities.GetContext();
        public Autorization()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Login.Focus();
            Data.Login = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = from p in db.Users
                       where p.UserLogin == Login.Text &&
                       p.UserPassword == Password.Text
                       select p;
            if(user.Count() ==1  ) 
            {
                Data.Login = true;
                Data.Familia = user.First().UserSurname;
                Data.Name = user.First().UserName;
                Data.Otchestvo = user.First().UserPatronymic;
                Data.Right = user.First().Role.RoleName;
                Close();
            }
            else
            {
                MessageBox.Show("fdsf");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Data.Login= true;
            Data.Familia= "Гость";
            Data.Name= "";
            Data.Otchestvo = "";
            Data.Right = "Клиент";
            Close();
        }
    }
}
