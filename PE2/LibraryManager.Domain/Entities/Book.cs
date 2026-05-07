using LibraryManager.Domain.Common;
using LibraryManager.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities
{
    public sealed class Book : LibraryItem, ILoanable
    {
        public string Author { get; }
        public string Isbn { get; }

        public Book(Guid id, string title, int? year, string location, string genre, string isbn, string author) : base(id, title, year, location, genre)
        {
            Author = author;
            Isbn = isbn;
        }

        public Book(BookResult bookResult, string location) : base(bookResult.Genre, location, bookResult.Title, bookResult.Year)
        {
            Author = bookResult.Authors;
            Isbn = bookResult.ISBN;
        }

        public bool IsAvailable => LoanedBy == null ? true : false;

        public string LoanedBy { get; set; }

        public DateTime? ReturnDate { get; set; }

        public void LoanTo(Member member, DateTime startDate)
        {
            LoanedBy = member.FullName;
            ReturnDate = startDate + TimeSpan.FromDays(28);
        }

        public void Return()
        {
            LoanedBy = null;
            ReturnDate = null;
        }
    }
}
