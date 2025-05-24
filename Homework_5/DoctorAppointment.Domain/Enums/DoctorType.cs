namespace DoctorAppointment.Domain.Enums;

/// <summary>
/// Represents the specialization or role of a doctor.
/// </summary>
public enum DoctorType
{
    /// <summary>
    /// A doctor who specializes in dental care.
    /// </summary>
    Dentist = 1,

    /// <summary>
    /// A doctor who treats skin-related conditions.
    /// </summary>
    Dermatologist,

    /// <summary>
    /// A general practitioner who provides primary care to families.
    /// </summary>
    FamilyDoctor,

    /// <summary>
    /// A medical professional who provides emergency or basic healthcare services.
    /// </summary>
    Paramedic,
}