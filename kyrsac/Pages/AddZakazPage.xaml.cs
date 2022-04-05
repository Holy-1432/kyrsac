using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddZakazPage.xaml
    /// </summary>
    public partial class AddZakazPage : Page
    {
        public ObservableCollection<товар> Goods;
        public ObservableCollection<состав_заказа> PacksOfOrder = new ObservableCollection<состав_заказа>();
        public состав_заказа SelectedPack;
        private товар _selectedGood;
        public AddZakazPage(все_заказы _все_заказы)
        {
            InitializeComponent();
            Myвсе_заказы = _все_заказы;
            this.DataContext = this;
            Goods = new ObservableCollection<товар>( DB.Connection.товар.ToList());
            ComboBoxListGoods.ItemsSource = Goods;
            DataGridOrderPacks.ItemsSource = PacksOfOrder;
            DataGridOrderPacks.SelectedItem = SelectedPack;


        }
        public все_заказы Myвсе_заказы { get; set; }

        private void ButtonSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            bool isValidOrder = DatePickerOrderDate.SelectedDate is null 
                                || String.IsNullOrEmpty(TextBoxPlaceOfDelivery.Text) 
                                || String.IsNullOrEmpty(TextBoxClientCode.Text);

            if (isValidOrder)
            {
                MessageBox.Show("Заполните все поля составления заказа");
                return;
            }

            if(PacksOfOrder.Count == 0)
            {
                MessageBox.Show("Состав заказа не может быть пустым");
                return;
            }
            int код_клиента;
            if (!Int32.TryParse(TextBoxClientCode.Text, out код_клиента))
            {
                MessageBox.Show("Код клиента должен быть числом");
                return;
            }
            if (DB.Connection.клиент.FirstOrDefault(cl=>cl.код_клиента == код_клиента) is null)
            {
                MessageBox.Show("Клиента с таким кодом не существует");
                return;
            }
           
            var newOrder = new все_заказы();

            newOrder.состав_заказа = PacksOfOrder.ToList();
            newOrder.код_клиента = код_клиента;
            newOrder.дата_заказа = DatePickerOrderDate.SelectedDate;
            newOrder.место_доставки = TextBoxPlaceOfDelivery.Text;
            decimal? generalOrderAmount = 0m;
            foreach (var item in newOrder.состав_заказа)
            {
                generalOrderAmount += item.общая_стоимость;
                item.все_заказы = newOrder;
            }
            newOrder.сумма_заказа = generalOrderAmount;
            newOrder.клиент = DB.Connection.клиент.First(item => item.код_клиента == код_клиента);
            DB.Connection.все_заказы.Add(newOrder);
            MessageBox.Show("Заказ добавлен");
            DB.Connection.SaveChanges();
        }

        private void ComboBoxListGoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var good = (товар)comboBox.SelectedItem;
            if (ComboBoxListGoods.SelectedItem is товар)
            {
                
                TextBlockPriceGood.Text = good.цена.ToString();
                _selectedGood = good;
            }
            else
            {
                return;
            }
        }

        private void ButtonAddOrderPack_Click(object sender, RoutedEventArgs e)
        {
            int countGoods;
            if (_selectedGood is null)
            {
                MessageBox.Show("Сначала выберете товар");
                return;
            }
            if (!Int32.TryParse(TextBoxCountGood.Text, out countGoods))
            {
                MessageBox.Show("Количество должно быть указано числом");
                return;
            }
            
            состав_заказа orderPack = new состав_заказа();
            orderPack.количество_товара = countGoods;
            orderPack.товар = _selectedGood;
            orderPack.код_товара = _selectedGood.код_товара;
            orderPack.цена_продажи = _selectedGood.цена;
            orderPack.общая_стоимость = (decimal)_selectedGood.цена*countGoods;
            PacksOfOrder.Add(orderPack);
        }

        private void DataGridGoodsOfOrder_Selected(object sender, RoutedEventArgs e)
        {
            var dataGrid = (DataGrid)sender;
            SelectedPack = (состав_заказа)dataGrid.SelectedItem;
        }

        private void ButtonRemoveGood_Click(object sender, RoutedEventArgs e)
        {
            var userAnswer = MessageBox.Show("Вы действительно хотите удалить этот набор товаров?", "Удаление состава заказа",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }
            SelectedPack = (состав_заказа)DataGridOrderPacks.SelectedItem;
            PacksOfOrder.Remove(SelectedPack);
        }
    }
}
