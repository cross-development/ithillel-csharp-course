using DoctorAppointment.Domain.Enums;

namespace DoctorAppointment.Domain.Entities;

/// <summary>
/// Represents a patient with illness information and additional details.
/// </summary>
public class Patient : UserBase
{
    /// <summary>
    /// Type of illness the patient has.
    /// </summary>
    public IllnessType IllnessType { get; set; }

    /// <summary>
    /// Optional additional information about the patient's condition.
    /// </summary>
    public string? AdditionalInfo { get; set; }

    /// <summary>
    /// Optional address of the patient.
    /// </summary>
    public string? Address { get; set; }
}