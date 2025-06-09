using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Persistence.Interfaces;

/// <summary>
/// Represents a repository interface for managing <see cref="Patient"/> entities.
/// </summary>
public interface IPatientRepository : IGenericRepository<Patient>
{

}