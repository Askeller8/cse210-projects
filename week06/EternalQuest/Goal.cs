public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public int GetPoints()
    {
        return _points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    // Abstract method to be implemented by derived classes
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Virtual method to display goal information
    public virtual string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "[X]" : "[ ]";
        return $"{statusSymbol} {_shortName} ({_description})";
    }
}