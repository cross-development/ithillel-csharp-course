namespace DoctorAppointment.Persistence.Configuration;

/// <summary>
/// Represents metadata for a database table, including file path and the last used identifier.
/// </summary>
public sealed class Table
{
    /// <summary>
    /// Gets or sets the last used unique identifier in the table.
    /// </summary>
    public int LastId { get; set; }

    /// <summary>
    /// Gets or sets the file path where the table's data is stored.
    /// </summary>
    public string Path { get; set; }
}

/// <summary>
/// Represents the structure of the application database configuration,
/// including all tables used in the application.
/// </summary>
public sealed class Database
{
    /// <summary>
    /// Gets or sets the configuration for the Doctors table.
    /// </summary>
    public Table Doctors { get; set; }

    /// <summary>
    /// Gets or sets the configuration for the Patients table.
    /// </summary>
    public Table Patients { get; set; }

    /// <summary>
    /// Gets or sets the configuration for the Appointments table.
    /// </summary>
    public Table Appointments { get; set; }
}

/// <summary>
/// Represents the root configuration model for the application's settings file.
/// </summary>
public sealed class AppSettingsConfiguration
{
    /// <summary>
    /// Gets or sets the database configuration section.
    /// </summary>
    public Database Database { get; set; }
}
