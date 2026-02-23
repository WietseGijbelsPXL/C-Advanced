using ProductManager.Models;
using ProductManager.Services;
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
using System.Windows.Shapes;

namespace ProductManager.UI
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        ProductRepository _repository = new ProductRepository();

        public ProductListWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void OnAddProduct_Clicked(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow(_repository);
            if (addProductWindow.ShowDialog() == true)
            {
                UpdateWindow();
            }
        }



        public void UpdateWindow()
        {
            productsListBox.Items.Clear();
            foreach (Product product in _repository.GetAllProducts())
            {
                productsListBox.Items.Add(product);
            }
        }

        private void OnDeleteProduct_Clicked(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListBox.SelectedItem;
            if (product != null)
            {
                _repository.Remove(product);
                UpdateWindow();
            }
        }
    }
}
