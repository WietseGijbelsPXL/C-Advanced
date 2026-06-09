using LootLegends.Interfaces;
using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Gems
{
    public abstract class Gem : Item, IGlowable
    {
        protected Gem(string name, double weight, Rarity rarity) : base(name, weight, rarity)
        {
        }

        public abstract void Glow();
    }
}
