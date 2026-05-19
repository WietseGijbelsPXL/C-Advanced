using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevShelf.Domain;

namespace DevShelf.Application.Models
{
    public class BookResult
    {
        public IEnumerable<Book> Books { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}