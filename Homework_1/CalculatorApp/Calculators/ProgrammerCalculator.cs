using CalculatorApp.Operations.Basic;
using CalculatorApp.Operations.Programmer;

namespace CalculatorApp.Calculators;

/// <summary>
/// Represents a programmer calculator that supports both basic arithmetic 
/// and bitwise operations.
/// </summary>
public class ProgrammerCalculator : Calculator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProgrammerCalculator"/> class
    /// and registers basic and programmer-specific operations.
    /// </summary>
    public ProgrammerCalculator()
    {
        Name = "Programmer calculator";

        _operations.Add("+", new Addition());
        _operations.Add("-", new Subtraction());
        _operations.Add("*", new Multiplication());
        _operations.Add("/", new Division());
        _operations.Add("&", new BitwiseAnd());
        _operations.Add("|", new BitwiseOr());
    }
}