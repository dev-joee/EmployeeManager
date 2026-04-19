using Microsoft.EntityFrameworkCore;
using EmployeesManager.Models;

namespace EmployeesManager.Data;

public class ApplicationDbContext : DbContext
{
    private const string ConnectionString = "Data Source=localhost,1433;Initial Catalog=EmployeesManager;User ID=sa;Password=joe#2005;Encrypt=True;Trust Server Certificate=True;MultipleActiveResultSets=True;";
    public DbSet<Employee> Employees { set; get; }
    public DbSet<Department> Departments { set; get; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}
