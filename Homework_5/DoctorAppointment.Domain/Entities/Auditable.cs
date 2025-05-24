namespace DoctorAppointment.Domain.Entities;

/// <summary>
/// Base class that provides auditing properties such as Id, creation and update timestamps.
/// </summary>
public abstract class Auditable
{
    /// <summary>
    /// Unique identifier of the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the entity was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}