using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private List<int> _unlockedMilestones;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _unlockedMilestones = new List<int>();
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. View Cat Rewards Gallery");
            Console.WriteLine("7. Exit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            if (choice == null)
            {
                running = false;
                continue;
            }

            if (!int.TryParse(choice, out int menuChoice) || menuChoice < 1 || menuChoice > 7)
            {
                Console.WriteLine("Enter a menu number from 1 to 7.");
                continue;
            }

            switch (menuChoice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: DisplayCatGallery(); break;
                case 7: running = false; break;
            }

        }

    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        CheckCatMilestones();
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        if (!ReadInt("Which type of goal would you like to create? ", 1, 3, out int typeChoice))
        {
            return;
        }

        if (!ReadText("What is the name of your goal? ", out string name, true) ||
            !ReadText("What is a short description of it? ", out string description, true) ||
            !ReadInt("What is the amount of points associated with this goal? ", 0, int.MaxValue, out int points))
        {
            return;
        }

        if (typeChoice == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            if (!ReadInt("How many times must this goal be completed for a bonus? ", 1, int.MaxValue, out int target) ||
                !ReadInt("What is the bonus for completing it that many times? ", 0, int.MaxValue, out int bonus))
            {
                return;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record yet.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        if (!ReadInt("Which goal did you accomplish? ", 1, _goals.Count, out int goalNumber))
        {
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];
        selectedGoal.RecordEvent();

        int pointsEarned = selectedGoal.GetPoints();
        // chech if checklist goal and if completed, add bonus points
        if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            pointsEarned += checklistGoal.GetBonus();
        }

        _score += pointsEarned;
        Console.WriteLine($"ongratulations! You have earned {pointsEarned} points!");
        CheckCatMilestones();
    }
    public void SaveGoals()
    {
        if (!ReadText("What is the filename for the goal file? ", out string filename))
        {
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }
        catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException || exception is ArgumentException || exception is NotSupportedException)
        {
            Console.WriteLine($"Could not save the goal file: {exception.Message}");
            return;
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        if (!ReadText("What is the filename for the goal file? ", out string filename))
        {
            return;
        }

        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
        }
        catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException || exception is ArgumentException || exception is NotSupportedException)
        {
            Console.WriteLine($"Could not load the goal file: {exception.Message}");
            return;
        }

        if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore) || loadedScore < 0)
        {
            Console.WriteLine("The goal file is empty or has an invalid score.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();
        for (int i = 1; i < lines.Length; i++)
        {
            if (TryParseGoal(lines[i], out Goal goal))
            {
                loadedGoals.Add(goal);
            }
            else
            {
                Console.WriteLine($"Skipping invalid goal record on line {i + 1}.");
            }
        }

        _goals.Clear();
        _goals.AddRange(loadedGoals);
        _score = loadedScore;
        Console.WriteLine("Goals loaded successfully.");
    }

    private static bool ReadInt(string prompt, int minimum, int maximum, out int value)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null)
            {
                value = 0;
                return false;
            }

            if (int.TryParse(input, out value) && value >= minimum && value <= maximum)
            {
                return true;
            }

            Console.WriteLine($"Enter a whole number from {minimum} to {maximum}.");
        }
    }

    private static bool ReadText(string prompt, out string value, bool rejectColon = false)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null)
            {
                value = string.Empty;
                return false;
            }

            input = input.Trim();
            if (!string.IsNullOrWhiteSpace(input) && (!rejectColon || !input.Contains(':')))
            {
                value = input;
                return true;
            }

            Console.WriteLine(rejectColon
                ? "Enter a value that is not blank and does not contain a colon."
                : "This value cannot be blank.");
        }
    }

    private static bool TryParseGoal(string line, out Goal goal)
    {
        goal = null;
        string[] parts = line.Split(':');

        if (parts.Length < 4 || string.IsNullOrWhiteSpace(parts[1]) || string.IsNullOrWhiteSpace(parts[2]))
        {
            return false;
        }

        if (parts[0] == "SimpleGoal" && parts.Length == 5 &&
            int.TryParse(parts[3], out int simplePoints) && simplePoints >= 0 &&
            bool.TryParse(parts[4], out bool isComplete))
        {
            goal = new SimpleGoal(parts[1], parts[2], simplePoints, isComplete);
            return true;
        }

        if (parts[0] == "EternalGoal" && parts.Length == 4 &&
            int.TryParse(parts[3], out int eternalPoints) && eternalPoints >= 0)
        {
            goal = new EternalGoal(parts[1], parts[2], eternalPoints);
            return true;
        }

        if (parts[0] == "ChecklistGoal" && parts.Length == 7 &&
            int.TryParse(parts[3], out int checklistPoints) && checklistPoints >= 0 &&
            int.TryParse(parts[4], out int bonus) && bonus >= 0 &&
            int.TryParse(parts[5], out int target) && target > 0 &&
            int.TryParse(parts[6], out int amountCompleted) && amountCompleted >= 0)
        {
            goal = new ChecklistGoal(parts[1], parts[2], checklistPoints, target, bonus, amountCompleted);
            return true;
        }

        return false;
    }

    // Custom Feature: Cat Reward Milestones
    private void CheckCatMilestones()
    {
        int[] milestones = { 300, 750, 1000, 1500, 2000 };
        string[] catPictures =
        {
            "Cat Photo #1: Porthos' First Day",
            "Cat Photo #2: Tarzan's First Christmas",
            "Cat Photo #3: Both cats on the Recliner",
            "Cat Photo #4: Me and My Buddy",
            "Cat Photo #5: Not a cat"
        };
        for (int i = 0; i < milestones.Length; i++)
        {
            if (_score >= milestones[i] && !_unlockedMilestones.Contains(milestones[i]))
            {
                _unlockedMilestones.Add(milestones[i]);
                Console.WriteLine($"\n===============================================");
                Console.WriteLine($"Congratulations! You've reached {milestones[i]} points and unlocked a new cat picture!");
                Console.WriteLine(catPictures[i]);
                Console.WriteLine($"===============================================");
            }
        }
    }
    public void DisplayCatGallery()
    {
        Console.WriteLine("\nCat Rewards Gallery:");
        int[] milestones = { 300, 750, 1000, 1500, 2000 };
        string[] catPictures =
        {
            "Cat Photo #1: Porthos' First Day",
            "Cat Photo #2: Tarzan's First Christmas",
            "Cat Photo #3: Both cats on the Recliner",
            "Cat Photo #4: Me and My Buddy",
            "Cat Photo #5: Not a cat"
        };
        string[] photoFiles =
        {
            "DayWeGotPorthos.jpg",
            "Tarzan'sFirstChristmas.jpg",
            "BothCatsOnTheRecliner.jpg",
            "MeAndMyBuddy.jpg",
            "NotACat.jpg"
        };

        for (int i = 0; i < milestones.Length; i++)
        {
            if (_score >= milestones[i])
            {
                Console.WriteLine($"Unlocked: {catPictures[i]} (Points: {_score} / Requires: {milestones[i]})");
            }
            else
            {
                Console.WriteLine($"Locked: {catPictures[i]} (Points: {_score} / Requires: {milestones[i]})");
            }
        }

        if (!ReadInt("Enter the number of an unlocked photo to view, or 0 to return: ", 0, catPictures.Length, out int selection) || selection == 0)
        {
            return;
        }

        int photoIndex = selection - 1;
        if (photoIndex < 0 || photoIndex >= catPictures.Length)
        {
            Console.WriteLine("That is not a valid photo number.");
            return;
        }

        if (_score < milestones[photoIndex])
        {
            Console.WriteLine("You have not unlocked that photo yet.");
            return;
        }

        string photoPath = Path.Combine(AppContext.BaseDirectory, "CatPhotos", photoFiles[photoIndex]);
        if (!File.Exists(photoPath))
        {
            Console.WriteLine($"Photo file was not found: {photoFiles[photoIndex]}");
            return;
        }

        Process.Start(new ProcessStartInfo(photoPath) { UseShellExecute = true });
    }
}