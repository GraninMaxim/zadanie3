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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Trade2Entities db = Trade2Entities.GetContext();
        Product p1 = new Product();

        public Add()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Artic.Text.Length == 0) errors.AppendLine("Введите артикул");
            if (Naim.Text.Length == 0) errors.AppendLine("Введите наименование");
            if (Opis.Text.Length == 0) errors.AppendLine("Введите описание");
            if (Proizvod.Text.Length == 0) errors.AppendLine("");
            if (Cost.Text.Length == 0) errors.AppendLine("");
            if (Kol.Text.Length == 0) errors.AppendLine("");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if ((int.Parse(Cost.Text) > 1)&&(int.Parse(Kol.Text)>0)) 
                {
                p1.ProductArticleNumber=Artic.Text;
                    p1.Изображение = photo.Text;
                    p1.Наименование=Naim.Text;
                    p1.Описание = Opis.Text;
                    p1.Производитель=Proizvod.Text;
                    p1.Стоимость= int.Parse (Cost.Text);
                    p1.Кол_склад= int.Parse (Kol.Text);

                   
                    db.Products.Add(p1);
                    db.SaveChanges();
                    MessageBox.Show("Запись добавлена");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
                
                
           
            

        }
    }
}
