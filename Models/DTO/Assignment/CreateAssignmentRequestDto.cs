namespace EduPanel.Models.DTO.Assignment
{
    public class CreateAssignmentRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
