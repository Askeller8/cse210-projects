using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);

        while (true)
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int duration) && duration > 0)
            {
                _duration = duration;
                break;
            }

            Console.WriteLine("Invalid input. Please enter a positive whole number of seconds.");
        }

        Console.WriteLine("Get ready...");
        Pause(3);
    }

    protected int Duration => _duration;

    public void End()
    {
        Console.WriteLine($"Good job! You have completed the {_name} Activity for {_duration} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            System.Threading.Thread.Sleep(1000);
        }
    }

    protected void ClearCurrentLine()
    {
        Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
    }
}