public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through slow breathing.";
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("Breathe in...");
            Countdown(4);
            elapsed += 4;

            if (elapsed >= _duration) break;

            Console.WriteLine("Breathe out...");
            Countdown(4);
            elapsed += 4;
        }
    }
}
