using EduPanel.Models.Domain;

namespace EduPanel.Repositories.Interface
{
    public interface IAssignmentRepository
    {
        Task<Assignment> CreateAsync(Assignment assignment);
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment?> GetByID(int assignmentID);
        Task<Assignment?> UpdateAsync(Assignment assignment);
        Task<Assignment?> DeleteAsync(int assignmentID);
    }
}
