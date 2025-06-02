namespace EduPanel.Models.DTO.Assignment
{
    public class AssignmentDto
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
