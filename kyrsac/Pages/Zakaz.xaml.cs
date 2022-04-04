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
namespace kyrsac
{
    /// <summary>
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Page
    {
        public long nom;
        public Zakaz()
        {
            InitializeComponent();
            Myвсе_заказы  = new все_заказы();
            var db = new dbZavgorodEntities2();
            ZakazGrid.ItemsSource = DB.Connection.все_заказы.ToList();//добавление таблицы в грид
            this.DataContext = this;
            var u = ZakazGrid.SelectedItem as все_заказы;
            //var db = new BankEntities();
        }

        public все_заказы Myвсе_заказы { get; set; }//My написанно на английском

        private void ContentBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)// только начал делать 
        {
            var ba = ZakazGrid.SelectedItem as все_заказы;
            nom = ba.код_заказа;
            var db = new dbZavgorodEntities2();
            var us = db.состав_заказа.ToList();
            var result = us.Where(find => find.код_заказа == nom).ToList();
            SostavGrid.ItemsSource = result;
        }

        private void ExelBt_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "все заказы ";
            //

            for (int j = 1; j < ZakazGrid.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = ZakazGrid.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= ZakazGrid.Columns.Count - 1; i++)
                for (int j = 0; j < ZakazGrid.Items.Count; j++)
                {
                    ZakazGrid.ScrollIntoView(ZakazGrid.Items[j]);
                    TextBlock b = ZakazGrid.Columns[i - 1].GetCellContent(ZakazGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }

        private void AddKLbt_Click(object sender, RoutedEventArgs e)
        {
            var u = ZakazGrid.SelectedItem as все_заказы;
            NavigationService.Navigate(new AddZakazPage(u));//открытие формы
        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PoiskBut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SbrosBut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBut_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBut_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ExelBt_Copy_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "Состав заказа";
            //

            for (int j = 1; j < SostavGrid.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = SostavGrid.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= SostavGrid.Columns.Count - 1; i++)
                for (int j = 0; j < SostavGrid.Items.Count; j++)
                {
                    SostavGrid.ScrollIntoView(SostavGrid.Items[j]);
                    TextBlock b = SostavGrid.Columns[i - 1].GetCellContent(SostavGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }
    }
}
