namespace EmployeesManager.UI;

using EmployeesManager.Models;
public class ShowAllDepartments
{
    public static void ShowAllDepartments_(List<Department> Departments)
    {
        Console.Clear();
        
        System.Console.WriteLine("=== All Departments List ===\n");

        if (Departments.Count() == 0)
        {
            System.Console.WriteLine("There are no Departments on the database\n");
            return;
        }

        foreach(var dep in Departments)
        {
            System.Console.WriteLine($"Department ID: {dep.Id}");            
            System.Console.WriteLine($"Department Name: {dep.Name}");            
        }
        
        System.Console.WriteLine("\n");
    }
}
