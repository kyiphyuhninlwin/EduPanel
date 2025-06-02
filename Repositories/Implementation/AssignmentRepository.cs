using EduPanel.Data;
using EduPanel.Models.Domain;
using EduPanel.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EduPanel.Repositories.Implementation
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Assignment> CreateAsync(Assignment assignment)
        {
            await context.Assignments.AddAsync(assignment);
            await context.SaveChangesAsync();

            return assignment;
        }

        public async Task<Assignment?> DeleteAsync(int assignmentID)
        {
            var exisitingAssignment = await context.Assignments.FirstOrDefaultAsync(a => a.ID == assignmentID);

            if(exisitingAssignment == null)
            {
                return null;
            }
            else
            {
                context.Assignments.Remove(exisitingAssignment);
                await context.SaveChangesAsync();
                return exisitingAssignment;
            }
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await context.Assignments.ToListAsync();
        }

        public async Task<Assignment?> GetByID(int assignmentID)
        {
            return await context.Assignments.FirstOrDefaultAsync(a => a.ID == assignmentID);
        }

        public async Task<Assignment?> UpdateAsync(Assignment assignment)
        {
            var exisitingAssignment = await context.Assignments.FirstOrDefaultAsync(a => a.ID == assignment.ID);

            if(exisitingAssignment != null)
            {
                context.Entry(exisitingAssignment).CurrentValues.SetValues(assignment);
                await context.SaveChangesAsync();
                return exisitingAssignment;
            }
            else
            {
                return null;
            }
        }
    }
}
