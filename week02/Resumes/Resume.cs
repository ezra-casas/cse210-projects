using System.Collections.Generic;

public class Resume{
    // attributes first
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // methods
    public void DisplayResume(){
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs){
            job.JobDetails();
        }
    }

}
