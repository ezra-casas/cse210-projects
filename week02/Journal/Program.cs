// Enhancements:
// This version uses JSON serialization to save/load journal entries,
// improving structure and integration with other systems.
// resources used:
// https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to
// https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please choose one of the following:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(prompt, response, date));
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJson($"{saveFilename + ".json"}");
                    break;

                case "4":
                    Console.Write("Enter filename to load (with .json): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromJson(loadFilename);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please type a number between 1-5.");
                    break;
            }
            Console.WriteLine($"Current save/load path: {Directory.GetCurrentDirectory()}");
            Console.WriteLine();
        }
    }
}
