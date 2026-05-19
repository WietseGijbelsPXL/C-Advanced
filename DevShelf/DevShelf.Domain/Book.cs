using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; } // bijv. 4.5 op 5
        public int Pages { get; set; }
        public int Year { get; set; }
    }
}