using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;

namespace Sample.Repositories.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> employees { get; set; }
}
