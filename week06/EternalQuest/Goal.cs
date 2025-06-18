public abstract class Goal
{
    protected string _name;
    protected int _points;
    protected string _description;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _points = points;
        _description = description;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetSaveString();
}
