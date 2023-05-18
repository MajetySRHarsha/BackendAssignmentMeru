using BackendAssignment.Data;
using BackendAssignment.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
//THis is the controller
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
            string dateFormat = "dd-MM-yyyy";
            List<Assignment> assignments = dbContext.AssignmentDB.ToList();
            List<Assignment> result = new List<Assignment>();
            foreach (Assignment assignment in assignments)
            {
                string inputDate = assignment.startDate.ToString();
                string outputDate = assignment.endDate.ToString();
                if (assignment == null)
                {
                    return NotFound();
                }
                DateTime currentDate = DateTime.Now;
                DateTime specifiedDate = DateTime.ParseExact(inputDate, dateFormat, null);

                DateTime specifiedDate1 = DateTime.ParseExact(outputDate, dateFormat, null);
                if (currentDate>=specifiedDate && currentDate<=specifiedDate1)
                {
                    result.Add(assignment);
                }
            }
            return Ok(result);

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
        
        [HttpGet]
        [Route("/api/AssignmentFiltered")]
        public ActionResult<IEnumerable<Assignment>> GetAssignmentsFiltered()
        {
            string dateFormat = "dd-MM-yyyy";
            List<Assignment> assignments = dbContext.AssignmentDB.ToList();
            List<Assignment> result = new List<Assignment>();
            foreach (Assignment assignment in assignments)
            {
                string inputDate = assignment.startDate.ToString();
                string outputDate = assignment.endDate.ToString();
                if (assignment == null)
                {
                    return NotFound();
                }
                DateTime currentDate = DateTime.Now;
                DateTime specifiedDate = DateTime.ParseExact(inputDate, dateFormat, null);

                DateTime specifiedDate1 = DateTime.ParseExact(outputDate, dateFormat, null);
                if (specifiedDate1 <= currentDate && specifiedDate <= currentDate)
                {
                    result.Add(assignment);
                }
            }
            return Ok(result);

        }




    }
}
