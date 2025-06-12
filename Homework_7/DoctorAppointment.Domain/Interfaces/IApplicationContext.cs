using DoctorAppointment.Domain.Enums;

namespace DoctorAppointment.Domain.Interfaces;

/// <summary>
/// Defines the application context interface that provides configuration information
/// for the application.
/// </summary>
public interface IApplicationContext
{
    /// <summary>
    /// Gets or sets the data format type used for serialization and deserialization of data.
    /// </summary>
    /// <value>The data format type from the <see cref="DataFormatType"/> enumeration.</value>
    DataFormatType Format { get; set; }
}