using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the basic math program!");
        Console.WriteLine("This program will allow you to enter numbers and calculate their sum, as well as find their average,and largest number in the list.");
        List<int> numbers = new List<int>();
        int userInput = -1;
        while (userInput != 0)
        {
            Console.Write("Enter a number (or 0 to finish): ");

            string userResponse = Console.ReadLine();
            userInput = int.Parse(userResponse);

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        Console.WriteLine("The sum of the numbers is: " + numbers.Sum());
        Console.WriteLine("The average of the numbers is: " + numbers.Average());
        Console.WriteLine("The largest number is: " + numbers.Max());
    }
}