using System;

class Program
{
    static int ReadInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a whole number.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Please select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        int choice;
        do
        {
            choice = ReadInteger("Enter your choice (1-3): ");
            if (choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number greater than 0 and less than 4.");
            }
        } while (choice < 1 || choice > 3);

        Activity activity = null;

        switch (choice)
        {
            case 1:
                activity = new BreathingActivity();
                break;
            case 2:
                activity = new ReflectingActivity();
                break;
            case 3:
                activity = new ListingActivity();
                break;
        }

        activity.Start();
        activity.End();
    }
}