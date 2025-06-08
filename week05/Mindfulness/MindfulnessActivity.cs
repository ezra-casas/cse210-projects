public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected MindfulnessLog _log;

    public void SetLog(MindfulnessLog log)
    {
        _log = log;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n{_description}");
        Console.Write("Enter duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity();
        End();
    }

    protected void End()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity.");
        _log?.AddEntry(_name, _duration); // Log activity here
        ShowSpinner(3);
    }


    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void RunActivity();
}
