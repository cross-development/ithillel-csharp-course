using Microsoft.Extensions.DependencyInjection;
using DoctorAppointment.UI.ConsoleUi.Interfaces;

namespace DoctorAppointment.UI.ConsoleUi;

/// <summary>
/// Represents the main console application for hospital administration.
/// Provides a menu interface to manage doctors, patients, and appointments.
/// </summary>
public sealed class ConsoleApp(IServiceProvider serviceProvider)
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
}