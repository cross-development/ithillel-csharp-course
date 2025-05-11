using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Programmer;

/// <summary>
/// Represents a bitwise OR operation that performs a bitwise OR on two integers.
/// </summary>
public class BitwiseOr : IOperation
{
    /// <summary>
    /// Gets the name of the bitwise OR operation.
    /// </summary>
    public string Name => "Bitwise OR";

    /// <summary>
    /// Gets the symbol that represents the bitwise OR operation.
    /// </summary>
    public string Symbol => "|";

    /// <summary>
    /// Executes the bitwise OR operation on two operands, performing a bitwise OR on <paramref name="a"/> and <paramref name="b"/>.
    /// Both operands are cast to integers before the operation.
    /// </summary>
    /// <param name="a">The first operand, to be cast to an integer for the bitwise OR.</param>
    /// <param name="b">The second operand, to be cast to an integer for the bitwise OR.</param>
    /// <returns>The result of performing a bitwise OR between <paramref name="a"/> and <paramref name="b"/> as integers.</returns>
    public double Execute(double a, double b)
    {
        return (int)a | (int)b;
    }
}