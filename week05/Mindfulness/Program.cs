/*
This is a mindfulness app that allows users to perform various activities such as breathing, reflection, and listing.
All completed activities are tracked with a timestamp,
name of the activity, and duration.
- Users can view the session's activity log from the main menu.
- Upon quitting, the session log is saved to a file
named "log.txt" automatically.

Added ReflectionActivity
This provides a reflective activity for users to think about their thoughts and feelings.
 */

using System;


class Program
{
    static void Main(string[] args)
    {
        var log = new MindfulnessLog();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Save and Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                log.SaveToFile(); // Save on exit
                break;
            }
            else if (choice == "4")
            {
                log.ShowLog();
                Console.WriteLine("Press Enter to return...");
                Console.ReadLine();
            }
            else
            {
                MindfulnessActivity activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    _ => null
                };

                if (activity == null)
                {
                    Console.WriteLine("Invalid choice.");
                    Thread.Sleep(2000);
                }
                else
                {
                    activity.SetLog(log);
                    activity.Start();
                }
            }
        }
    }
}
