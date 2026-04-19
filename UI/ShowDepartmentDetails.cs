namespace EmployeesManager.UI;

using EmployeesManager.Models;
public class ShowDepartmentDetails
{
    public static void ShowDepartmentDetails_(Department Department)
    {
        Console.Clear();

        System.Console.WriteLine("=== Department Details ===");
        System.Console.WriteLine($"Department ID: {Department.Id}");
        System.Console.WriteLine($"Department Name: {Department.Name}");
        System.Console.WriteLine($"Department location: {Department.Location}");

        System.Console.WriteLine("\n");
    }
}
