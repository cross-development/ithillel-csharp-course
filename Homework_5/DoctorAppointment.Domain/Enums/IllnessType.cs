namespace DoctorAppointment.Domain.Enums;

/// <summary>
/// Represents various types of illnesses that patients may have.
/// </summary>
public enum IllnessType
{
    /// <summary>
    /// Illnesses or conditions related to the eyes.
    /// </summary>
    EyeDisease = 1,

    /// <summary>
    /// Infections caused by viruses, bacteria, or other pathogens.
    /// </summary>
    Infection,

    /// <summary>
    /// Diseases or problems related to teeth and oral health.
    /// </summary>
    DentalDisease,

    /// <summary>
    /// Skin-related diseases or conditions.
    /// </summary>
    SkinDisease,

    /// <summary>
    /// Emergency condition requiring ambulance or immediate care.
    /// </summary>
    Ambulance,
}