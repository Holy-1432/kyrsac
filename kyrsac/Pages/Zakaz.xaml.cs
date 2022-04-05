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
using System.Collections.ObjectModel;

namespace kyrsac
{
    /// <summary>
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Page
    {
        public long nom;
        public ObservableCollection<все_заказы> OrdersView;
        public ObservableCollection<состав_заказа> PacksOfOrder;
        public все_заказы SelectedOrder;
        public Zakaz()
        {
            InitializeComponent();
            Myвсе_заказы  = new все_заказы();
            var db = new dbZavgorodEntities2();
            OrdersView = new ObservableCollection<все_заказы>(DB.Connection.все_заказы.ToList());
            PacksOfOrder = new ObservableCollection<состав_заказа>();
            DataGridAllOrders.ItemsSource = OrdersView;//добавление таблицы в грид
            DataGridPacksOfSelectedOrder.ItemsSource = PacksOfOrder;
            this.DataContext = this;
            var u = DataGridAllOrders.SelectedItem as все_заказы;
            //var db = new BankEntities();
        }

        public все_заказы Myвсе_заказы { get; set; }//My написанно на английском

        private void ContentBt_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void Button_Click(object sender, RoutedEventArgs e)// только начал делать 
        //{
        //    var ba = DataGridAllOrders.SelectedItem as все_заказы;
        //    nom = ba.Id;
        //    var db = new dbZavgorodEntities2();
        //    var us = db.состав_заказа.ToList();
        //    var result = us.Where(find => find.Id == nom).ToList();
        //    SostavGrid.ItemsSource = result;
        //}

        private void ExelBt_Click(object sender, RoutedEventArgs e)
        {
            //
            var application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);

            Excel.Worksheet sheet1 = application.Worksheets.Item[1]; //Sheets[1];
            sheet1.Name = "все заказы ";
            //

            for (int j = 1; j < DataGridAllOrders.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = DataGridAllOrders.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= DataGridAllOrders.Columns.Count - 1; i++)
                for (int j = 0; j < DataGridAllOrders.Items.Count; j++)
                {
                    DataGridAllOrders.ScrollIntoView(DataGridAllOrders.Items[j]);
                    TextBlock b = DataGridAllOrders.Columns[i - 1].GetCellContent(DataGridAllOrders.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }

        private void AddKLbt_Click(object sender, RoutedEventArgs e)
        {
            var u = DataGridAllOrders.SelectedItem as все_заказы;
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

            for (int j = 1; j < DataGridPacksOfSelectedOrder.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j];
                //sheet1.Columns[j].ColumnWidth = 25;
                myRange.Value2 = DataGridPacksOfSelectedOrder.Columns[j - 1].Header;
                myRange.Font.Bold = true;
            }


            for (int i = 1; i <= DataGridPacksOfSelectedOrder.Columns.Count - 1; i++)
                for (int j = 0; j < DataGridPacksOfSelectedOrder.Items.Count; j++)
                {
                    DataGridPacksOfSelectedOrder.ScrollIntoView(DataGridPacksOfSelectedOrder.Items[j]);
                    TextBlock b = DataGridPacksOfSelectedOrder.Columns[i - 1].GetCellContent(DataGridPacksOfSelectedOrder.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i];
                    myrange.Value2 = b.Text;
                }
        }

        private void ButtonViewPackSelectedOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAllOrders.SelectedItem is null)
            {
                MessageBox.Show("Выберите заказ, щёлкнув по нему");
                return;
            }
            SelectedOrder = (все_заказы)DataGridAllOrders.SelectedItem;
            PacksOfOrder.Clear();
            foreach (var item in SelectedOrder.состав_заказа)
            {
                PacksOfOrder.Add(item);
            }
        }

        private void ButtonDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var userAnswer = MessageBox.Show("Вы действительно хотите удалить этот заказ?", "Удаление заказа",
                       MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }
            var button = (Button)sender;
            var order = (все_заказы)button.DataContext;
            //SelectedOrder = (все_заказы)DataGridAllOrders.SelectedItem;
            //DataGridPacksOfSelectedOrder.ItemsSource = SelectedOrder.состав_заказа;
            OrdersView.Remove(order);
            //DataGridPacksOfSelectedOrder.ItemsSource = null;
            PacksOfOrder.Clear();
            order.состав_заказа.Clear();
            DB.Connection.все_заказы.Remove(order);
            DB.Connection.SaveChanges();
        }

        private void ButtonDeletePackOfOrder_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var packOrder = (состав_заказа)button.DataContext;
            SelectedOrder.состав_заказа.Remove(packOrder);
            var newOrderAmount = SelectedOrder.сумма_заказа - packOrder.общая_стоимость;
            PacksOfOrder.Remove(packOrder);
            DB.Connection.все_заказы.First(item=>item.код_заказа == packOrder.все_заказы.код_заказа).состав_заказа.Remove(packOrder);
            DB.Connection.все_заказы.First(item => item.код_заказа == packOrder.все_заказы.код_заказа).сумма_заказа = newOrderAmount;
            DB.Connection.SaveChanges();
            //orderInDb;
            OrdersView.Clear();
            var newList = DB.Connection.все_заказы.ToList();
            foreach (var item in newList)
            {
                OrdersView.Add(item);
            }
        }
    }
}
