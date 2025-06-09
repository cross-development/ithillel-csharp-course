using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Persistence.Interfaces;

/// <summary>
/// Represents a repository interface for managing <see cref="Appointment"/> entities.
/// </summary>
public interface IAppointmentRepository : IGenericRepository<Appointment>
{

}