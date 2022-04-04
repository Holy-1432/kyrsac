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
    /// Логика взаимодействия для AddZakazPage.xaml
    /// </summary>
    public partial class AddZakazPage : Page
    {
        public AddZakazPage(все_заказы _все_заказы)
        {
            InitializeComponent();
            Myвсе_заказы = _все_заказы;
            this.DataContext = this;
        }
        public все_заказы Myвсе_заказы { get; set; }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            var код_клиента = KodTB.Text;
            var дата_заказа = DataZak.SelectedDate;
            var место_доставки = MestoBT.Text;// 
           
                
            var u = new все_заказы();

            u.код_клиента = Convert.ToInt32(код_клиента);
            u.дата_заказа = дата_заказа;
            u.место_доставки = место_доставки;
            
            
            DB.Connection.все_заказы.Add(u);
            DB.Connection.SaveChanges();
        }
    }
}
