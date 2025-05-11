using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Engineering;

/// <summary>
/// Represents a modulo operation that returns the remainder of a division of two numbers.
/// </summary>
public class Modulo : IOperation
{
    /// <summary>
    /// Gets the name of the operation.
    /// </summary>
    public string Name => "Modulo";

    /// <summary>
    /// Gets the symbol that represents the modulo operation.
    /// </summary>
    public string Symbol => "%";

    /// <summary>
    /// Executes the modulo operation between two operands.
    /// </summary>
    /// <param name="a">The dividend (the number to be divided).</param>
    /// <param name="b">The divisor (the number by which the dividend is divided).</param>
    /// <returns>The remainder when <paramref name="a"/> is divided by <paramref name="b"/>.</returns>
    /// <exception cref="DivideByZeroException">
    /// Thrown when <paramref name="b"/> is zero, as division by zero is not allowed.
    /// </exception>
    public double Execute(double a, double b)
    {
        if (b is 0)
        {
            throw new DivideByZeroException("Division by zero is not possible");
        }

        return a % b;
    }
}