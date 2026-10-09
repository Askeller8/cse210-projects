using System;
// Activity Instructions
// Practice the principle of polymorphism by writing a program that computes the areas of different shapes cut out of pieces of paper.

// For all shapes, you need to keep track of the color of the paper and then have a method to compute the area. The area should not be stored as a member variable, but instead, you should store the length of the shapes sides and then compute the area as needed.

// Your program should include squares (which store a color and a single side), rectangles (which store a color and two sides), and a circle (which store a color and a radius). You should create several kinds of shapes and put them into a single list. Then, iterate through the list and display their areas.

// Design the Classes
// Based on what you learned in inheritance, it seems reasonable to create a base shape class where you can include any responsibilities that all shapes have in common. Then you can create derived classes for the individual square, rectangle and circle shapes.

// In this example all shapes have a color and a method to get the area, but the implementation of that method will be different for each kind of shape. Thus, the GetArea method should be declared in the base class, but you should override it in the derived classes.

// These relationships can be seen with the following class diagram:

// Class Diagram
// Shape Class Diagram
// Start the Project
// Open the class project in VS Code.
// Navigate to the Shapes project in the week06 folder. Find the Program.cs file, which will be your entry point for the program.
// Verify that you can run the project.
// Create the base Shape class
// In a new file, create the Shape class.
// Add the color member variable and a getter and setter for it.
// Create a constructor that accepts the color and sets it.
// Create a virtual method for GetArea().
// Create the Square class
// In a new file, create the Square class.
// Make sure this class inherits from the base class.
// Create a constructor that accepts the color and the side, and then call the base constructor with the color.
// Create the _side attribute as a private member variable.
// Override the GetArea() method from the base class and fill in the body of this function to return the area.
// Test the Square class
// Return to the Main method in Program.cs to test your code.
// Create a Square instance, call the GetColor() and GetArea() methods and make sure they return the values you expect.
// Create the Rectangle and Circle classes
// Repeat the steps above for the Rectangle and Circle classes, putting them each in their own files, storing the necessary variables, and overriding the GetArea() for each.
// Test these classes back in Main and make sure they work as expected.
// Build a List
// In your Main method, create a list to hold shapes (Hint: The data type should be List<Shape>).
// Add a square, rectangle, and circle to this list.
// Iterate through the list of shapes. For each one, call and display the GetColor() and GetArea() methods.
class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shapes> shapesList = new List<Shapes>();

        // Add a square, rectangle, and circle to the list
        shapesList.Add(new Square("Red", 4));
        shapesList.Add(new Rectangle("Blue", 5, 3));
        shapesList.Add(new Circle("Green", 2.5));

        // Iterate through the list of shapes and display their color and area
        foreach (var shape in shapesList)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}