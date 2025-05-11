using CalculatorApp.Core.Interfaces;

namespace CalculatorApp.Operations.Basic;

/// <summary>
/// Represents an addition operation that adds two numbers together.
/// </summary>
public class Addition : IOperation
{
    /// <summary>
    /// Gets the name of the addition operation.
    /// </summary>
    public string Name => "Addition";

    /// <summary>
    /// Gets the symbol that represents the addition operation.
    /// </summary>
    public string Symbol => "+";

    /// <summary>
    /// Executes the addition operation between two operands, adding <paramref name="a"/> and <paramref name="b"/>.
    /// </summary>
    /// <param name="a">The first operand to be added.</param>
    /// <param name="b">The second operand to be added.</param>
    /// <returns>The result of adding <paramref name="a"/> and <paramref name="b"/> together.</returns>
    public double Execute(double a, double b)
    {
        return a + b;
    }
}