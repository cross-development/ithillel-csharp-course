using Newtonsoft.Json;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Persistence.Configuration;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Repository class for managing <see cref="Appointment"/> entities.
/// Inherits common CRUD functionality from <see cref="GenericRepository{Appointment}"/>.
/// </summary>
public sealed class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    /// <summary>
    /// Gets or sets the file path where appointment data is stored.
    /// </summary>
    protected override string Path { get; set; }

    /// <summary>
    /// Gets or sets the last used ID for appointment entities.
    /// </summary>
    protected override int LastId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentRepository"/> class.
    /// Loads the path and last used ID from the application settings.
    /// </summary>
    public AppointmentRepository()
    {
        AppSettingsConfiguration result = ReadFromAppSettings();

        Path = result.Database.Appointments.Path;
        LastId = result.Database.Appointments.LastId;
    }

    /// <summary>
    /// Saves the current value of <see cref="LastId"/> to the application settings file.
    /// </summary>
    protected override void SaveLastId()
    {
        AppSettingsConfiguration result = ReadFromAppSettings();
        result.Database.Appointments.LastId = LastId;

        var json = JsonConvert.SerializeObject(result, Formatting.Indented);
        File.WriteAllText(Constants.AppSettingsPath, json);
    }
}