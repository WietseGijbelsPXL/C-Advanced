using LibraryManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities
{
    public sealed class Game : LibraryItem, ILoanable
    {
        public int? Pegi { get; }
        public string Platform { get; }

        public bool IsAvailable => LoanedBy == null ? true : false;

        public string LoanedBy { get; set; }

        public DateTime? ReturnDate { get; set; }

        public Game(Guid id, string title, int? year, string location, string genre, int? pegi, string platform): base(id, title, year, location, genre)
        {
            Pegi = pegi;
            Platform = platform;
        }

        public void LoanTo(Member member, DateTime startDate)
        {
            LoanedBy = member.FullName;
            ReturnDate = startDate + TimeSpan.FromDays(14);
        }

        public void Return()
        {
            LoanedBy = null;
            ReturnDate = null;
        }
    }
}
