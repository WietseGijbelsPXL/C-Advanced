using Fruitshop.Application;
using Fruitshop.Domain;
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

namespace Fruitshop.Presentation
{
    /// <summary>
    /// Interaction logic for OverviewWindow.xaml
    /// </summary>
    public partial class OverviewWindow : Window
    {
        FruitService _service;

        public OverviewWindow()
        {
            InitializeComponent();

            _service = new FruitService(new Infrastructure.FruitRepository());
            fruitListBox.ItemsSource = _service.GetAllFruits();

        }

        private void createFruitButton_Click(object sender, RoutedEventArgs e)
        {
            EditFruitWindow editFruitWindow = new EditFruitWindow(null, _service);
            if (editFruitWindow.ShowDialog() == true)
            {
                fruitListBox.ItemsSource = _service.GetAllFruits();
            }
        }

        private void deleteFruitButton_Click(object sender, RoutedEventArgs e)
        {
            _service.Delete(((Fruit)fruitListBox.SelectedItem).Id);
            fruitListBox.ItemsSource = _service.GetAllFruits();
        }

        private void fruitListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditFruitWindow editFruitWindow = new EditFruitWindow((Fruit)fruitListBox.SelectedItem, _service);
            if (editFruitWindow.ShowDialog() == true)
            {
                fruitListBox.ItemsSource = _service.GetAllFruits();
            }
        }
    }
}
