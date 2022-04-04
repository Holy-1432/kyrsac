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

namespace kyrsac.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTovarPage.xaml
    /// </summary>
    public partial class AddTovarPage : Page
    {
        public AddTovarPage(товар _товар)
        {
            InitializeComponent();
            Myтовар = _товар;
            this.DataContext = this;
        }
        public товар Myтовар { get; set; }

        private void SaveTovarBt_Click(object sender, RoutedEventArgs e)//добавление товара 
        {
            
           
           // DB.Connection.SaveChanges();
            var тип = TipBox.Text;
            var название = NameBox.Text;
            var характеристика = XaraktBox.Text;// 
            var изготовитель = IzgBox.Text;// 
            var наличие_на_складе = NalichieBox.Text;// 
            var цена = ChenaBox.Text;// 

            var u = new товар();

            u.тип = тип;
            u.название = название;
            u.характеристика = характеристика;
            u.изготовитель = изготовитель;
            u.наличие_на_складе = наличие_на_складе;
            u.цена = Convert.ToInt32( цена);
            DB.Connection.товар.Add(u);
            DB.Connection.SaveChanges();
        }

        private void EditTovarBt_Click(object sender, RoutedEventArgs e)//изменение товара
        {
            var тип = TipBox.Text;
            var название = NameBox.Text;
            var характеристика = XaraktBox.Text;// 
            var изготовитель = IzgBox.Text;// 
            var наличие_на_складе = NalichieBox.Text;// 
            var цена = ChenaBox.Text;// 

            var u = new товар();

            u.тип = тип;
            u.название = название;
            u.характеристика = характеристика;
            u.изготовитель = изготовитель;
            u.наличие_на_складе = наличие_на_складе;
            u.цена = Convert.ToInt32(цена);
           // DB.Connection.товар.Add(u);
            DB.Connection.SaveChanges();
        }
    }
}
