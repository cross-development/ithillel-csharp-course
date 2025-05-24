using Newtonsoft.Json;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Persistence.Configuration;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Repository class for managing <see cref="Patient"/> entities.
/// Provides CRUD operations and handles persistence via JSON file.
/// Inherits from <see cref="GenericRepository{Patient}"/>.
/// </summary>
public sealed class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    /// <summary>
    /// Gets or sets the file path where patient data is stored.
    /// </summary>
    protected override string Path { get; set; }

    /// <summary>
    /// Gets or sets the last used ID for patient entities.
    /// </summary>
    protected override int LastId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PatientRepository"/> class.
    /// Loads the file path and last ID from the app settings configuration.
    /// </summary>
    public PatientRepository()
    {
        AppSettingsConfiguration result = ReadFromAppSettings();

        Path = result.Database.Patients.Path;
        LastId = result.Database.Patients.LastId;
    }

    /// <summary>
    /// Persists the current value of <see cref="LastId"/> to the app settings file.
    /// </summary>
    protected override void SaveLastId()
    {
        AppSettingsConfiguration result = ReadFromAppSettings();
        result.Database.Patients.LastId = LastId;

        var json = JsonConvert.SerializeObject(result, Formatting.Indented);
        File.WriteAllText(Constants.AppSettingsPath, json);
    }
}