using EmployeesManager.Models;
using EmployeesManager.UI;
using EmployeesManager.Data;

namespace EmployeesManager.Control;

public class DepartmentsController
{
    private static Department _departments = new Department();

    public static void FetchAllDepartments()
    {
        EmployeesManager.UI.ShowAllDepartments.ShowAllDepartments_(_departments.GetDepartmentsList());
    }

    public static void AddNewDepartment()
    {
        string name = string.Empty;
        string location = string.Empty;

        System.Console.Write("Entre Department Name: ");
        name = Console.ReadLine();

        System.Console.Write("Entre Department Location: ");
        location = Console.ReadLine();

        _departments.Add(name, location);
    }

    public static void ShowDepartmentDetails()
    {
        int id;

        System.Console.Write("Entre Department ID: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            System.Console.WriteLine("Invalid input, please entre a number.\n");
        }

        var DbContext = new ApplicationDbContext();
        var Department = new Department();

        Department = DbContext.Departments.FirstOrDefault(d => d.Id == id);

        if (Department == null)
        {
            System.Console.WriteLine($"the Department with ID {id} does not exist in the database\n");
            return;
        }

        EmployeesManager.UI.ShowDepartmentDetails.ShowDepartmentDetails_(Department);
    }

    public static void UpdateDepartment()
    {
        int id = 0;
        string location = string.Empty;

        System.Console.Write("Entre Department ID you want to update: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            System.Console.WriteLine("invalid input, please add a number.\n");            
            System.Console.Write("Entre Department ID you want to update: ");
        }        

        System.Console.Write("Entre New Department Location: ");
        location = Console.ReadLine();

        _departments.Update(id, location);
    }
}
