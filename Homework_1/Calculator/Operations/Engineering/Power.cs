using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Engineering;

/// <summary>
/// Represents a power operation that raises a number to the power of another number.
/// </summary>
public class Power : IOperation
{
    /// <summary>
    /// Gets the name of the operation.
    /// </summary>
    public string Name => "Power";

    /// <summary>
    /// Gets the symbol that represents the power operation.
    /// </summary>
    public string Symbol => "^";

    /// <summary>
    /// Executes the power operation between two operands, raising <paramref name="a"/> to the power of <paramref name="b"/>.
    /// </summary>
    /// <param name="a">The base (the number to be raised to a power).</param>
    /// <param name="b">The exponent (the power to which the base is raised).</param>
    /// <returns>The result of raising <paramref name="a"/> to the power of <paramref name="b"/>.</returns>
    public double Execute(double a, double b)
    {
        return Math.Pow(a, b);
    }
}