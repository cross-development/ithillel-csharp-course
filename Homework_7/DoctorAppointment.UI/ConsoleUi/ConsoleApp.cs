using Microsoft.Extensions.DependencyInjection;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.UI.ConsoleUi.Interfaces;

namespace DoctorAppointment.UI.ConsoleUi;

/// <summary>
/// Main console application class that handles user interaction with the hospital administration system.
/// </summary>
/// <remarks>
/// This class is responsible for displaying the main menu, processing user input,
/// and delegating to the appropriate manager services for doctor, patient, and appointment management.
/// It also handles data format selection at application startup.
/// </remarks>
/// <param name="serviceProvider">The dependency injection service provider used to resolve manager services.</param>
/// <param name="applicationContext">The application context that stores global application settings.</param>
public sealed class ConsoleApp(IServiceProvider serviceProvider, IApplicationContext applicationContext)
{
    /// <summary>
    /// Runs the main loop of the console application, displaying a menu and
    /// handling user input to navigate between different management modules.
    /// </summary>
    /// <remarks>
    /// This method continuously prompts the user with the menu options until the
    /// user selects the "Exit" option. Based on the user's choice, it retrieves
    /// the appropriate manager service from the dependency injection container
    /// and invokes its <see cref="IDoctorManager.Run"/>, <see cref="IPatientManager.Run"/>,
    /// or <see cref="IAppointmentManager.Run"/> method.
    /// </remarks>
    public void Run()
    {
        applicationContext.Format = AskForDataFormat();

        var exit = false;

        while (!exit)
        {
            Console.WriteLine("=== Hospital Admin Console ===");
            Console.WriteLine("1. Manage Doctors");
            Console.WriteLine("2. Manage Patients");
            Console.WriteLine("3. Manage Appointments");
            Console.WriteLine("0. Exit");

            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1": serviceProvider.GetRequiredService<IDoctorManager>().Run(); break;
                case "2": serviceProvider.GetRequiredService<IPatientManager>().Run(); break;
                case "3": serviceProvider.GetRequiredService<IAppointmentManager>().Run(); break;
                case "0": exit = true; break;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }

    /// <summary>
    /// Prompts the user to select a data format and returns the corresponding <see cref="DataFormatType"/> value.
    /// </summary>
    /// <remarks>
    /// If the user provides an invalid input or no input, the method defaults to <see cref="DataFormatType.Json"/>.
    /// </remarks>
    /// <returns>
    /// The selected <see cref="DataFormatType"/> based on user input, or <see cref="DataFormatType.Json"/> if the input is invalid.
    /// </returns>
    private static DataFormatType AskForDataFormat()
    {
        var availableFormats = Enum.GetNames<DataFormatType>().Select(name => name.ToLower());

        Console.WriteLine($"Select data format: {string.Join(" / ", availableFormats)}");
        var input = Console.ReadLine()?.Trim().ToLower();

        if (Enum.TryParse<DataFormatType>(input, true, out var format))
        {
            return format;
        }

        Console.WriteLine("Invalid format. Default to JSON.");
        format = DataFormatType.Json;

        return format;
    }
}