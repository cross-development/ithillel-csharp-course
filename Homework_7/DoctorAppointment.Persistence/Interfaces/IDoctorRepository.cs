using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Persistence.Interfaces;

/// <summary>
/// Represents a repository interface for managing <see cref="Doctor"/> entities.
/// </summary>
public interface IDoctorRepository : IGenericRepository<Doctor>
{

}