using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Swimming(new DateTime(2022, 11, 3), 13, 14),
            new Cycling(new DateTime(2022, 11, 3), 24, 18.4)
        };
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
