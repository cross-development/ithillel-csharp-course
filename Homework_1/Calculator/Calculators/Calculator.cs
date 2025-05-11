using CalculatorApp.Core.Exceptions;
using CalculatorApp.Core.Interfaces;
using CalculatorApp.Core.Models;

namespace CalculatorApp.Calculators;

/// <summary>
/// Represents the base class for all calculators, providing common logic for operation execution and management.
/// </summary>
public abstract class Calculator
{
    /// <summary>
    /// A collection of operations supported by the calculator, where the key is the operation symbol.
    /// </summary>
    protected readonly Dictionary<string, IOperation> _operations = new();

    /// <summary>
    /// Gets the name of the calculator.
    /// </summary>
    public string Name { get; protected init; }

    /// <summary>
    /// Performs a calculation using the specified operands and operation symbol.
    /// </summary>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <param name="operation">The symbol of the operation to perform.</param>
    /// <returns>A <see cref="CalculationResult"/> containing details of the operation and result.</returns>
    /// <exception cref="CalculatorException">Thrown when the specified operation is not supported by the calculator.</exception>
    public CalculationResult Calculate(double a, double b, string operation)
    {
        if (!_operations.TryGetValue(operation, out var op))
        {
            throw new CalculatorException($"Operation '{operation}' is not supported in calculator {Name}");
        }

        double result = op.Execute(a, b);

        return new CalculationResult
        {
            FirstOperand = a,
            SecondOperand = b,
            Operation = operation,
            Result = result,
        };
    }

    /// <summary>
    /// Gets a list of available operations supported by the calculator.
    /// </summary>
    /// <returns>A list of <see cref="IOperation"/> instances representing supported operations.</returns>
    public List<IOperation> GetAvailableOperations()
    {
        return _operations.Values.ToList();
    }
}