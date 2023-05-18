using BackendAssignment.Data;
using BackendAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssignment.Controllers
{
    [Route("api/Assignment")]
    [ApiController]
    public class AssignmentController :Controller
    {
        private readonly AssignmentDbContext dbContext;

        public AssignmentController(AssignmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> GetAssignmentsLive()
        {
            return dbContext.AssignmentDB.ToList();

        }

        [HttpPost]
        public ActionResult<Assignment> createAssignment([FromBody]Assignment assignment)
        {
            if(assignment == null) {
                return BadRequest(assignment);
            }
            assignment.Id = new Guid();
            dbContext.AssignmentDB.Add(assignment);
            dbContext.SaveChanges();
            return Ok(assignment);
        }
       



    }
}
