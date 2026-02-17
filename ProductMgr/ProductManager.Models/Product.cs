using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models
{
    public class Product
    {
        public int ID { get; set; }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Naam mag niet leeg zijn.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("Prijs moet positief zijn!");
                }
            }
        }

        private int _stock;

        public int Stock
        {
            get { return _stock; }
            set
            {
                if (value >= 0)
                {
                    _stock = value;
                }
                else
                {
                    throw new Exception("Prijs moet positief zijn!");
                }
            }
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
