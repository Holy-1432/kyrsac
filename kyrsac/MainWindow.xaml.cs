using kyrsac.Pages;
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

namespace kyrsac
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var page = new MainPage();
            MainFrame.Navigate(page);
        }

        private void GlMain_Click(object sender, RoutedEventArgs e)
        {
         //   MessageBox.Show("Главная");
            var page = new MainPage();
            MainFrame.Navigate(page);
        }

        private void katalogMain_Click(object sender, RoutedEventArgs e)
        {
          //  MessageBox.Show("каталог товаров");
            var page = new TovarPage();
            MainFrame.Navigate(page);
        }

        private void klientMain_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Список товаров");
            var page = new KlientPage();
            MainFrame.Navigate(page);
        }

        private void OtchetMain_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Отчеты");
            var page = new OtchetPage();
            MainFrame.Navigate(page);
        }

        



        private void ZakazMain_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Это заказ");
            var page = new Zakaz();
           MainFrame.Navigate(page);
        }
    }
}
