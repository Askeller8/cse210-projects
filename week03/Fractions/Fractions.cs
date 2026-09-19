using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor with no parameters, initializes to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter for the numerator, initializes denominator to 1
    public Fraction(int num)
    {
        numerator = num;
        denominator = 1;
    }

    // Constructor with two parameters for numerator and denominator
    public Fraction(int num, int denom)
    {
        numerator = num;
        denominator = denom;
    }

    // Getter and Setter for Numerator
    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int num)
    {
        numerator = num;
    }

    // Getter and Setter for Denominator
    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int denom)
    {
        if (denom != 0)
        {
            denominator = denom;
        }
        else
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
    }

    // Method to return the fraction as a string
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}