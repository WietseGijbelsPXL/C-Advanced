using LootLegends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LootLegends.Items
{
    public abstract class Item
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("naam mag niet leeg zijn.");
                }
            }
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = ((int)Rarity + 1) * 10; }
        }


        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value > 0)
                {
                    _weight = value;
                }
                else
                {
                    throw new ArgumentException("gewicht moet positief zijn.");
                }
            }
        }

        public Rarity Rarity { get; set; }

        public abstract string GetDescription();

        protected Item(string name, double weight, Rarity rarity)
        {
            Name = name;
            Weight = weight;
            Rarity = rarity;
        }

        public override string ToString()
        {
            return $"{Name} ({Rarity}) - Value: {Value}";
        }
    }
}
