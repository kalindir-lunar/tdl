using System.Text.Json;

namespace ConsoleToDoList_TDL;

public class TaskManager
{
    static List<Task> tasks = new List<Task>();

    public static void AddTask(string taskDescription)
    {
        LoadTasksFromFile();
        Task task = new Task(taskDescription);
        tasks.Add(task);
        SaveTasksToFile(tasks);
        
        ConsoleUi.PrintText($"Adding task {taskDescription} successfully!", ConsoleColor.Green);
        Thread.Sleep(1500);

        ConsoleUi.ShowMenu();
    }

    public static void EditTask()
    {
        LoadTasksFromFile();
        if (tasks.Count == 0)
        {
            ConsoleUi.PrintText("There are no tasks to edit.");
            ConsoleUi.BackToMainMenu();
        }
        
        ConsoleUi.PrintText("Input task number to edit and press Enter or any other key to exit:");
        DisplayAllTasks();
        
        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
        }
        else
        {
            ConsoleUi.PrintText("Please enter a number!", ConsoleColor.Red);
            ConsoleUi.ShowMenu();
        }
        
        LoadTasksFromFile();
        
        if (taskNumber <= tasks.Count && taskNumber >= 0)
        {
            string oldDescription = tasks[taskNumber - 1].Description;
            ConsoleUi.PrintText("Input new description for chosen task:");
            string newDescription = Console.ReadLine();
            tasks[taskNumber - 1].Description = newDescription;
            SaveTasksToFile(tasks);
            
            ConsoleUi.PrintText($"Edit task {oldDescription} successfully to {newDescription}!", ConsoleColor.Green);
            Thread.Sleep(1500);
        }
        else
        {
            ConsoleUi.PrintText("Task number is out of tasks range!", ConsoleColor.Red);
            Thread.Sleep(1500);
            ConsoleUi.ShowMenu();
        }

        ConsoleUi.ShowMenu();
    }

    public static void RemoveTask()
    {
        LoadTasksFromFile();
        if (tasks.Count == 0)
        {
            ConsoleUi.PrintText("There are no tasks to remove.");
            ConsoleUi.BackToMainMenu();
        }
        
        ConsoleUi.PrintText("Input task number to remove and press Enter or any other key to exit:");
        DisplayAllTasks();

        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
        }
        else
        {
            ConsoleUi.PrintText("Please enter a number!", ConsoleColor.Red);
            Thread.Sleep(1500);
            ConsoleUi.ShowMenu();
        }

        LoadTasksFromFile();

        if (taskNumber <= tasks.Count && taskNumber >= 0)
        {
            string taskDescription = tasks[taskNumber - 1].Description;
            tasks.Remove(tasks[taskNumber - 1]);
            SaveTasksToFile(tasks);
            
            ConsoleUi.PrintText($"Removing task {taskDescription} successfully!", ConsoleColor.Green);
            Thread.Sleep(1500);
        }
        else
        {
            ConsoleUi.PrintText("Task number is out of tasks range!", ConsoleColor.Red);
            Thread.Sleep(1500);
            ConsoleUi.ShowMenu();
        }

        ConsoleUi.ShowMenu();
    }

    public static void MarkTaskAsCompleted()
    {
        LoadTasksFromFile();
        if (tasks.Count == 0)
        {
            ConsoleUi.PrintText("There are no tasks to mark as completed.");
            ConsoleUi.BackToMainMenu();
        }
        
        ConsoleUi.PrintText("Input task number to complete and press Enter or any other key to exit:");
        DisplayAllTasks();
        
        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
        }
        else
        {
            ConsoleUi.PrintText("Please enter a number!", ConsoleColor.Red);
            ConsoleUi.ShowMenu();
        }

        LoadTasksFromFile();

        if (taskNumber <= tasks.Count && taskNumber >= 0)
        {
            string taskDescription = tasks[taskNumber - 1].Description;
            tasks[taskNumber - 1].IsCompleted = true;
            SaveTasksToFile(tasks);
            
            ConsoleUi.PrintText($"Completed task {taskDescription} successfully!", ConsoleColor.Green);
            Thread.Sleep(1500);
        }
        else
        {
            ConsoleUi.PrintText("Task number is out of tasks range!", ConsoleColor.Red);
            ConsoleUi.ShowMenu();
        }

        ConsoleUi.ShowMenu();
    }

    public static void DisplayAllTasks()
    {
        LoadTasksFromFile();
        
        if (tasks.Count == 0)
        {
            ConsoleUi.PrintText("There are no tasks to display.");
            ConsoleUi.BackToMainMenu();
        }
        ConsoleUi.PrintText("Task List:");
        
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].IsCompleted)
            {
                ConsoleUi.PrintText($"{i + 1}. {tasks[i].Description} (DONE)", ConsoleColor.Yellow);
            }
            else ConsoleUi.PrintText($"{i + 1}. {tasks[i].Description}");
        }
    }

    public static void SaveTasksToFile(List<Task> tasks)
    {
        string updateJson = JsonSerializer.Serialize(tasks);
        File.WriteAllText("tasks.json", updateJson);
    }

    public static void LoadTasksFromFile()
    {
        if (File.Exists("tasks.json"))
        {
            string json = File.ReadAllText("tasks.json");

            if (json != "")
            {
                tasks = JsonSerializer.Deserialize<List<Task>>(json);
            }
        }
    }
}