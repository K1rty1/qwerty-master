using qwerty.Model;
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

namespace qwerty.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        Core db = new Core();
        List<ProductType> productTypes;
        public ProductPage()
        {
            InitializeComponent();
            List<string> sortTypeList = new List<string>()
            {"аименование","остаток на складе","стоймость"
            };
            SortComboBox.ItemsSource = sortTypeList;
            productTypes = new List<ProductType>
            {
                new ProductType()
                { 
                    ID=0,
                    Title="Все типы"
                }
            };
            productTypes.AddRange(db.context.ProductType.ToList());
            FilterComboBox.ItemsSource = productTypes;
            UpdateUI();




        }
        private void UpdateUI()
        {
            List<Product> displayProduct = GetRows().ToList();
             ProductListView.ItemsSource =displayProduct;
        }
        private List<Product> GetRows()
        {
            List<Product> arrayproduct = db.context.Product.ToList();
            string searchData = SearchTextBox.Text;
            if (!String.IsNullOrEmpty(SearchTextBox.Text))
            {
                arrayproduct = arrayproduct.Where(x => x.Title.ToUpper().Contains(searchData)).ToList();
            }
            int filter = Convert.ToInt32(FilterComboBox.SelectedValue);
            if (FilterComboBox.SelectedIndex == 0)
            {
                arrayproduct = arrayproduct.ToList();
            }
            else
            {
                arrayproduct = arrayproduct.Where(x => x.ProductTypeID==filter).ToList();
            }
            int value = SortComboBox.SelectedIndex;
            if (value==0)
            {
                arrayproduct = arrayproduct.OrderBy(p => p.Title).ToList();
            }
            else if (value==1)
            {
                arrayproduct = arrayproduct.OrderBy(p => p.ProductionWorkshopNumber).ToList();
            }
            return arrayproduct;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateProductPage());
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Введите наименование продукта")
            {
                SearchTextBox.Text = "";
            }
        }

        private void SearchTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Введите наименование продукта";
            }
        }

        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUI();
        }

        private void FilterComboBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }
        private void ReverceButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SortComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
