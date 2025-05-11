namespace CalculatorApp.Core.Interfaces;

/// <summary>
/// Defines the basic structure for a calculator operation.
/// </summary>
public interface IOperation
{
    /// <summary>
    /// Gets the name of the operation (e.g., "Addition", "Multiplication").
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the symbol representing the operation (e.g., "+", "*").
    /// </summary>
    string Symbol { get; }

    /// <summary>
    /// Executes the operation using two input values.
    /// </summary>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <returns>The result of the operation.</returns>
    double Execute(double a, double b);
}