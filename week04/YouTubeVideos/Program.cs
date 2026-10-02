using System;

class Program
{
    static void Main(string[] args)
    {
        // Create videos and comments here
        Video video1 = new Video("How to Program with Classes", "John Doe", 300);
        Comment comment1 = new Comment("Alice Smith", "Great explanation!");
        Comment comment2 = new Comment("Bob Johnson", "Very helpful.");
        video1.AddComment(comment1);
        video1.AddComment(comment2);

        Video video2 = new Video("Introduction to C#", "Jane Doe", 450);
        Comment comment3 = new Comment("Charlie Brown", "Excellent tutorial.");
        Comment comment4 = new Comment("David Wilson", "Thanks for sharing.");
        video2.AddComment(comment3);
        video2.AddComment(comment4);

        // Add videos to a list
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}