using System;

public class ReflectingActivity : Activity
{
    private readonly string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on your day and your experiences.")
    {
    }

    public override void Start()
    {
        base.Start();
        ClearCurrentLine();
        Console.WriteLine("");
        Console.WriteLine("Let's begin the reflecting exercise.");

        Console.WriteLine("Take a moment to think about your day and consider what went well.");
        Console.WriteLine("You will be prompted to reflect on a specific experience.");
        Console.WriteLine("Press Enter when you are ready to begin.");
        Console.ReadLine();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        int elapsed = 0;
        Spinner spinner = new Spinner();
        string lastQuestion = "";

        while (elapsed < Duration)
        {
            string question = _questions[random.Next(_questions.Length)];
            while (question == lastQuestion && _questions.Length > 1)
            {
                question = _questions[random.Next(_questions.Length)];
            }

            lastQuestion = question;
            Console.WriteLine($"Question: {question}");

            int delay = Math.Min(5, Duration - elapsed);
            ClearCurrentLine();
            spinner.Spin(delay);
            Console.WriteLine();
            elapsed += delay;
        }

        ClearCurrentLine();
    }
}