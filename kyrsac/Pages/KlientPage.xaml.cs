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
using Excel = Microsoft.Office.Interop.Excel;

namespace kyrsac.Pages
{
    /// <summary>
    /// Логика взаимодействия для KlientPage.xaml
    /// </summary>
    public partial class KlientPage : Page
    {
        public KlientPage()
        {
            InitializeComponent();
            Myклиент = new клиент();
            var db = new dbZavgorodEntities2();
            KlientGrid.ItemsSource = DB.Connection.клиент.ToList();//добавление таблицы в грид
            this.DataContext = this;
            var u = KlientGrid.SelectedItem as клиент;
            //var db = new BankEntities();


        }

        public клиент Myклиент { get; set; }//My написанно на английском

        private void AddKLbt_Click(object sender, RoutedEventArgs e)
        {
            var u = KlientGrid.SelectedItem as клиент;
            NavigationService.Navigate(new AddKlientPage(u));//открытие формы
          
         //   DB.Connection.клиент.Remove(u);
          //  DB.Connection.SaveChanges();
        }

       

      

        private void DeleteBut_Click_1(object sender, RoutedEventArgs e)
        {
            var u = KlientGrid.SelectedItem as клиент;
            MessageBox.Show(u.ФИО);
            //DB.Connection.клиент.Attach(u);
            DB.Connection.клиент.Remove(u);
            DB.Connection.SaveChanges();
            KlientGrid.ItemsSource = DB.Connection.клиент.ToList();
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            var u = KlientGrid.SelectedItem as клиент;
            NavigationService.Navigate(new AddKlientPage(u));
            DB.Connection.SaveChanges();
            KlientGrid.ItemsSource = DB.Connection.клиент.ToList();
            //var u = KlientGrid.SelectedItem as клиент;//изменение
            // NavigationService.Navigate(new AddKlientPage(u));

        }

        private void PoiskBut_Click(object sender, RoutedEventArgs e)
        {   

             var db = new dbZavgorodEntities2();
             var us = db.клиент.ToList();
             IEnumerable<клиент> rezult = null;
             int ind = SpisokBox.SelectedIndex;
             if (SerchText.Text.Length > 0)
             {
                 switch (ind)
                 {
                     case 0:
                         var page = new KlientPage();
                         NavigationService.Navigate(page); break;
                     case 1: rezult = us.Where(find => find.ФИО.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                     case 2: rezult = us.Where(find => find.телефон.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                     case 3: rezult = us.Where(find => find.адрес.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                     default: break;
                 }
             }
             else
             {
                 var page = new KlientPage();
                 NavigationService.Navigate(page);
             }
             //var rezult = us.Where(user =>user.Surname.StartsWith(SearchText.Text)).ToList();
             KlientGrid.ItemsSource = rezult.ToList();
             CounterLabel.Content = KlientGrid.Items.Count;
        }

        private void SbrosBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new KlientPage();
            NavigationService.Navigate(page);
        }

        private void ExelBt_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "Клиенты ";
            //

            for (int j = 1; j< KlientGrid.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = KlientGrid.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= KlientGrid.Columns.Count-1; i++)
                for (int j = 0; j < KlientGrid.Items.Count; j++)
                {
                    KlientGrid.ScrollIntoView(KlientGrid.Items[j]);
                   TextBlock b = KlientGrid.Columns[i - 1].GetCellContent(KlientGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }


        }
    }
}
