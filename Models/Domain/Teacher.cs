namespace EduPanel.Models.Domain
{
    public class Teacher
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateOnly? JoinDate { get; set; }
    }
}
