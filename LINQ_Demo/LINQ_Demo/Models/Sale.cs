using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo.Models
{
    public class Sale
    {
        public int InstrumentId { get; set; }
        public DateTime SoldAt { get; set; }
        public string CustomerName { get; set; }
    }
}
