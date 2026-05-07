using LibraryManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities
{
    public class Member : Entity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => FirstName + " " + LastName;

        public Member(Guid id,string firstName, string lastName) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
