using EduPanel.Models.Domain;
using EduPanel.Models.DTO.Assignment;
using EduPanel.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepository assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment(CreateAssignmentRequestDto request)
        {
            // Map Dto to Domain
            var assignment = new Assignment
            {
                Name = request.Name,
                Description = request.Description,
                DueDate = request.DueDate
            };

            await assignmentRepository.CreateAsync(assignment);

            // Map Domain to Dto
            var response = new AssignmentDto
            {
                Name = assignment.Name,
                Description = assignment.Description,
                DueDate = assignment.DueDate
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssignments()
        {
            var assignments = await assignmentRepository.GetAllAsync();

            // Map Domain to Dto
            var response = new List<AssignmentDto>();
            foreach (var assignment in assignments)
            {
                response.Add(new AssignmentDto
                {
                    Name = assignment.Name,
                    Description = assignment.Description,
                    DueDate = assignment.DueDate
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{assignmentID:int}")]
        public async Task<IActionResult> GetAssignmentByID([FromRoute] int assignmentID)
        {
            var assignment = await assignmentRepository.GetByID(assignmentID);

            if (assignment != null)
            {
                var response = new AssignmentDto
                {
                    Name = assignment.Name,
                    Description = assignment.Description,
                    DueDate = assignment.DueDate
                };

                return Ok(response);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpPut]
        [Route("{assignmentID:int}")]
        public async Task<IActionResult> UpdateAssignment([FromRoute] int assignmentID, UpdateAssignmentRequestDto request)
        {
            var assignment = new Assignment
            {
                ID = assignmentID,
                Name = request.Name,
                Description = request.Description,
                DueDate = request.DueDate,
            };

            assignment = await assignmentRepository.UpdateAsync(assignment);

            if(assignment == null) 
            {
                return NotFound();
            }

            var response = new AssignmentDto
            {
                ID = assignment.ID,
                Name = assignment.Name,
                Description = assignment.Description,
                DueDate = assignment.DueDate
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{assignmentID:int}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] int assignmentID)
        {
            var assignment = await assignmentRepository.DeleteAsync(assignmentID);

            if (assignment == null)
            {
                return NotFound();
            }

            var response = new AssignmentDto
            {
                Name = assignment.Name,
                Description = assignment.Description,
                DueDate = assignment.DueDate
            };

            return Ok(response);
        }
    }
}
