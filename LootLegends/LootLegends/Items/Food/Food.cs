using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items.Food
{
    public abstract class Food : Item
    {
        protected Food(string name, double weight, Rarity rarity) : base(name, weight, rarity)
        {
        }
    }
}
