using BackendAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAssignment.Data
{
    public class AssignmentDbContext:DbContext
    {
        public AssignmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Assignment> AssignmentDB { get; set; }
    }
}
