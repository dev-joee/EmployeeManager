namespace EmployeesManager.Models;

using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Dynamic;
using EmployeesManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public void Add(string name, string location)
    {
        var Department = new Department()
        {
            Name = name,
            Location = location,
        };

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                DbContext.Departments.Add(Department);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error occured while adding Department [{Department.Name}] to the detabase, Error Message: {e.Message}");
            }
        }
    }

    public Department Retrieve(int id)
    {
        var Department = new Department();

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                Department = DbContext.Departments.FirstOrDefault(d => d.Id == id);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error occured while retrieving Department [{id}] to the detabase, Error Message: {e.Message}");
            }
        }
        
        return Department;
    }

    public void Update(int id, string location)
    {
        var Department = new Department();

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                Department = DbContext.Departments.FirstOrDefault(d => d.Id == id);

                if (Department == null)
                {
                    System.Console.WriteLine("This Department Does Not Exist\n");
                    return;    
                }   

                Department.Location = location; // the only thing we can update in a department is its location

                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error occured while Updating Department [{Department.Name}] to the detabase, Error Message: {e.Message}");
            }
        }
    }

    public List<Department> GetDepartmentsList()
    {
        List<Department> DepartmentsList = new List<Department>();

        using (var DbContext = new ApplicationDbContext())
        {
            try
            {
                DepartmentsList = DbContext.Departments.ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error occured while fetching Department List to the detabase, Error Message: {e.Message}");
            }
        }

        return DepartmentsList;
    }
}

