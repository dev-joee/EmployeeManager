using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeesManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManager.Models;

public class Employee
{
    [Key]
    public int Id { set; get; }
    public string Name { set; get; }
    public double Salary { set; get; }
    [ForeignKey("Department")]
    public int DepartmentId { set; get; }
    public Department? Department { set; get; }

    public void Add(string name, double salary, int departmentId)
    {
        var Employee = new Employee()
        {
            Name = name ,
            Salary = salary ,
            DepartmentId = departmentId
        };

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                DbContext.Employees.Add(Employee);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"there was an error while adding Employee [{Employee.Name}] to the Database, error message: {e.Message}");                
            }
        }

        System.Console.WriteLine("Employee Added.\n");
    }

    public Employee Retrieve(int id)
    {
        var Employee = new Employee();

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                Employee = DbContext.Employees.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"there was an error while retrieving Employee [{id}] from the Database, error message: {e.Message}");                
            }
        }
        
        return Employee; // return null if not found 
    }
    
    public void Update(int id, string name, double salary, int departmentId)
    {
        var Employee = new Employee();

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                Employee = DbContext.Employees.FirstOrDefault(e => e.Id == id);
                
                if (Employee == null)
                {
                    System.Console.WriteLine($"Employee with id [{id}] is not found");    
                    return;
                }

                Employee.Name = name;
                Employee.Salary = salary;
                Employee.DepartmentId = departmentId;

                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"there was an error while retrieving Employee [{id}] from the Database, error message: {e.Message}");                
            }
        }

        System.Console.WriteLine("Employee Updated.\n");
    }

    public void Delete(Employee employee)
    {
        if (employee == null)
        {
            System.Console.WriteLine("This Employee does not Exist\n");
            return;
        }
        
        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                DbContext.Employees.Remove(employee);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"there was an error while removing Employee [{employee.Id}] from the Database, error message: {e.Message}");                
            }
        }

        System.Console.WriteLine("Employee Deleted.\n");
    }

    public List<Employee> GetEmployeesList()
    {
        List<Employee> EmployeesList = new List<Employee>();

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                EmployeesList = DbContext.Employees
                                .Include(p => p.Department)
                                .ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"there was an error while retrieving Employees List from the Database, error message: {e.Message}");                
            }
        }

        return EmployeesList;
    }
}
