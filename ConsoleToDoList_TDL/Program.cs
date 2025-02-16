using System.Net.Mime;

namespace ConsoleToDoList_TDL;

class Program
{
    static void Main(string[] args)
    {
        ConsoleUi.ShowMenu();
        Console.ReadLine();
        //TaskManager.LoadTasksFromFile();
    }
}