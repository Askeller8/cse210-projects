using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by focusing on your breathing.")
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Let's begin the breathing exercise.");

        int remaining = Duration;
        while (remaining > 0)
        {
            int inhaleSeconds = Math.Min(4, remaining);
            for (int i = inhaleSeconds; i > 0; i--)
            {
                ClearCurrentLine();
                Console.Write($"Breathe in... {i} seconds left");
                Pause(1);
            }
            remaining -= inhaleSeconds;

            if (remaining <= 0)
                break;

            int exhaleSeconds = Math.Min(6, remaining);
            for (int i = exhaleSeconds; i > 0; i--)
            {
                ClearCurrentLine();
                Console.Write($"Breathe out... {i} seconds left");
                Pause(1);
            }
            remaining -= exhaleSeconds;
        }

        ClearCurrentLine();
    }
}
