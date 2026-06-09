using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Potions
{
    public abstract class Potion : Item
    {
        protected Potion(string name, double weight, Rarity rarity) : base(name, weight, rarity)
        {
        }
    }
}
