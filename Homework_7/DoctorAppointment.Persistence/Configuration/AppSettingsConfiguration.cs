namespace DoctorAppointment.Persistence.Configuration;

/// <summary>
/// Represents a table that stores data and provides access to its metadata.
/// </summary>
/// <remarks>The <see cref="Table"/> class encapsulates information about a data table, including its last used
/// unique identifier and the file path where its data is stored. This class is sealed and cannot be
/// inherited.</remarks>
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
/// Represents a database containing configurations for various tables.
/// </summary>
/// <remarks>The <see cref="Database"/> class provides access to the configurations for the Doctors, Patients, 
/// and Appointments tables. Each table is represented by a <see cref="Table"/> object, which can be  used to manage the
/// structure and behavior of the corresponding table.</remarks>
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
/// Represents the configuration settings for databases in different formats.
/// </summary>
/// <remarks>This class provides access to database configuration sections for JSON and XML formats. Use the <see
/// cref="Json"/> property to configure or retrieve settings for JSON-formatted databases, and the <see cref="Xml"/>
/// property for XML-formatted databases.</remarks>
public sealed class DatabaseFormat
{
    /// <summary>
    /// Gets or sets the database configuration section for the json format.
    /// </summary>
    public Database Json { get; set; }

    /// <summary>
    /// Gets or sets the database configuration section for the xml format.
    /// </summary>
    public Database Xml { get; set; }
}

/// <summary>
/// Represents the application settings configuration, including database-related settings.
/// </summary>
/// <remarks>This class is designed to encapsulate configuration settings typically loaded from an application's
/// configuration file or environment variables. It provides access to the database configuration section.</remarks>
public sealed class AppSettingsConfiguration
{
    /// <summary>
    /// Gets or sets the database configuration section.
    /// </summary>
    public DatabaseFormat Database { get; set; }
}