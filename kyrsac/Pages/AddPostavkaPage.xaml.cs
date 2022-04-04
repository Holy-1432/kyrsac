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
using kyrsac.Pages;

namespace kyrsac.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPostavkaPage.xaml
    /// </summary>
    public partial class AddPostavkaPage : Page
    {
        public AddPostavkaPage(поставка _поставка)
        {
            InitializeComponent();
            Myпоставка = _поставка;
            this.DataContext = this;
        }
        public поставка Myпоставка { get; set; }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            var количество = KolTb.Text;
            var код_товара = KodTb.Text;
            var id_поставщика = IdTb.Text;//
            var дата_поставки = DateDp.SelectedDate;//
            var сумма_поставки = SumTb.Text;//


            var u = new поставка();

            u.количество = Convert.ToInt32(количество);
            u.код_товара = Convert.ToInt32(код_товара);
            u.id_поставщика = Convert.ToInt32(id_поставщика);
            u.дата_поставки = дата_поставки;
            u.сумма_поставки = Convert.ToInt32(сумма_поставки);

            DB.Connection.поставка.Add(u);
            DB.Connection.SaveChanges();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var количество = KolTb.Text;
            var код_товара = KodTb.Text;
            var id_поставщика = IdTb.Text;//
            var дата_поставки = DateDp.SelectedDate;//
            var сумма_поставки = SumTb.Text;//


            var u = new поставка();

            u.количество = Convert.ToInt32(количество);
            u.код_товара = Convert.ToInt32(код_товара);
            u.id_поставщика = Convert.ToInt32(id_поставщика);
            u.дата_поставки = дата_поставки;
            u.сумма_поставки = Convert.ToInt32(сумма_поставки);

           // DB.Connection.поставка.Add(u);
            DB.Connection.SaveChanges();
        }
    }
}
