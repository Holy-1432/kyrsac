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
    /// Логика взаимодействия для AddPostavshikPage.xaml
    /// </summary>
    public partial class AddPostavshikPage : Page
    {
        public AddPostavshikPage(поставщик _поставщик)
        {
            InitializeComponent();
            Myпоставщик = _поставщик;
            this.DataContext = this;
        }
        public поставщик Myпоставщик { get; set; }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            DB.Connection.SaveChanges();
            var название_поставщика = NameBox.Text;
            var телефон = PhoneBox.Text;
            var email = EmailBox.Text;// 
           

            var u = new поставщик();

            u.название_поставщика = название_поставщика;
            u.телефон = телефон;
            u.email = email;
           
            DB.Connection.поставщик.Add(u);
            DB.Connection.SaveChanges();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
           // DB.Connection.SaveChanges();
            var название_поставщика = NameBox.Text;
            var телефон = PhoneBox.Text;
            var email = EmailBox.Text;// 


            var u = new поставщик();

            u.название_поставщика = название_поставщика;
            u.телефон = телефон;
            u.email = email;

          //  DB.Connection.поставщик.Add(u);
            DB.Connection.SaveChanges();
            MessageBox.Show("!!");
        }
    }
}
