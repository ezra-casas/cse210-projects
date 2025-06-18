public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetDetailsString() =>
        $"[∞] {_name} ({_description})";

    public override string GetSaveString() =>
        $"EternalGoal|{_name}|{_description}|{_points}";
}
