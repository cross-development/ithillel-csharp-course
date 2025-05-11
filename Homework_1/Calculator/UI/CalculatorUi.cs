using CalculatorApp.Calculators;
using CalculatorApp.Core.Exceptions;
using CalculatorApp.Factories;

namespace CalculatorApp.UI;

/// <summary>
/// Represents the user interface for interacting with a calculator.
/// Allows the user to perform calculations, change calculators, and view available operations.
/// </summary>
public class CalculatorUi
{
    /// <summary>
    /// An instance of the <see cref="Calculator"/> class.
    /// </summary>
    private Calculator _calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorUi"/> class with the specified calculator.
    /// </summary>
    /// <param name="calculator">The calculator to use in the UI.</param>
    public CalculatorUi(Calculator calculator)
    {
        _calculator = calculator;
    }

    /// <summary>
    /// Runs the calculator UI, prompting the user for input and displaying results.
    /// </summary>
    public void Run()
    {
        Console.WriteLine($"\nWelcome to {_calculator.Name}");

        DisplayAvailableOperations();

        while (true)
        {
            try
            {
                Console.WriteLine("\nEnter the operation (or 'exit' to exit, 'change' to change the calculator): ");

                string? operation = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(operation))
                {
                    Console.WriteLine("Invalid operation. Please try again.");
                    continue;
                }

                if (operation.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }

                if (operation.Equals("change", StringComparison.CurrentCultureIgnoreCase))
                {
                    ChangeCalculator();
                    continue;
                }

                Console.WriteLine("\nEnter first number: ");

                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    continue;
                }

                Console.WriteLine("Enter second number: ");

                if (!double.TryParse(Console.ReadLine(), out double b))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    continue;
                }

                var result = _calculator.Calculate(a, b, operation);

                Console.WriteLine($"Result is: {result}");
            }
            catch (CalculatorException ex)
            {
                Console.WriteLine($"Calculator error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Displays the available operations for the current calculator.
    /// </summary>
    private void DisplayAvailableOperations()
    {
        Console.WriteLine("\nAvailable operations:");

        foreach (var operation in _calculator.GetAvailableOperations())
        {
            Console.WriteLine($"{operation.Symbol} - {operation.Name}");
        }
    }

    /// <summary>
    /// Allows the user to change the calculator type to a different one.
    /// Prompts the user for a selection and updates the calculator accordingly.
    /// </summary>
    private void ChangeCalculator()
    {
        Console.WriteLine("\nSelect a calculator type:");

        var types = CalculatorFactory.GetAvailableCalculatorTypes();

        for (int i = 0; i < types.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {types[i]}");
        }

        Console.WriteLine($"\nYour choice (1 - {types.Count}): ");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= types.Count)
        {
            _calculator = CalculatorFactory.CreateCalculator(types[choice - 1]);

            Console.WriteLine($"\nYou are using {_calculator.Name} now");

            DisplayAvailableOperations();
        }
        else
        {
            Console.WriteLine("Incorrect selection. The calculator remains unchanged.");
        }
    }
}