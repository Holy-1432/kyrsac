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
    /// Логика взаимодействия для OtchetPage.xaml
    /// </summary>
    public partial class OtchetPage : Page
    {
        public OtchetPage()
        {
            InitializeComponent();
        }
       

        private void PostavkaBut_Click(object sender, RoutedEventArgs e)
        {

           
            NavigationService.Navigate(new PostavkaPage());//открытие формы
        }

        private void PostavshikBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PostavshikPage());//открытие формы
        }
    }
}
