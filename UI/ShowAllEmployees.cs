namespace EmployeesManager.UI;

using EmployeesManager.Models;

public class ShowAllEmployees
{
    public static void ShowAllEmployees_(List<Employee> Employees)
    {
        Console.Clear();

        if (Employees.Count() == 0)
        {
            System.Console.WriteLine("There are no Employees on the database\n");
            return;
        }
        
        System.Console.WriteLine("=== All Employees List ===\n");

        foreach(var emp in Employees)
        {
            System.Console.WriteLine("---");
            System.Console.WriteLine($"Employee ID: {emp.Id}");            
            System.Console.WriteLine($"Employee Name: {emp.Name}");            
            System.Console.WriteLine($"Employee Salary: {emp.Salary}");            
            System.Console.WriteLine($"Employee DepartmentId: {emp.DepartmentId}");            
            System.Console.WriteLine("---");
        }
        
        System.Console.WriteLine("\n");
    }
}
