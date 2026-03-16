using RecipeManager.Domain.Models;
using RecipeManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Application
{
    public class RecipeService
    {
        public bool Saved { get; set; }

        RecipeJsonRepository _repository;

        public RecipeService()
        {
            _repository = new RecipeJsonRepository();
        }

        public void LoadRecipes(string path)
        {
            _repository.Import(path);
        }

        public List<Recipe> GetRecipes()
        {
            return _repository.GetAll();
        }

        public void AddRecipe(Recipe recipe)
        {
            if(recipe.Difficulty == "Moeilijk" && recipe.Ingredients.Count < 3)
            {
                throw new InvalidDataException("Een moeilijk recept moet minstens 3 ingrediënten hebben.");
            }
            _repository.Add(recipe);
            Saved = false;
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _repository.Update(recipe);
            Saved = false;
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _repository.Delete(recipe.Id);
            Saved = false;
        }

        public void SaveRecipes(string path)
        {
            _repository.Save(path);
            Saved = true;

        }
    }
}
