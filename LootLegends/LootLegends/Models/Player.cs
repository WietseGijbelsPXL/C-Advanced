using LootLegends.Interfaces;
using LootLegends.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Models
{
    public class Player
    {
        public string Name { get; }
        public int Health { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Speed { get; set; } = 10;

        public List<Item> Inventory { get; } = new List<Item>();

        public Player(string name)
        {
            Name = name;
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }

        public void ShowInventory()
        {
            foreach (Item item in Inventory)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void UseConsumables()
        {
            foreach(Item item in Inventory)
            {
                if(item is IConsumable i)
                {
                    i.Eat(this);
                }
            }
        }

        public void ShowGlowables()
        {
            foreach (Item item in Inventory)
            {
                if (item is IGlowable i)
                {
                    i.Glow();
                }
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"\n{Name} Stats:");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Speed: {Speed}");
        }
    }
}
