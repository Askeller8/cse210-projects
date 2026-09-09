using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next(1, 101);

        int userGuess = 0;
        
        while (userGuess != magicNumber)
        {
            Console.Write("Guess a magicnumber between 1 and 100: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out userGuess))
            {
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You've guessed the magic number!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}