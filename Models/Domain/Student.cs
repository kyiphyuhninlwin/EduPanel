namespace EduPanel.Models.Domain
{
    public class Student
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

    }
}
