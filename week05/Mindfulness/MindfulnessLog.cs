using System.Text;

public class MindfulnessLog
{
    private List<string> _entries = new List<string>();

    public void AddEntry(string activityName, int duration)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _entries.Add($"{timestamp} - Completed '{activityName}' for {duration} seconds");
    }

    public void ShowLog()
    {
        Console.WriteLine("\n--- Activity Log ---");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No activities logged yet.");
        }
        else
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }
        Console.WriteLine();
    }

    public void SaveToFile(string filename = "log.txt")
    {
        File.WriteAllLines(filename, _entries);
        Console.WriteLine($"Log saved to {filename}");
    }
}
