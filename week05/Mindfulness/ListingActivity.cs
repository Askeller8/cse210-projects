using System;

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    private readonly string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public override void Start()
    {
        base.Start();
        ClearCurrentLine();
        Console.WriteLine("Let's begin the listing exercise.");

        Console.WriteLine("Take a moment to find a quiet space and reflect on the good things in your life.");
        Console.WriteLine("You will be prompted to list as many items as you can in a certain area. Try to list as many as possible within the time limit.");
        Console.WriteLine("Press Enter when you are ready to begin.");
        Console.ReadLine();
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");


        int remaining = Duration;
        Spinner spinner = new Spinner();

        while (remaining > 0)
        {
            spinner.Spin(1);
            Pause(1);
            remaining -= 1;
        }

        ClearCurrentLine();
    }
}