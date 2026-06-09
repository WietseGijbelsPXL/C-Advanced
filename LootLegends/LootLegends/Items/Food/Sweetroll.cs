using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Food
{
    public class Sweetroll : Food, IConsumable
    {
        public Sweetroll(Rarity rarity) : base("Sweetroll", 0.3, rarity)
        {
        }

        public void Eat(Player player)
        {
            int healthGained = 10 * (int)Rarity + 1;
            player.Health += healthGained;
            Console.WriteLine($"You eat a sweetroll…​ Delicious! +{healthGained} HP.");
        }

        public override string GetDescription()
        {
            return "A sweet roll that restores a lot of health.";
        }

        public override string ToString()
        {
            return base.ToString() + " Sweetroll";
        }
    }
}
