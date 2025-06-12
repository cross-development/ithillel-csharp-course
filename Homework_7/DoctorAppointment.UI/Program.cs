using Microsoft.Extensions.DependencyInjection;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.Application.Services;
using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.Persistence.Interfaces;
using DoctorAppointment.Persistence.Repositories;
using DoctorAppointment.UI.ConsoleUi;
using DoctorAppointment.UI.ConsoleUi.Interfaces;
using DoctorAppointment.UI.ConsoleUi.Managers;
using DoctorAppointment.UI.Infrastructure;

namespace DoctorAppointment.UI;

/// <summary>
/// The entry point of the Doctor Appointment console application.
/// Configures dependency injection, builds the service provider,
/// and starts the main console application loop.
/// </summary>
internal class Program
{
    /// <summary>
    /// The main method that configures services and starts the application.
    /// </summary>
    /// <param name="args">The command-line arguments (not used).</param>
    /// <remarks>
    /// This method sets up the dependency injection container by registering
    /// repository, service, and UI manager implementations. After configuring
    /// all required services, it builds the service provider, resolves the
    /// main <see cref="ConsoleApp"/> instance, and runs the application.
    /// </remarks>
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();

        // Register the application context as a singleton
        services.AddSingleton<IApplicationContext, ApplicationContext>();

        // Register the format strategy resolver for IDataFormatStrategy<T>
        services.AddTransient(typeof(IDataFormatStrategy<>), typeof(FormatStrategyResolver<>));

        // Persistence layer service registrations
        services.AddTransient<IDoctorRepository, DoctorRepository>();
        services.AddTransient<IPatientRepository, PatientRepository>();
        services.AddTransient<IAppointmentRepository, AppointmentRepository>();

        // Application layer service registrations
        services.AddTransient<IDoctorService, DoctorService>();
        services.AddTransient<IPatientService, PatientService>();
        services.AddTransient<IAppointmentService, AppointmentService>();

        // UI layer service registrations
        services.AddTransient<IDoctorManager, DoctorManager>();
        services.AddTransient<IPatientManager, PatientManager>();
        services.AddTransient<IAppointmentManager, AppointmentManager>();
        services.AddTransient<ConsoleApp>();

        var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<ConsoleApp>();

        app.Run();
    }
}

