using Newtonsoft.Json;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Persistence.Configuration;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Repository class for managing <see cref="Doctor"/> entities.
/// Provides CRUD operations and handles persistence via JSON file.
/// Inherits from <see cref="GenericRepository{Doctor}"/>.
/// </summary>
public sealed class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    /// <summary>
    /// Gets or sets the file path where doctor data is stored.
    /// </summary>
    protected override string Path { get; set; }

    /// <summary>
    /// Gets or sets the last used ID for doctor entities.
    /// </summary>
    protected override int LastId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DoctorRepository"/> class.
    /// Loads the file path and last ID from the app settings configuration.
    /// </summary>
    public DoctorRepository()
    {
        AppSettingsConfiguration result = ReadFromAppSettings();

        Path = result.Database.Doctors.Path;
        LastId = result.Database.Doctors.LastId;
    }

    /// <summary>
    /// Persists the current value of <see cref="LastId"/> to the app settings file.
    /// </summary>
    protected override void SaveLastId()
    {
        AppSettingsConfiguration result = ReadFromAppSettings();
        result.Database.Doctors.LastId = LastId;

        var json = JsonConvert.SerializeObject(result, Formatting.Indented);
        File.WriteAllText(Constants.AppSettingsPath, json);
    }
}