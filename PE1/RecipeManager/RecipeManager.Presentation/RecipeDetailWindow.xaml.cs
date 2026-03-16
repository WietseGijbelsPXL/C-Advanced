using RecipeManager.Domain.Models;
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

namespace RecipeManager.Presentation
{
    /// <summary>
    /// Interaction logic for RecipeDetailWindow.xaml
    /// </summary>
    public partial class RecipeDetailWindow : Window
    {
        public Recipe Recipe
        {
            set
            {
                nameTextBlock.Text = value.Name;
                preparationTimeTextBlock.Text = $"{value.PreparationTime.ToString()} min";
                difficultyTextBlock.Text = value.Difficulty.ToString();
                ingredientsListBox.ItemsSource = value.Ingredients;
            }
        }

        public RecipeDetailWindow()
        {
            InitializeComponent();
        }
    }
}
