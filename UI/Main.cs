namespace EmployeesManager.UI;

public class Main
{
    public static void main()
    {
        int choice = 0;

        do
        {
            ShowMenu();
            
            choice = ValidateInput();
            
            DoAction(choice);
        
        } while (!HasQuit());
        
        System.Console.WriteLine("\n\nThanks For Using Employees Manager!!\n");
        Environment.Exit(0);
    }
    
    public static bool HasQuit()
    {
        string responce = string.Empty;
        bool HasQuit = false;

        while (true)
        {
            System.Console.Write("\ndo you want to continue? [Y/n]: ");
            responce = Console.ReadLine();

            responce.ToLower();
            
            if (responce == "y" || responce == string.Empty)
            {
                HasQuit = false;
                break;
            }
            else if (responce == "n")
            {
                HasQuit = true;
                break;
            }

            System.Console.WriteLine("invalid responce, please entre Y (to continue) or N (to quit).");
        }
        
        return HasQuit;
    }

    public static void ShowMenu()
    {
        Console.Clear();

        System.Console.WriteLine("Welcome to Employees Manager!!\n");
        System.Console.WriteLine("1- Fetch All Employees");
        System.Console.WriteLine("2- Add New Employee");
        System.Console.WriteLine("3- Show Employee Card");
        System.Console.WriteLine("4- Update Employee");
        System.Console.WriteLine("5- Delete Employee");
        System.Console.WriteLine("6- Fetch All Departments");
        System.Console.WriteLine("7- Add New Department");
        System.Console.WriteLine("8- Show Department Details");
        System.Console.WriteLine("9- Update Department");
        System.Console.WriteLine("0- Exit\n");
    }

    public static int ValidateInput()
    {
        int input = 0;
        
        bool valid = false;
        
        while (true)
        {
            System.Console.Write("\nChoice [1 - 9 | 0 to exit]: ");
            
            valid = int.TryParse(Console.ReadLine(), out input);  
            
            if (!valid)
            {
                System.Console.WriteLine("invalid input, please entre a number.");
                continue;
            }

            if (input > 9 || input < 0)
            {
                System.Console.WriteLine("invalid input range, please choose a number between 1 and 9.");
                continue;
            }

            break;
        }        

        return input;
    }

    public static void DoAction(int input)
    {
        switch (input)
        {
            case 1:
                EmployeesManager.Control.EmployeesController.FetchAllEmployees();
                break;

            case 2:
                EmployeesManager.Control.EmployeesController.AddNewEmployee();
                break;

            case 3:
                EmployeesManager.Control.EmployeesController.ShowEmployeeCard();
                break;
        
            case 4:
                EmployeesManager.Control.EmployeesController.UpdateEmployee();
                break;
        
            case 5:
                EmployeesManager.Control.EmployeesController.DeleteEmployee();
                break;
        
            case 6:
                EmployeesManager.Control.DepartmentsController.FetchAllDepartments();
                break;
        
            case 7:
                EmployeesManager.Control.DepartmentsController.AddNewDepartment();
                break;
        
            case 8:
                EmployeesManager.Control.DepartmentsController.ShowDepartmentDetails();
                break;
        
            case 9:
                EmployeesManager.Control.DepartmentsController.UpdateDepartment();
                break;
            case 0:
                System.Console.WriteLine("\n\nThanks For Using Employees Manager!!\n");
                Environment.Exit(0);
                break;
        }
    }
}
