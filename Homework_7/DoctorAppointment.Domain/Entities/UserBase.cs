namespace DoctorAppointment.Domain.Entities;

/// <summary>
/// Abstract base class for users in the system (e.g., doctors, patients).
/// Inherits from <see cref="Auditable"/>.
/// </summary>
public abstract class UserBase : Auditable
{
    /// <summary>
    /// First name of the user.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Last name of the user.
    /// </summary>
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// Optional phone number of the user.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Optional email address of the user.
    /// </summary>
    public string? Email { get; set; }
}