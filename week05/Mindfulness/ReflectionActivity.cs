public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What could you learn from this experience?",
        "What did you learn about yourself?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection";
        _description = "This activity helps you reflect on moments of strength and resilience.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}
