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
    /// Логика взаимодействия для TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        public TovarPage()
        {
            InitializeComponent();
            Myтовар = new товар();
            var db = new dbZavgorodEntities2();
           TovarGrid.ItemsSource = DB.Connection.товар.ToList();//добавление таблицы в грид

            this.DataContext = this;
            var u = TovarGrid.SelectedItem as товар;
        }
        public товар Myтовар { get; set; }//My написанно на английском

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            var u = TovarGrid.SelectedItem as товар;
            NavigationService.Navigate(new AddTovarPage(u));//открытие формы
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var u = TovarGrid.SelectedItem as товар;
            MessageBox.Show(Convert.ToString(u));
            //   DB.Connection.товар.Attach(u
            MessageBox.Show($"{u.код_товара}, {u.название}, {u.цена}");
            DB.Connection.товар.Remove(u);
            
            DB.Connection.SaveChanges();
            TovarGrid.ItemsSource = DB.Connection.товар.ToList();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var u = TovarGrid.SelectedItem as товар;
            NavigationService.Navigate(new AddTovarPage(u));
            DB.Connection.SaveChanges();
            TovarGrid.ItemsSource = DB.Connection.товар.ToList();            

        }

        private void ExelBt_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "товары ";
            //

            for (int j = 1; j < TovarGrid.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = TovarGrid.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= TovarGrid.Columns.Count-1; i++)
                for (int j = 0; j < TovarGrid.Items.Count; j++)
                {
                    TovarGrid.ScrollIntoView(TovarGrid.Items[j]);
                    TextBlock b = TovarGrid.Columns[i - 1].GetCellContent(TovarGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }

        private void PoiskBut_Click(object sender, RoutedEventArgs e)
        {
            var db = new dbZavgorodEntities2();
            var us = db.товар.ToList();
            IEnumerable<товар> rezult = null;
            int ind = SpisokBox.SelectedIndex;
            if (SerchText.Text.Length > 0)
            {
                switch (ind)
                {
                    case 0:
                        var page = new TovarPage();
                        NavigationService.Navigate(page); break;
                    case 1: rezult = us.Where(find => find.тип.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 2: rezult = us.Where(find => find.название.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 3: rezult = us.Where(find => find.характеристика.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 4: rezult = us.Where(find => find.изготовитель.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 5: rezult = us.Where(find => find.наличие_на_складе.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    //case 6: rezult = us.Where(find => find.цена.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    default: break;
                }
            }
            else
            {
                var page = new TovarPage();
                NavigationService.Navigate(page);
            }
            //var rezult = us.Where(user =>user.Surname.StartsWith(SearchText.Text)).ToList();
            TovarGrid.ItemsSource = rezult.ToList();
            CounterLabel.Content = TovarGrid.Items.Count;
        }

        private void SbrosBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new TovarPage();
            NavigationService.Navigate(page);
        }
    }
}
