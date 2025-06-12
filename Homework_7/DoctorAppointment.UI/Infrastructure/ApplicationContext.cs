using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces;

namespace DoctorAppointment.UI.Infrastructure;

/// <summary>
/// Provides contextual information for the application, such as data format preferences.
/// </summary>
public class ApplicationContext : IApplicationContext
{
    /// <summary>
    /// Gets or sets the data format type to be used for data persistence.
    /// Default value is <see cref="DataFormatType.Json"/>.
    /// </summary>
    public DataFormatType Format { get; set; } = DataFormatType.Json;
}