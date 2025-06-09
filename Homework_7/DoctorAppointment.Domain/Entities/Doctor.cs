using DoctorAppointment.Domain.Enums;

namespace DoctorAppointment.Domain.Entities;

/// <summary>
/// Represents a doctor in the system with a specific type, experience, and salary.
/// </summary>
public class Doctor : UserBase
{
    /// <summary>
    /// The specialization or category of the doctor.
    /// </summary>
    public DoctorType DoctorType { get; set; }

    /// <summary>
    /// The doctor's years of experience.
    /// </summary>
    public byte Experience { get; set; }

    /// <summary>
    /// The doctor's salary.
    /// </summary>
    public decimal Salary { get; set; }
}