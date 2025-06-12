using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Persistence.Configuration;

/// <summary>
/// Extension methods for AppSettingsConfiguration to manage entity tables.
/// </summary>
public static class AppSettingsExtensions
{
    /// <summary>
    /// Gets the appropriate entity table based on the specified data format and entity type.
    /// </summary>
    /// <param name="config">The application settings configuration.</param>
    /// <param name="format">The data format type (Json or Xml).</param>
    /// <param name="entityType">The entity type (Doctor, Patient, or Appointment).</param>
    /// <returns>The corresponding table configuration.</returns>
    /// <exception cref="NotSupportedException">Thrown when the format or entity type is not supported.</exception>
    public static Table GetEntityTable(this AppSettingsConfiguration config, DataFormatType format, EntityType entityType)
    {
        var database = format switch
        {
            DataFormatType.Json => config.Database.Json,
            DataFormatType.Xml => config.Database.Xml,
            _ => throw new NotSupportedException($"Format '{format}' is not supported.")
        };

        return entityType switch
        {
            EntityType.Doctor => database.Doctors,
            EntityType.Patient => database.Patients,
            EntityType.Appointment => database.Appointments,
            _ => throw new NotSupportedException($"Entity type '{entityType}' is not supported.")
        };
    }

    /// <summary>
    /// Sets the entity table for the specified data format and entity type.
    /// </summary>
    /// <param name="config">The application settings configuration.</param>
    /// <param name="format">The data format type (Json or Xml).</param>
    /// <param name="entityType">The entity type (Doctor, Patient, or Appointment).</param>
    /// <param name="table">The table configuration to set.</param>
    /// <exception cref="NotSupportedException">Thrown when the format or entity type is not supported.</exception>
    public static void SetEntityTable(this AppSettingsConfiguration config, DataFormatType format, EntityType entityType, Table table)
    {
        var database = format switch
        {
            DataFormatType.Json => config.Database.Json,
            DataFormatType.Xml => config.Database.Xml,
            _ => throw new NotSupportedException($"Format '{format}' is not supported.")
        };

        switch (entityType)
        {
            case EntityType.Doctor:
                database.Doctors = table;
                break;
            case EntityType.Patient:
                database.Patients = table;
                break;
            case EntityType.Appointment:
                database.Appointments = table;
                break;
            default:
                throw new NotSupportedException($"Entity type '{entityType}' is not supported.");
        }
    }
}