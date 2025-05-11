using CalculatorApp.Operations.Basic;
using CalculatorApp.Operations.Engineering;

namespace CalculatorApp.Calculators;

/// <summary>
/// Represents an engineering calculator that supports both basic arithmetic
/// and engineering-specific operations like modulo and power.
/// </summary>
public class EngineeringCalculator : Calculator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EngineeringCalculator"/> class
    /// and registers basic and engineering-specific operations.
    /// </summary>
    public EngineeringCalculator()
    {
        Name = "Engineering calculator";

        _operations.Add("+", new Addition());
        _operations.Add("-", new Subtraction());
        _operations.Add("*", new Multiplication());
        _operations.Add("/", new Division());
        _operations.Add("%", new Modulo());
        _operations.Add("^", new Power());
    }
}