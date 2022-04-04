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
    /// Логика взаимодействия для PostavshikPage.xaml
    /// </summary>
    public partial class PostavshikPage : Page
    {
        public PostavshikPage()
        {
            InitializeComponent();
            Myпоставщик = new поставщик();
            var db = new dbZavgorodEntities2();
            PostavshikGrid.ItemsSource = db.поставщик.ToList();//добавление таблицы в грид

            this.DataContext = this;
        }
        public поставщик Myпоставщик { get; set; }//My написанно на английском

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {


            var u = PostavshikGrid.SelectedItem as поставщик;
            MessageBox.Show(u.название_поставщика);
            DB.Connection.поставщик.Remove(u);//ВОТ ТУТ ОШИБКА  "Не удалось удалить объект, поскольку он не найден в ObjectStateManager."

            DB.Connection.SaveChanges();
            PostavshikGrid.ItemsSource = DB.Connection.клиент.ToList();
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            var u = PostavshikGrid.SelectedItem as поставщик;
            NavigationService.Navigate(new AddPostavshikPage(u));
            DB.Connection.SaveChanges();
            PostavshikGrid.ItemsSource = DB.Connection.поставщик.ToList();
           // var u = PostavshikGrid.SelectedItem as поставщик;
          //  NavigationService.Navigate(new AddPostavshikPage(u));//открытие формы
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            var u = PostavshikGrid.SelectedItem as поставщик;
            NavigationService.Navigate(new AddPostavshikPage(u));//открытие формы
        }

        private void SbrosBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new PostavshikPage();
            NavigationService.Navigate(page);
        }

        private void PoiskBut_Click(object sender, RoutedEventArgs e)
        {
            var db = new dbZavgorodEntities2();
            var us = db.поставщик.ToList();
            IEnumerable<поставщик> rezult = null;
            int ind = SpisokBox.SelectedIndex;
            if (SerchText.Text.Length > 0)
            {
                switch (ind)
                {
                    case 0:
                        var page = new KlientPage();
                        NavigationService.Navigate(page); break;
                    case 1: rezult = us.Where(find => find.название_поставщика.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 2: rezult = us.Where(find => find.телефон.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    case 3: rezult = us.Where(find => find.email.StartsWith(SerchText.Text)); SerchText.IsEnabled = true; break;
                    default: break;
                }
            }
            else
            {
                var page = new KlientPage();
                NavigationService.Navigate(page);
            }
           // var rezult = us.Where(user =>user.Surname.StartsWith(SearchText.Text)).ToList();
            PostavshikGrid.ItemsSource = rezult.ToList();
            CounterLabel.Content = PostavshikGrid.Items.Count;
        }

        private void ExelBt_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "Поставщики";
            //

            for (int j = 1; j < PostavshikGrid.Columns.Count ; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = PostavshikGrid.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= PostavshikGrid.Columns.Count-1; i++)
                for (int j = 0; j < PostavshikGrid.Items.Count; j++)
                {
                    PostavshikGrid.ScrollIntoView(PostavshikGrid.Items[j]);
                    TextBlock b = PostavshikGrid.Columns[i - 1].GetCellContent(PostavshikGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }
    }
}
