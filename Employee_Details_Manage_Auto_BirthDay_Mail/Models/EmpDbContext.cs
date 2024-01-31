using Microsoft.EntityFrameworkCore;

namespace Employee_Details_Manage_Auto_BirthDay_Mail.Models
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext()
        {

        }
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) 
        {
        }
        public DbSet<Employee> Employee { get; set;}
    }
}
