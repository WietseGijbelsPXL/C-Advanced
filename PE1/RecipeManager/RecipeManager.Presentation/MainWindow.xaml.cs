using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using RecipeManager.Application;
using RecipeManager.Domain.Models;

namespace RecipeManager.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecipeService _service = new RecipeService();
        RecipeDetailWindow _recipeDetailWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void FillListBox()
        {
            recipesListBox.ItemsSource = null;
            if (_service.GetRecipes() != null)
            {
                recipesListBox.ItemsSource = _service.GetRecipes();
                saveJsonButton.IsEnabled = true;
                exportCsvButton.IsEnabled = true;
            }
            else
            {
                saveJsonButton.IsEnabled = false;
                exportCsvButton.IsEnabled = false;
            }
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeEditWindow recipeEditWindow = new RecipeEditWindow(null);
            if (recipeEditWindow.ShowDialog() == true)
            {
                _service.AddRecipe(recipeEditWindow.Recipe);
                FillListBox();
            }
        }

        private void EditRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeEditWindow recipeEditWindow = new RecipeEditWindow((Recipe)recipesListBox.SelectedItem);
            if (recipeEditWindow.ShowDialog() == true)
            {
                _service.UpdateRecipe(recipeEditWindow.Recipe);
                FillListBox();
            }
        }

        private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = (Recipe)recipesListBox.SelectedItem;

            MessageBoxResult result = MessageBox.Show($"Bent u zeker dat u het recept {recipe.Name} wil verwijderen?", "Bevesting verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                _service.DeleteRecipe(recipe);
                FillListBox();
            }
        }

        private void LoadJsonButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files| *.json|All files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _service.LoadRecipes(openFileDialog.FileName);
                FillListBox();
            }
        }

        private void SaveJsonButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files| *.json|All files|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                _service.SaveRecipes(saveFileDialog.FileName);
            }
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files| *.csv|All files|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Recipe recipe in _service.GetRecipes())
                    {
                        sw.WriteLine($"{recipe.Name};{recipe.PreparationTime};{recipe.Difficulty}");
                    }
                }
            }
        }
        private void recipesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Recipe recipe = (Recipe)recipesListBox.SelectedItem;


            if (_recipeDetailWindow == null || !_recipeDetailWindow.IsVisible)
            {
                _recipeDetailWindow = new RecipeDetailWindow();
                _recipeDetailWindow.Recipe = recipe;
                _recipeDetailWindow.Show();
            }
            else
            {
                _recipeDetailWindow.Recipe = recipe;
                _recipeDetailWindow.Show();
                _recipeDetailWindow.Activate();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_service.Saved == false)
            {
                MessageBoxResult result = MessageBox.Show("Recepten zijn niet opgeslagen. Bent u zeker dat u wil sluiten?","Bevestig afsluiten",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if(result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}