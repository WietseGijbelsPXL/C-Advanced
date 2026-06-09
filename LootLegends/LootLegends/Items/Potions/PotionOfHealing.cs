using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Potions
{
    public class PotionOfHealing : Potion, IConsumable
    {
        public PotionOfHealing(Rarity rarity) : base("Potion of Healing", 0.5, rarity)
        {
        }

        public void Eat(Player player)
        {
            int gainedHealth = 20 * ((int)Rarity + 1);
            player.Speed += gainedHealth;
            Console.WriteLine($"You drink a potion of healing…​ You feel healthy! +{gainedHealth} health.");
        }

        public override string GetDescription()
        {
            return "A potion that restores health.";
        }

        public override string ToString()
        {
            return base.ToString() + "health potion";
        }
    }
}
