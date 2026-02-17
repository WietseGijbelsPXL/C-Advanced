using StudentManager.Domain;
using StudentManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application
{
    public class StudentService
    {
        private readonly StudentRepository _repository;

        public StudentService(StudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudent(string firstName, string lastName)
        {
            Student newStudent = new Student(firstName, lastName);

            bool alreadyExists = _repository.All().Any(s =>
                s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
                throw new InvalidOperationException("Deze student bestaat al.");

            _repository.Add(newStudent);
        }

        public List<Student> GetAllStudents()
        {
            return _repository.All();
        }
    }
}
