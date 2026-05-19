using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Models
{
    public class BookRequest
    {
        public string TitleFilter { get; set; }
        public string AuthorFilter { get; set; }
        public double RatingFilter { get; set; }
        public int Page { get; set; }
        public int BooksPerPage { get; set; } = 10;
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; } = "asc";
    }
}