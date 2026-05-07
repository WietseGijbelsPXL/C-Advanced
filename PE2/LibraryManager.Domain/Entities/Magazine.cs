using LibraryManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities
{
    public class Magazine : LibraryItem
    {
        public int? IssueNumber { get; }

        public Magazine(Guid id, string title, int? year, string location, string genre, int? issueNumber): base(id, title, year, location, genre)
        {
            IssueNumber = issueNumber;
        }

    }
}
