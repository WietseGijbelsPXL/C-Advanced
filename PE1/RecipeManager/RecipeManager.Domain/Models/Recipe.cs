using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Domain.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        private int preparationTime;

        public int PreparationTime
        {
            get { return preparationTime; }
            set
            {
                if (value < 1 || value > 180)
                {
                    throw new ArgumentException("Voorbereidingstijd moet tussen 1 en 180 minuten liggen.");
                }
                preparationTime = value;
            }
        }


        public string Difficulty { get; set; }
        public List<string> Ingredients { get; set; }


        public override string ToString()
        {
            return $"{Name} ({PreparationTime} min, {Difficulty})";
        }
    }
}
