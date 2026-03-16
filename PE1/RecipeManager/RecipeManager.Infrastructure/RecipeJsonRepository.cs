using RecipeManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeManager.Infrastructure
{
    public class RecipeJsonRepository
    {
        List<Recipe> _recipes = new List<Recipe>();

        public void Import(string jsonFile)
        {
            if (!File.Exists(jsonFile))
            {
                throw new FileNotFoundException("Het bestand bestaat niet.");
            }

            string content = File.ReadAllText(jsonFile);
            _recipes = JsonSerializer.Deserialize<List<Recipe>>(content);
        }

        public List<Recipe> GetAll()
        {
            return _recipes;
        }

        public void Add(Recipe recipe)
        {
            recipe.Id = Guid.NewGuid();
            _recipes.Add(recipe);
        }

        public void Update(Recipe recipe)
        {
            _recipes.Find(r => r.Id == recipe.Id).Name = recipe.Name;
            _recipes.Find(r => r.Id == recipe.Id).Ingredients = recipe.Ingredients;
            _recipes.Find(r => r.Id == recipe.Id).Difficulty = recipe.Difficulty;
            _recipes.Find(r => r.Id == recipe.Id).PreparationTime = recipe.PreparationTime;
        }

        public void Delete(Guid id)
        {
            _recipes.Remove(_recipes.Find(r => r.Id == id));
        }

        public void Save(string jsonFile)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            string content = JsonSerializer.Serialize(_recipes, options);
            File.WriteAllText(jsonFile, content);
        }
    }
}
