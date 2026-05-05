using EmployeeTrainingManager.Domain;
using EmployeeTrainingManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Application
{
    public class EnrollmentService
    {
        EnrollmentRepository _EnrollmentRepository;

        public EnrollmentService(EnrollmentRepository enrollmentRepository)
        {
            _EnrollmentRepository = enrollmentRepository;
        }

        public IEnumerable<Enrollment> GetAllEnrollmentsAsync()
        {
            return _EnrollmentRepository.GetAllAsync();
        }

        public Enrollment GetEnrollmentByIdAsync(int id)
        {
            return _EnrollmentRepository.GetByIdAsync(id);
        }

        public IEnumerable<Enrollment> GetEnrollmentsByEmployeeIdAsync(int employeeId)
        {
            return _EnrollmentRepository.GetByEmployeeIdAsync(employeeId);
        }

        public void EnrollEmployeeAsync(int employeeId, string trainingId, bool isBillable)
        {
            _EnrollmentRepository.AddAsync(new Enrollment() { });
        }

        public void DeleteEnrollmentAsync(int id)
        {
            _EnrollmentRepository.DeleteAsync(id);
        }
    }
}
