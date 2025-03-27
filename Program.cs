namespace Aufgaben;

public class Program
{
    static void Main()
    {
        bool repeat = true;
        while (repeat)
        {
            Console.WriteLine("What do you want to do?" +
                              "\n1. Show Tasks" +
                              "\n2. Add Task" +
                              "\n3. Complete Task" +
                              "\n4. Delete Task\n");
            Console.Write("Enter a number: ");

            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "1":
                case "show":
                    TaskItem.ShowTasks();
                    break;
                case "2":
                case "add":
                    TaskItem.AddTask();
                    break;
                case "3":
                case "complete":
                    TaskItem.CompleteTask();
                    break;
                case "4":
                case "delete":
                    TaskItem.DeleteTask();
                    break;
                default:
                    Console.WriteLine("Input not valid. Please enter a number!");
                    break;
            }
            Console.Write("Do you want to continue? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "n")
            {
                repeat = false;
            }
        }
    }
}