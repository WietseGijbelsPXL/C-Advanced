using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Gems
{
    public class Ruby : Gem, IGlowable
    {
        public Ruby(Rarity rarity) : base("Ruby", 0.04, rarity)
        {
        }

        public override string GetDescription()
        {
            return "A red gem";
        }

        public override void Glow()
        {
            Console.WriteLine("A gem that glows bright red.");
        }

        public override string ToString()
        {
            return base.ToString() + "ruby";
        }
    }
}
