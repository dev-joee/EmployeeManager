namespace EmployeesManager.Control;

using System.Data.Common;
using EmployeesManager.Data;
using EmployeesManager.Models;
using EmployeesManager.UI;
using Microsoft.EntityFrameworkCore;

public static class EmployeesController
{
    private static Employee _employee = new Employee();
    public static Department _department = new Department();

    public static void FetchAllEmployees()
    {
        EmployeesManager.UI.ShowAllEmployees.ShowAllEmployees_(_employee.GetEmployeesList());
    }

    public static void AddNewEmployee()
    {
        var DbContext = new ApplicationDbContext();

        string name = string.Empty;
        double salary = 0;
        int departmentId = 0;

        System.Console.Write("Employee Name: ");
        name = Console.ReadLine();

        System.Console.Write("Employee Salary: ");
        while (!double.TryParse(Console.ReadLine(), out salary))
        {
            System.Console.WriteLine("invalid salary, please entre a number.\n");
            System.Console.Write("Employee Salary: ");
        }

        ShowAllDepartments.ShowAllDepartments_(_department.GetDepartmentsList());

        while (true)
        {
            System.Console.Write("Choose Department ID: ");
            while(!int.TryParse(Console.ReadLine(), out departmentId))
            {
                System.Console.WriteLine("invalid input, please entre a number.");
                System.Console.Write("Choose Department ID: ");
            }
            
            if (!DbContext.Departments.Any(d => d.Id == departmentId))
            {
                System.Console.WriteLine($"no such Department with this ID: {departmentId}, please entre a correct one\n");
                continue;
            }

            break;
        }
        
        _employee.Add(name, salary, departmentId);
    }

    public static void ShowEmployeeCard()
    {
        int id;

        System.Console.Write("Entre Employee ID: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            System.Console.WriteLine("Invalid input, please entre a number.\n");
        }

        var DbContext = new ApplicationDbContext();
        var Employee = new Employee();

        Employee = DbContext.Employees.FirstOrDefault(e => e.Id == id);

        if (Employee == null)
        {
            System.Console.WriteLine($"the Employee with ID {id} does not exist in the database\n");
            return;
        }

        EmployeesManager.UI.ShowEmployeeCard.ShowEmployeeCard_(Employee);
    }

    public static void UpdateEmployee()
    {
        int id = 0;
        string name = string.Empty;
        double salary = 0;
        int departtmentid = 0;
        
        System.Console.Write("Entre Employee ID you want to update: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            System.Console.WriteLine("invalid input, please add a number.\n");            
            System.Console.Write("Entre Employee ID you want to update: ");
        }

        System.Console.Write("Entre New Employee Name: ");
        name = Console.ReadLine();

        System.Console.Write("Entre New Employee Salary: ");
        while (!double.TryParse(Console.ReadLine(), out salary))
        {
            System.Console.WriteLine("invalid input, please add a number.\n");            
            System.Console.Write("Entre New Employee Salary: ");
        }

        EmployeesManager.UI.ShowAllDepartments.ShowAllDepartments_(_department.GetDepartmentsList());
        System.Console.Write("Choose New (or existing) Department ID: ");
        while (!int.TryParse(Console.ReadLine(), out departtmentid))
        {
            System.Console.WriteLine("invalid input, please add a number.\n");            
            System.Console.Write("Choose New (or existing) Department ID: ");
        }
        
        _employee.Update(id, name, salary, departtmentid);
    }

    public static void DeleteEmployee()
    {
        int id = 0;
        var Employee = new Employee();
        var DbContext = new ApplicationDbContext();

        EmployeesManager.UI.ShowAllEmployees.ShowAllEmployees_(_employee.GetEmployeesList());

        System.Console.Write("Entre Employee ID you want to Delete: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            System.Console.WriteLine("invalid input, please add a number.\n");            
            System.Console.Write("Entre Employee ID you want to Delete: ");
        }

        Employee = DbContext.Employees.FirstOrDefault(e => e.Id == id);

        _employee.Delete(Employee);
    }
}
