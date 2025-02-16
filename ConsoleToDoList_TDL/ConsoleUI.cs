namespace ConsoleToDoList_TDL;

public class ConsoleUi
{
    public static void ShowMenu()
    {
        DisplayAppLogo();

        Console.WriteLine("Choose an action (1-5):");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. Remove task");
        Console.WriteLine("3. Mark task as completed");
        Console.WriteLine("4. Display all tasks");
        Console.WriteLine("5. Exit");

        GetUserInput();
    }

    static void GetUserInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            //add task
            case ConsoleKey.D1:
                InputTaskProperties();
                break;
            //remove task
            case ConsoleKey.D2:
                DisplayAppLogo();
                TaskManager.RemoveTask();
                break;
            //mark task
            case ConsoleKey.D3:
                DisplayAppLogo();
                TaskManager.MarkTaskAsCompleted();
                break;
            //display all tasks
            case ConsoleKey.D4:
                DisplayAppLogo();
                TaskManager.DisplayAllTasks();
                BackToMainMenu();
                break;
            case ConsoleKey.D5:
                Environment.Exit(0);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Try again.");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.White;
                ShowMenu();
                break;
        }
    }

    static void InputTaskProperties()
    {
        DisplayAppLogo();
        Console.WriteLine("Enter task description: ");
        string taskDescription = Console.ReadLine();
        
        TaskManager.AddTask(taskDescription);
    }

    public static void BackToMainMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("Press Enter to back menu...");

        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
        {
            ShowMenu();
        }
    }

    public static void PrintText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void PrintText(string text)
    {
        Console.WriteLine(text);
    }

    public static void DisplayAppLogo()
    {
        /*
        ████████╗██████╗ ██╗     
        ╚══██╔══╝██╔══██╗██║     
           ██║   ██║  ██║██║     
           ██║   ██║  ██║██║     
           ██║   ██████╔╝███████╗
           ╚═╝   ╚═════╝ ╚══════╝
         */
        Console.Clear();
        PrintText("----------------------------");
        PrintText("");
        PrintText("\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2557\u2588\u2588\u2588\u2588\u2588\u2588\u2557 \u2588\u2588\u2557     ", ConsoleColor.DarkRed);
        PrintText("\u255a\u2550\u2550\u2588\u2588\u2554\u2550\u2550\u255d\u2588\u2588\u2554\u2550\u2550\u2588\u2588\u2557\u2588\u2588\u2551     ", ConsoleColor.Red);
        PrintText("   \u2588\u2588\u2551   \u2588\u2588\u2551  \u2588\u2588\u2551\u2588\u2588\u2551     " , ConsoleColor.Yellow);
        PrintText("   \u2588\u2588\u2551   \u2588\u2588\u2551  \u2588\u2588\u2551\u2588\u2588\u2551     ", ConsoleColor.Green);
        PrintText("   \u2588\u2588\u2551   \u2588\u2588\u2588\u2588\u2588\u2588\u2554\u255d\u2588\u2588\u2588\u2588\u2588\u2588\u2588\u2557", ConsoleColor.DarkGreen);
        PrintText("   \u255a\u2550\u255d   \u255a\u2550\u2550\u2550\u2550\u2550\u255d \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u255d");
        PrintText("");
        PrintText("----------------------------");
        PrintText("");
    }
}