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
using kyrsac.Pages;

namespace kyrsac.Pages
{
    /// <summary>
    /// Логика взаимодействия для PostavkaPage.xaml
    /// </summary>
    public partial class PostavkaPage : Page
    {
        public PostavkaPage()
        {
            InitializeComponent();
            Myпоставка = new поставка();
            var db = new dbZavgorodEntities2();
             PostavkaGrid.ItemsSource = db.поставка.ToList();//добавление таблицы в грид

            this.DataContext = this;
        }
        public поставка Myпоставка { get; set; }//My написанно на английском

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            var u = PostavkaGrid.SelectedItem as поставка;
            NavigationService.Navigate(new AddPostavkaPage(u));//открытие формы
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            var u = PostavkaGrid.SelectedItem as поставка;
            NavigationService.Navigate(new AddPostavkaPage(u));//открытие формы
        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            var u = PostavkaGrid.SelectedItem as поставка;
           // MessageBox.Show(u.код_товара);
            //DB.Connection.клиент.Attach(u);
            DB.Connection.поставка.Remove(u);
            DB.Connection.SaveChanges();
           PostavkaGrid.ItemsSource = DB.Connection.клиент.ToList();
        }

        private void SbrosBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new PostavkaPage();
            NavigationService.Navigate(page);
        }

        private void PoiskBut_Click(object sender, RoutedEventArgs e)
        {
          /*  var db = new dbZavgorodEntities2();
            var us = db.поставка.ToList();
            IEnumerable<поставка> rezult = null;
            int ind = SpisokBox.SelectedIndex;
            if (SerchText.Text.Length > 0)
            {
                switch (ind)
                {
                    case 0:
                        var page = new KlientPage();
                        NavigationService.Navigate(page); break;
                    case 1: rezult = us.Where(find => find.количество.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 2: rezult = us.Where(find => find.код_товара.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
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
            PostavkaGrid.ItemsSource = rezult.ToList();
            CounterLabel.Content = PostavkaGrid.Items.Count;*/
        }

        private void ExelBt_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "Поставки";
            //

            for (int j = 1; j < PostavkaGrid.Columns.Count ; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = PostavkaGrid.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= PostavkaGrid.Columns.Count-1; i++)
                for (int j = 0; j < PostavkaGrid.Items.Count; j++)
                {
                    PostavkaGrid.ScrollIntoView(PostavkaGrid.Items[j]);
                    TextBlock b = PostavkaGrid.Columns[i - 1].GetCellContent(PostavkaGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }
    }
}
