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
        public ProductPage()
        {
            InitializeComponent();
            ProductListView.ItemsSource = db.context.Product.ToList();


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
    }
}
