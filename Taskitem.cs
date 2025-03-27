namespace Aufgaben;

public class TaskItem
{
    private string Title { get; }
    private bool IsCompleted { get; set; }

    private static List<TaskItem> _taskCollection = [];
    private const string FilePath = @"C:\Users\Erdin Zeller\RiderProjects\cstest\Aufgaben\AllTasks.txt";

    private TaskItem(string title, bool isCompleted)
    {
        Title = title;
        IsCompleted = isCompleted;
    }

    private static string ReturnCapitalizedName(string name)
    {
        name = char.ToUpper(name[0]) + name.Substring(1);
        return name;
    }

    private string ReturnTextToString(string name, bool isCompleted)
    {
        return $"{name}: {isCompleted}";
    }

    private static void OverwriteAllText(List<TaskItem> tasks)
    {
        File.WriteAllText(FilePath, "");
        for (int i = 0; i < tasks.Count; i++)
        {
            File.AppendAllText(FilePath,
                $"{tasks[i].Title}: {tasks[i].IsCompleted}" +
                (i < tasks.Count - 1 ? Environment.NewLine : ""));
        }
    }

    private static List<TaskItem> ReturnLinesFromFile()
    {
        _taskCollection.Clear();
        var lines = File.ReadAllLines(FilePath)
            .Where(x => !string.IsNullOrWhiteSpace(x));
        
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            
            var fileTitle = parts[0];
            var fileIsCompleted = bool.Parse(parts[1]);
            _taskCollection.Add(new TaskItem(fileTitle, fileIsCompleted));
        }

        return _taskCollection;
    }
    public static void ShowTasks()
    {
        _taskCollection = ReturnLinesFromFile();
        foreach (var task in _taskCollection)
        {
            Console.WriteLine($"{task.Title}: {task.IsCompleted}");
        }
    }
    public static void AddTask()
    {
        Console.Write("What is your new task called?: ");
        var newTaskName = Console.ReadLine();
        if (newTaskName != null)
        {
            var newTask = new TaskItem(newTaskName, false);
            if (new FileInfo(FilePath).Length == 0)
            {
                File.AppendAllText(FilePath, newTask.ReturnTextToString
                                                (ReturnCapitalizedName(newTaskName), false));
            }
            else
            {
                File.AppendAllText(FilePath, Environment.NewLine
                                             + newTask.ReturnTextToString
                                                 (ReturnCapitalizedName(newTaskName), false));
            }
        }
    }

    public static void CompleteTask()
    {
        Console.Write("What Task did you complete?: ");
        var completedTaskName = Console.ReadLine();

        while (completedTaskName == null)
        {
            Console.WriteLine("You need to enter a Task name!");
            completedTaskName = Console.ReadLine();
        }
        
        completedTaskName = ReturnCapitalizedName(completedTaskName);
        _taskCollection = ReturnLinesFromFile();
        
        TaskItem? foundTask = _taskCollection.FirstOrDefault(t => t.Title == completedTaskName);
        if (foundTask != null)
        {
            foundTask.IsCompleted = true;
            OverwriteAllText(_taskCollection);
        }
        else
        {
            Console.WriteLine("Task could not be found!");
        }
    }

    public static void DeleteTask()
    {
        Console.Write("What Task do you want to remove?: ");
        var deleteTaskName = Console.ReadLine();
        while (deleteTaskName == null)
        {
            Console.WriteLine("You need to enter a Task name!");
            deleteTaskName = Console.ReadLine();
        }
        
        deleteTaskName = ReturnCapitalizedName(deleteTaskName);
        _taskCollection = ReturnLinesFromFile();
        
        TaskItem? foundTask = _taskCollection.FirstOrDefault(t => t.Title == deleteTaskName);
        if (foundTask != null)
        {
            _taskCollection.Remove(foundTask);
            OverwriteAllText(_taskCollection);
        }
        else
        {
            Console.WriteLine("Task could not be found!");
        }
        
    }
}


