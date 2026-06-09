using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Food
{
    public class Apple : Food, IConsumable
    {
        public Apple(Rarity rarity) : base("Apple", 0.32, rarity)
        {
        }

        public void Eat(Player player)
        {
            int healthGained = 5 * (int)Rarity + 1;
            player.Health += healthGained;
            Console.WriteLine($"You eat a apple…​ Delicious! +{healthGained} HP.");
        }

        public override string GetDescription()
        {
            return "A juicy apple that restores health.";
        }

        public override string ToString()
        {
            return base.ToString() + "Apple";
        }
    }
}
