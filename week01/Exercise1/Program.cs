using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your first name: ");
        string FirstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string LastName = Console.ReadLine();

        Console.WriteLine($"Your name is {LastName}, {FirstName} {LastName}");
    }
}