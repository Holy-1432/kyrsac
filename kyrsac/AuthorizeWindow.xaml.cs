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

namespace kyrsac
{
    /// <summary>
    /// Логика взаимодействия для AuthorizeWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        public AuthorizeWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            /*   var page = new MainWindow();
               page.Show();
               this.Close();*/
            //var db = new dbZavgorodEntities2();
            //var us = db.Security.ToList();
            //bool flag = us.Any(log => log.Login == TextLogin.Text && log.Password == TextPasw.Password);
            if (true)
            {
                var page = new MainWindow();
                page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль не верный");
                TextLogin.Focus();
                TextPasw.Clear();
            }


        }
    }
}
