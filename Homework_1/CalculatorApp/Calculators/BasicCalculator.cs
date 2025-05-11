using CalculatorApp.Operations.Basic;

namespace CalculatorApp.Calculators;

/// <summary>
/// Represents a basic calculator that supports fundamental arithmetic operations:
/// addition, subtraction, multiplication, and division.
/// </summary>
public class BasicCalculator : Calculator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BasicCalculator"/> class
    /// and registers the basic arithmetic operations.
    /// </summary>
    public BasicCalculator()
    {
        Name = "Basic calculator";

        _operations.Add("+", new Addition());
        _operations.Add("-", new Subtraction());
        _operations.Add("*", new Multiplication());
        _operations.Add("/", new Division());
    }
}