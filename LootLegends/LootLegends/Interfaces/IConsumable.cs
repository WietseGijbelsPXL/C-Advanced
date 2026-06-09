using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Interfaces
{
    public interface IConsumable
    {
        void Eat(Player player);
    }
}
