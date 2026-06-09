using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Gems
{
    public class Sapphire : Gem, IGlowable
    {
        public Sapphire(Rarity rarity) : base("Sapphire", 0.03, rarity)
        {
        }

        public override string GetDescription()
        {
            return "A blue gem";
        }

        public override void Glow()
        {
            Console.WriteLine("A gem that glows bright blue.");
        }

        public override string ToString()
        {
            return base.ToString() + "sapphire";
        }
    }
}
