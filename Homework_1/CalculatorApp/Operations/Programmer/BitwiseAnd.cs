using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Programmer;

/// <summary>
/// Represents a bitwise AND operation that performs a bitwise AND on two integers.
/// </summary>
public class BitwiseAnd : IOperation
{
    /// <summary>
    /// Gets the name of the bitwise AND operation.
    /// </summary>
    public string Name => "Bitwise AND";

    /// <summary>
    /// Gets the symbol that represents the bitwise AND operation.
    /// </summary>
    public string Symbol => "&";

    /// <summary>
    /// Executes the bitwise AND operation on two operands, performing a bitwise AND on <paramref name="a"/> and <paramref name="b"/>.
    /// Both operands are cast to integers before the operation.
    /// </summary>
    /// <param name="a">The first operand, to be cast to an integer for the bitwise AND.</param>
    /// <param name="b">The second operand, to be cast to an integer for the bitwise AND.</param>
    /// <returns>The result of performing a bitwise AND between <paramref name="a"/> and <paramref name="b"/> as integers.</returns>
    public double Execute(double a, double b)
    {
        return (int)a & (int)b;
    }
}