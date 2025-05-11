using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Basic;

/// <summary>
/// Represents a multiplication operation that multiplies two numbers.
/// </summary>
public class Multiplication : IOperation
{
    /// <summary>
    /// Gets the name of the operation.
    /// </summary>
    public string Name => "Multiplication";

    /// <summary>
    /// Gets the symbol that represents the multiplication operation.
    /// </summary>
    public string Symbol => "*";

    /// <summary>
    /// Executes the multiplication of two operands.
    /// </summary>
    /// <param name="a">The first operand (the number to be multiplied).</param>
    /// <param name="b">The second operand (the number by which to multiply).</param>
    /// <returns>The result of multiplying <paramref name="a"/> and <paramref name="b"/>.</returns>
    public double Execute(double a, double b)
    {
        return a * b;
    }
}