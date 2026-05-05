using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo.Models
{
    public abstract class Instrument
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Condition { get; set; }
        public Store Shop { get; set; }
    }
}
