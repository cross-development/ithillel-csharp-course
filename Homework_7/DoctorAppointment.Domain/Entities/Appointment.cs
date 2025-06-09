namespace DoctorAppointment.Domain.Entities;

/// <summary>
/// Represents an appointment between a patient and a doctor.
/// </summary>
public class Appointment : Auditable
{
    /// <summary>
    /// The patient involved in the appointment.
    /// </summary>
    public Patient? Patient { get; set; }

    /// <summary>
    /// The doctor involved in the appointment.
    /// </summary>
    public Doctor? Doctor { get; set; }

    /// <summary>
    /// Start time of the appointment.
    /// </summary>
    public DateTime DateTimeFrom { get; set; }

    /// <summary>
    /// End time of the appointment.
    /// </summary>
    public DateTime DateTimeTo { get; set; }

    /// <summary>
    /// Optional description or notes about the appointment.
    /// </summary>
    public string? Description { get; set; }
}