using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Application.Services;

/// <summary>
/// Service implementation for managing <see cref="Appointment"/> entities.
/// Delegates CRUD operations to the injected <see cref="IAppointmentRepository"/>.
/// </summary>
public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
{
    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="appointment">The appointment to create.</param>
    /// <returns>The created appointment.</returns>
    public Appointment Create(Appointment appointment)
    {
        return appointmentRepository.Create(appointment);
    }

    /// <summary>
    /// Retrieves an appointment by its identifier.
    /// </summary>
    /// <param name="id">The appointment ID.</param>
    /// <returns>The appointment if found; otherwise, null.</returns>
    public Appointment? GetById(int id)
    {
        return appointmentRepository.GetById(id);
    }

    /// <summary>
    /// Retrieves all appointments.
    /// </summary>
    /// <returns>An enumerable collection of appointments.</returns>
    public IEnumerable<Appointment> GetAll()
    {
        return appointmentRepository.GetAll();
    }

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="id">The ID of the appointment to update.</param>
    /// <param name="appointment">The updated appointment data.</param>
    /// <returns>The updated appointment.</returns>
    public Appointment Update(int id, Appointment appointment)
    {
        return appointmentRepository.Update(id, appointment);
    }

    /// <summary>
    /// Deletes an appointment by its identifier.
    /// </summary>
    /// <param name="id">The appointment ID.</param>
    /// <returns><c>true</c> if the appointment was deleted; otherwise, <c>false</c>.</returns>
    public bool Delete(int id)
    {
        return appointmentRepository.Delete(id);
    }
}