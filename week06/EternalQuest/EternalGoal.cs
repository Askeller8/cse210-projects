public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never completed, so no action is needed here.
    }
    public override bool IsComplete()
    {
        // Eternal goals are never completed, so always return false.
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}:{_description}:{_points}";
    }
}