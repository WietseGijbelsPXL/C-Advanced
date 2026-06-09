using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Potions
{
    public class PotionOfFlying : Potion, IConsumable, IGlowable
    {
        public PotionOfFlying(Rarity rarity) : base("Potion of Flying", 0.1, rarity)
        {
        }

        public void Eat(Player player)
        {
            int gainedSpeed = 3 * ((int)Rarity + 1);
            player.Speed += gainedSpeed;
            Console.WriteLine($"You drink a potion of flying…​ You feel lighter! +{gainedSpeed} Speed.");
        }

        public override string GetDescription()
        {
            return "A potion that grants the flight of Hermes.";
        }

        public void Glow()
        {
            Console.WriteLine("The potion glows bright blue.");
        }

        public override string ToString()
        {
            return base.ToString() + "flying potion";
        }
    }
}
