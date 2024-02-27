using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace zadanie3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Trade2Entities db = Trade2Entities.GetContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.ShowDialog();
            autorization.Focus();
            if (Data.Login == false) Close();
            if (Data.Right == "Администратор")
            {
                Add_zap.IsEnabled = true;
                Edit.IsEnabled = true;
                Delete.IsEnabled = true;
            }
           
            autorization.Title = Data.Familia + " " + Data.Name + " "
                + Data.Otchestvo + " - " + Data.Right;

            db.Products.Load();
            listView1.ItemsSource = db.Products.Local.ToBindingList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add f = new Add();
            f.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Product row = (Product)listView1.SelectedValue;
                    db.Products.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
    }
}
