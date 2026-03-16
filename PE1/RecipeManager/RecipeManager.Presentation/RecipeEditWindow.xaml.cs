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
    /// Interaction logic for RecipeEditWindow.xaml
    /// </summary>
    public partial class RecipeEditWindow : Window
    {
        public Recipe Recipe { get; set; }

        public RecipeEditWindow(Recipe recipe)
        {
            InitializeComponent();
            if (recipe != null)
            {
                Recipe = recipe;
                nameTextBox.Text = recipe.Name;
                preparationTimeTextBox.Text = recipe.PreparationTime.ToString();
                difficultyComboBox.Text = recipe.Difficulty;
                RefreshListBox();
                Title = "Wijzig recept";
            }
            else
            {
                Recipe = new Recipe();
                Title = "Nieuw recept";
            }
        }

        public void RefreshListBox()
        {
            ingredientsListBox.ItemsSource = null;
            ingredientsListBox.ItemsSource = Recipe.Ingredients;
        }

        private void addIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (Recipe.Ingredients != null)
            {
                Recipe.Ingredients.Add(ingredientTextBox.Text);
            }
            else
            {
                Recipe.Ingredients = new List<string> { ingredientTextBox.Text };
            }
                RefreshListBox();
        }

        private void removeIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe.Ingredients.Remove(ingredientTextBox.Text);
            RefreshListBox();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(preparationTimeTextBox.Text) || string.IsNullOrWhiteSpace(difficultyComboBox.Text) || ingredientsListBox.Items.Count == 0)
            {
                MessageBox.Show("Vul alle velden correct in.","Fout",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Recipe.Name = nameTextBox.Text;
                Recipe.Difficulty = difficultyComboBox.Text;
                Recipe.PreparationTime = int.Parse(preparationTimeTextBox.Text);
                Recipe.Ingredients = ingredientsListBox.Items.Cast<string>().ToList();
                DialogResult = true;
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
