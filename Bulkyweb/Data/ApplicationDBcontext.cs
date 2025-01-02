using Microsoft.EntityFrameworkCore;
using Bulkyweb.Models.Entities;

namespace Bulkyweb.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
