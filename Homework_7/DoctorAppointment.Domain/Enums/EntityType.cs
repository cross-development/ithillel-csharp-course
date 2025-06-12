namespace DoctorAppointment.Domain.Enums;

/// <summary>
/// Represents the type of entity in the doctor appointment system.
/// </summary>
public enum EntityType
{
    /// <summary>
    /// Represents a medical doctor entity.
    /// </summary>
    Doctor,

    /// <summary>
    /// Represents a patient entity.
    /// </summary>
    Patient,

    /// <summary>
    /// Represents an appointment entity.
    /// </summary>
    Appointment
}