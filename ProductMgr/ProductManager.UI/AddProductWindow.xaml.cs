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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        ProductRepository _repository;

        public AddProductWindow(ProductRepository productRepository)
        {
            InitializeComponent();
            _repository = productRepository;
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product() { ID = int.Parse(idTextBox.Text), Name = nameTextBox.Text, Price = decimal.Parse(priceTextBox.Text), Stock = int.Parse(stockTextBox.Text) };
                _repository.Add(product);
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
