using CalculatorApp.Calculators;
using CalculatorApp.Factories;
using CalculatorApp.UI;

namespace CalculatorApp;

/// <summary>
/// The entry point of the console calculator application.
/// Provides the user with the option to choose a calculator type and run the calculator UI.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method that serves as the entry point for the application.
    /// Prompts the user to select a calculator type and starts the corresponding calculator UI.
    /// </summary>
    /// <param name="args">Command-line arguments (unused in this implementation).</param>
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Console calculator ===");

        var calculatorTypes = CalculatorFactory.GetAvailableCalculatorTypes();

        Console.WriteLine("Select a calculator type:");

        for (int i = 0; i < calculatorTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {calculatorTypes[i]}");
        }

        int choice;

        do
        {
            Console.Write($"Your choice (1 - {calculatorTypes.Count}): ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > calculatorTypes.Count);

        var selectedType = calculatorTypes[choice - 1];

        Calculator calculator = CalculatorFactory.CreateCalculator(selectedType);

        CalculatorUi ui = new CalculatorUi(calculator);

        ui.Run();
    }
}