using System.Text.Json;
using System.Text.Json.Serialization;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }
    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveJson(string filename)
    {
        string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, jsonString);
    }

    public void LoadFromJson(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<Entry>>(json);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            entries.Add(Entry.FromFileFormat(line));
        }
    }
}
