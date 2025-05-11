using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Basic;

/// <summary>
/// Represents a subtraction operation that subtracts one number from another.
/// </summary>
public class Subtraction : IOperation
{
    /// <summary>
    /// Gets the name of the operation.
    /// </summary>
    public string Name => "Subtraction";

    /// <summary>
    /// Gets the symbol that represents the subtraction operation.
    /// </summary>
    public string Symbol => "-";

    /// <summary>
    /// Executes the subtraction of two operands.
    /// </summary>
    /// <param name="a">The first operand (the number from which another number will be subtracted).</param>
    /// <param name="b">The second operand (the number to subtract from the first).</param>
    /// <returns>The result of subtracting <paramref name="b"/> from <paramref name="a"/>.</returns>
    public double Execute(double a, double b)
    {
        return a - b;
    }
}