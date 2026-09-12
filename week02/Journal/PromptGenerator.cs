using System;

class PromptGenerator
{
    private string[] prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the worst part of my day?",
        "What is something you're proud of that you accomplished today?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "What is one thing you learned today?",
        "What is one thing you could have done better today?",
        "What is something that made me smile today?",
        "What is something you needed today that you didn't have?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}