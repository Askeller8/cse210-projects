using System;
// Activity Instructions
// Practice the principle of inheritance by creating a base class and derived classes.

// For this activity, you will write classes to represent different kinds of homework assignments. Consider the following example of Math and writing assignments.

// Math Assignments
// A Math assignment may need to store the student's name, the topic (for example, "Fractions"), the textbook section (for example, "7.3"), and the problems from that section (for example, "3-10, 20-21").

// The Math assignment should have a constructor that requires a value for each of the items that it stores.

// The Math assignment needs to provide a method to return a summary of the assignment that contains the student's name and the topic, and it also needs to provide a method to display the Math homework list including the section number and the problems (for example, "Section 7.3 Problems 8-19").

// Writing Assignments
// A writing assignment may need to store the student's name, the topic (for example, "European History"), and the title of the assignment (for example, "The Causes of World War II").

// The writing assignment should have a constructor that requires a value for each of the items that it stores.

// The writing assignment needs to provide a method to return a summary of the assignment that contains the student's name and the topic, and it also needs to provide a method to get the writing information which consists of the title and the student's name (for example, "The Causes of World War II by Mary Waters").

// Design the Classes
// There are a number of things these classes have in common and a number of differences. Using inheritance, you can separate the things that change from the things that stay the same, putting the common elements in a base class and the differing elements in a derived class.

// Consider the following class diagram:

// Class Diagram showing separate classes
// Class Diagram Without Inheritance
// From these diagrams you can see that the _studentName and _topic attributes are the same in both classes, and so is the GetSummary() method. Instead of duplicating these items, you can create a base class that they both inherit from.

// The following class diagram shows an approach that uses inheritance. This is the approach you will use for this assignment.

// Class Diagram showing inheritance
// Class Diagram Showing Inheritance
// Start the Project
// Open the class project in VS Code.
// Navigate to the Homework project in the week05 folder. Find the Program.cs file, which will be your entry point for the program.
// Verify that you can run the project.
// Create the base class
// Begin by creating a new file and a class for your base Assignment class.
// Add the attributes as private member variables.
// Create a constructor for this class that receives a student name and topic and sets the member variables.
// Add the method for GetSummary() to return the student's name and the topic.
// Test your class by returning to the Main method in the Program.cs file. Create a simple assignment, call the method to get the summary, and then display it to the screen.
// Sample Output


// Samuel Bennett - Multiplication
// Create the MathAssignment class
// Create a new file for the MathAssignment class.
// Create this class and make sure to specify that it inherits from the base Assignment class.
// Add the attributes as private member variables. Make sure that you do not create new member variables for the ones you inherited from the base class.
// Create a constructor for your class that accepts all four parameters, have it call the base class constructor to set the base class attributes that way.
// Add the GetHomeworkList() method.
// Test your class by returning to the Main method and creating a new MathAssignment object and set its values. Make sure to test both the GetSummary() and the GetHomeworkList() methods.
// Sample Output


// Roberto Rodriguez - Fractions
// Section 7.3 Problems 8-19
// Create the WritingAssignment class
// Follow the same pattern as before by creating a new file for the WritingAssignment class.
// Create the class and set up the inheritance relationship.
// Add the member variables and set up the constructor as you did for the MathAssignment class.
// Add the GetWritingInformation() method.
// Notice that this method needs to access the _studentName variable defined in the base class. Even though WritingAssignment class inherited this attribute, it is private, so you cannot access it directly in the derived class.

// To get the data you need for the method you can either make the variable protected in the base class, or you can create a public GetStudentName method to return it.

// Return to Main and test your new class.
// Sample Output


// Mary Waters - European History
// The Causes of World War II by Mary Waters
class Program
{
 
    static void Main(string[] args)
    {
        // Create a MathAssignment object
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Create a WritingAssignment object
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}