using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Application.Interfaces;

/// <summary>
/// Service interface for managing <see cref="Appointment"/> entities.
/// Provides CRUD operations for appointments.
/// </summary>
public interface IAppointmentService
{
    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="appointment">The appointment to create.</param>
    /// <returns>The created appointment.</returns>
    Appointment Create(Appointment appointment);

    /// <summary>
    /// Retrieves an appointment by its identifier.
    /// </summary>
    /// <param name="id">The appointment ID.</param>
    /// <returns>The appointment if found; otherwise, null.</returns>
    Appointment? GetById(int id);

    /// <summary>
    /// Retrieves all appointments.
    /// </summary>
    /// <returns>An enumerable collection of appointments.</returns>
    IEnumerable<Appointment> GetAll();

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="id">The ID of the appointment to update.</param>
    /// <param name="appointment">The updated appointment data.</param>
    /// <returns>The updated appointment.</returns>
    Appointment Update(int id, Appointment appointment);

    /// <summary>
    /// Deletes an appointment by its identifier.
    /// </summary>
    /// <param name="id">The appointment ID.</param>
    /// <returns><c>true</c> if the appointment was deleted; otherwise, <c>false</c>.</returns>
    bool Delete(int id);
}