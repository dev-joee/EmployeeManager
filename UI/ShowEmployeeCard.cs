namespace EmployeesManager.UI;

using EmployeesManager.Models;
public class ShowEmployeeCard
{
    public static void ShowEmployeeCard_(Employee Employee)
    {
        Console.Clear();

        System.Console.WriteLine("=== Employee Card ===");
        System.Console.WriteLine($"Employee Id: {Employee.Id}");
        System.Console.WriteLine($"Employee Name: {Employee.Name}");
        System.Console.WriteLine($"Employee Salary: {Employee.Salary}");
        System.Console.WriteLine($"Employee's Department ID: {Employee.DepartmentId}");
    
        System.Console.WriteLine("\n");
    }
}
