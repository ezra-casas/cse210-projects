
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry() { }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public void Display()
    {
        Console.WriteLine($"{Date}");
        Console.WriteLine($"{Prompt}");
        Console.WriteLine($"{Response}");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split("|");
        return new Entry(parts[1], parts[2], parts[0]);
    }
}
