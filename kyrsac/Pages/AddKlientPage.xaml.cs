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
    /// Логика взаимодействия для AddKlientPage.xaml
    /// </summary>
    public partial class AddKlientPage : Page
    {
        
        public AddKlientPage(клиент _клиент)
        {
            InitializeComponent();

            Myклиент = _клиент;
            this.DataContext = this;
        }
        public клиент Myклиент { get; set; }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {           
            var ФИО = FioBox.Text;
            var телефон = PhoneBox.Text;
            var адрес = AdresBox.Text;// 
           

            var u = new клиент();

            u.ФИО = ФИО;
            u.телефон = телефон;
            u.адрес = адрес;
            
            DB.Connection.клиент.Add(u);
            DB.Connection.SaveChanges();



        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var ФИО = FioBox.Text;
            var телефон = PhoneBox.Text;
            var адрес = AdresBox.Text;// 


            var u = new клиент();

            u.ФИО = ФИО;
            u.телефон = телефон;
            u.адрес = адрес;

          //  DB.Connection.клиент.Add(u);
            DB.Connection.SaveChanges();
            MessageBox.Show("!!");
        }
    }
}
