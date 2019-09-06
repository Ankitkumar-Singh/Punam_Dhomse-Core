using Assignment6.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment6.MyDbContext
{
    #region "AppDBContext"
    public class AppDBContext : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="AppDBContext"/> class.</summary>
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 
        }

        /// <summary>Gets or sets the employee.</summary>
        public DbSet<Employee> Employee { get; set; }

        /// <summary>Gets or sets the department.</summary>
        /// <value>The department.</value>
        public DbSet<Departments> Department { get; set; }
    }
    #endregion
}
