using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Domain
{
    public class Enrollment
    {
        public Employee Employee { get; set; }
        public int Id { get; set; }
        public bool IsBillable { get; set; }
        public Training Training { get; set; }

        public Enrollment()
        {
            
        }

        public Enrollment(Employee employee, int id, Training training)
        {
            Employee = employee;
            Id = id;
            Training = training;
        }
    }
}
