namespace StudentManager.Domain.Test
{
    public class StudentTest
    {
        [Fact]
        public void Constructor_FirstName_ArgumentException()
        {
            string firstName = "";
            string lastName = "Lastname";

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName));
        }


        [Fact]
        public void Constructor_ValidNames_CreateStudent()
        {
            string firstName = "Wietse";
            string lastName = "Gijbels";

            Student student = new Student(firstName, lastName);

            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(lastName, student.LastName);
        }

        [Fact]
        public void Constructor_LastName_ArgumentException()
        {
            string firstName = "Wietse";
            string lastName = "";
            
            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName));
        }

        [Fact]
        public void ToString_ValidStudent_ReturnsFullName()
        {
            Student student = new Student("Wietse", "Gijbels");

            string result = student.ToString();

            Assert.Equal("Wietse Gijbels", result);
        }
    }
}