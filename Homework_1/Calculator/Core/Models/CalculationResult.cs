namespace CalculatorApp.Core.Models;

/// <summary>
/// Represents the result of a calculation, including operands, operation, and final result.
/// </summary>
public class CalculationResult
{
    /// <summary>
    /// Gets the first operand used in the calculation.
    /// </summary>
    public double FirstOperand { get; init; }

    /// <summary>
    /// Gets the second operand used in the calculation.
    /// </summary>
    public double SecondOperand { get; init; }

    /// <summary>
    /// Gets the symbol or name of the operation performed (e.g., "+", "*").
    /// </summary>
    public required string Operation { get; init; }

    /// <summary>
    /// Gets the result of the calculation.
    /// </summary>
    public double Result { get; init; }

    /// <summary>
    /// Returns a string representation of the calculation in the format "a op b = result".
    /// </summary>
    /// <returns>A formatted string displaying the full calculation.</returns>
    public override string ToString()
    {
        return $"{FirstOperand} {Operation} {SecondOperand} = {Result}";
    }
}