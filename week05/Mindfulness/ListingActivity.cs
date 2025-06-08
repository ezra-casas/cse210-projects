public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity helps you reflect on the good in your life.";
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You may begin listing now:");
        ShowSpinner(5);

        int count = 0;
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }
}
