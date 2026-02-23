using StudentManager.Infrastructure;

namespace StudentManager.Application.Test
{
    public class StudentServiceTest
    {
        [Fact]
        public void AddStudent_ValidStudent_AddsStudent()
        {
            StudentRepository studentRepository = new StudentRepository();
            StudentService studentService = new StudentService(studentRepository);

            studentService.AddStudent("Wietse", "Gijbels");

            Assert.Single(studentService.GetAllStudents());
            Assert.Equal("Wietse", studentService.GetAllStudents()[0].FirstName);
            Assert.Equal("Gijbels", studentService.GetAllStudents()[0].LastName);
        }

        [Fact]
        public void AddStudent_DuplicateStudent_ThrowsInvalidOperationException()
        {
            StudentRepository studentRepository = new StudentRepository();
            StudentService studentService = new StudentService(studentRepository);

            studentService.AddStudent("Wietse", "Gijbels");

            Assert.Throws<InvalidOperationException>(() => studentService.AddStudent("Wietse", "Gijbels"));
        }

        [Fact]
        public void AddStudent_EmptyFirstName_ThrowsArgumentException()
        {
            // Arrange
            StudentRepository repository = new StudentRepository();
            StudentService service = new StudentService(repository);

            // Act + Assert
            Assert.Throws<ArgumentException>(() =>
            {
                service.AddStudent("", "Johnson");
            });
        }
    }
}