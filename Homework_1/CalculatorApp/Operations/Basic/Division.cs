using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Basic;

/// <summary>
/// Represents a division operation that divides two numbers.
/// </summary>
public class Division : IOperation
{
    /// <summary>
    /// Gets the name of the operation.
    /// </summary>
    public string Name => "Division";

    /// <summary>
    /// Gets the symbol that represents the division operation.
    /// </summary>
    public string Symbol => "/";

    /// <summary>
    /// Executes the division of two operands.
    /// </summary>
    /// <param name="a">The numerator (the number to be divided).</param>
    /// <param name="b">The denominator (the number by which to divide).</param>
    /// <returns>The result of dividing <paramref name="a"/> by <paramref name="b"/>.</returns>
    /// <exception cref="DivideByZeroException">
    /// Thrown when <paramref name="b"/> is 0, as division by zero is not allowed.
    /// </exception>
    public double Execute(double a, double b)
    {
        if (b is 0)
        {
            throw new DivideByZeroException("Division by zero is not possible");
        }

        return a / b;
    }
}