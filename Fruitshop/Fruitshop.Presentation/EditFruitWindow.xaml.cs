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
    /// Interaction logic for EditFruitWindow.xaml
    /// </summary>
    public partial class EditFruitWindow : Window
    {
        FruitService _service;
        Fruit _fruit;

        public EditFruitWindow(Fruit fruit, FruitService fruitService)
        {
            InitializeComponent();

            _service = fruitService;

            _fruit = fruit;
            if (fruit != null)
            {
                nameTextBox.Text = fruit.Name;
                colorTextBox.Text = fruit.Color;
                seasonTextBox.Text = fruit.Season;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (_fruit == null)
            {
                _fruit = new Fruit();
                FillObject();
                _service.Add(_fruit);
            }
            else
            {
                FillObject();
                _service.Update(_fruit);
            }
            DialogResult = true;
        }

        private void FillObject()
        {
            _fruit.Name = nameTextBox.Text;
            _fruit.Color = colorTextBox.Text;
            _fruit.Season = seasonTextBox.Text;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
