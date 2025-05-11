using CalculatorApp.Calculators;
using CalculatorApp.Core.Enums;

namespace CalculatorApp.Factories;

/// <summary>
/// Provides factory methods to create calculators based on the specified <see cref="CalculatorType"/>.
/// </summary>
public static class CalculatorFactory
{
    /// <summary>
    /// Creates an instance of a calculator based on the specified <see cref="CalculatorType"/>.
    /// </summary>
    /// <param name="type">The type of calculator to create.</param>
    /// <returns>A <see cref="Calculator"/> object corresponding to the specified type.</returns>
    /// <exception cref="NotImplementedException">Thrown when the specified calculator type is not supported.</exception>
    public static Calculator CreateCalculator(CalculatorType type)
    {
        return type switch
        {
            CalculatorType.Basic => new BasicCalculator(),
            CalculatorType.Programmer => new ProgrammerCalculator(),
            CalculatorType.Engineering => new EngineeringCalculator(),
            _ => throw new NotImplementedException($"Unknown type of calculator: {type}")
        };
    }

    /// <summary>
    /// Retrieves a list of all available calculator types defined in the <see cref="CalculatorType"/> enum.
    /// </summary>
    /// <returns>A list of <see cref="CalculatorType"/> values.</returns>
    public static List<CalculatorType> GetAvailableCalculatorTypes()
    {
        return Enum.GetValues<CalculatorType>().ToList();
    }
}