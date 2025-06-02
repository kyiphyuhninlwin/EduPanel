namespace EduPanel.Models.DTO.Assignment
{
    public class UpdateAssignmentRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
