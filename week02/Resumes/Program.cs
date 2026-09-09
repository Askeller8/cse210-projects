using System;
// Design the Classes
// You program should contain two classes one for a Job and one for the Resume itself, as follows:

// Class: Job
// Responsibilities:
// Keeps track of the company, job title, start year, and end year.
// Behaviors:
// Displays the job information in the format "Job Title (Company) StartYear-EndYear", for example: "Software Engineer (Microsoft) 2019-2022".
// Class: Resume
// Responsibilities:
// Keeps track of the person's name and a list of their jobs.
// Behaviors:
// Displays the resume, which shows the name first, followed by displaying each one of the jobs.
// Start the Project
// Open the class project in VS Code.
// Navigate to the Resumes project in the week02 folder. Find the Program.cs file, which will be your entry point for the program.
// Verify that you can run the project and see the beginning "Hello World" output.
// Create the Job class
// Create a new file for your job class. By convention this should be named Job.cs .
// Create the class (Hint this is the public class Job syntax).
// Create member variables in the class for each element that this class should contain. By convention these member variables should begin with an underscore and a lowercase letter such as _jobTitle .
// Test your Job class
// Back in your Program.cs file, add code to your Main function.
// Create a new job instance named job1 .
// Set the member variables using the dot notation (for example, job1._jobTitle = "Software Engineer";
// Verify that you can display the company of this job on the screen, again using the dot notation to access the member variable.
// Create a second job, set its variables, display this company on the screen as well.
// Sample Output


// Microsoft
// Apple
// Add a Display method to the Job class
// Return to your Job.cs file and add a method (member function) to display the job details. This method should not have any parameters and does not need to return anything. By convention, this method should begin with a capital letter, such as Display, and if you have multiple words each word should be capitalized, such as DisplayJobDetails .
// This method should display the job details on the screen in the correct format. Remember that the method can access the member variables directly, without needing them to be passed into it.
// Return to your Program.cs file. Remove the lines of code where you displayed the company earlier, and replace them with calls to your new method. Remember that you call the method using the same dot notation such as job1.Display(); .
// Sample Output


// Software Engineer (Microsoft) 2019-2022
// Manager (Apple) 2022-2023
// Create the Resume class
// Create a new file for your Resume class. Each class should be in its own file and the file name should match the name of the class.
// Create the Resume class.
// Create the member variable for the person's name.
// Create the member variable for the list of Jobs. (Hint: the data type for this should be List<Job> , and it is probably easiest to initialize this to a new list right when you declare it..)
// Test your Resume class
// Return to your Program.cs. Add the end of the Main function, create a new instance of the Resume class.
// Add the two jobs you created earlier, to the list of jobs in the resume object.
// Verify that you can access and display the first job title using dot notation similar to myResume._jobs[0]._jobTitle .
// Add a Display method to the Resume class
// Return to your Resume class and add a method to display its details.
// This method should not have any parameters and should not return anything.
// In the method body, you should display the person's name and then iterate through each Job instance in the list of jobs and display them.
// Hint: remember that you can call each job's Display method that you created earlier.
// Return to your main function, remove any code that is displaying information, and instead, add a call at the end to the Display method from your Resume class to display the name and all the jobs in one line.
// Sample Output


// Name: Allison Rose
// Jobs:
// Software Engineer (Microsoft) 2019-2022
// Manager (Apple) 2022-2023
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
