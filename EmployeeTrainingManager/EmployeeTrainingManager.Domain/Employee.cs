using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Domain
{
    public class Employee
    {
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            
        }

        public Employee(string firstName, int id, string lastName)
        {
            FirstName = firstName;
            Id = id;
            LastName = lastName;
        }
    }
}
