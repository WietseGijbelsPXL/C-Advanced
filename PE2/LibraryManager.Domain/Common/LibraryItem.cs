using LibraryManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Common
{
    public abstract class LibraryItem : Entity
    {
        public string Genre { get; }
        public string Location { get; }
        public string Title { get; }
        public int? Year { get; }

        protected LibraryItem(Guid id, string title, int? year, string location, string genre) : base(id)
        {
            Genre = genre;
            Location = location;
            Title = title;
            Year = year;
        }

        protected LibraryItem(string genre, string location, string title, int? year)
        {
            Genre = genre;
            Location = location;
            Title = title;
            Year = year;
        }

        public override string ToString()
        {
            return $""""
                {Title} ({Year}) 
                    Genre: {Genre}
                    Locatie: {Location}
                """";
        }
    }
}
