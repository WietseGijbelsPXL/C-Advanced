using EmployeeTrainingManager.Domain;
using EmployeeTrainingManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Application
{
    public class EmployeeService
    {
        EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployeesAsync()
        {
            return _employeeRepository.GetAllAsync();
        }

        public Employee GetEmployeeByIdAsync(int id)
        {
            return _employeeRepository.GetByIdAsync(id);
        }

        public void AddEmployeeAsync(string firstName, string lastName)
        {
            _employeeRepository.AddAsync(new Employee() { FirstName = firstName, LastName = lastName });
        }

        public void UpdateEmployeeAsync(int id, string firstName, string lastName)
        {
            _employeeRepository.UpdateAsync(new Employee() { Id = id, FirstName = firstName, LastName = lastName });
        }

        public void DeleteEmployeeAsync(int id)
        {
            _employeeRepository.DeleteAsync(id);
        }
    }
}
