using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Application.Interfaces;

/// <summary>
/// Service interface for managing <see cref="Doctor"/> entities.
/// Provides CRUD operations for doctors.
/// </summary>
public interface IDoctorService
{
    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="doctor">The doctor to create.</param>
    /// <returns>The created doctor.</returns>
    Doctor Create(Doctor doctor);

    /// <summary>
    /// Retrieves a doctor by its identifier.
    /// </summary>
    /// <param name="id">The doctor ID.</param>
    /// <returns>The doctor if found; otherwise, null.</returns>
    Doctor? GetById(int id);

    /// <summary>
    /// Retrieves all doctors.
    /// </summary>
    /// <returns>An enumerable collection of doctors.</returns>
    IEnumerable<Doctor> GetAll();

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="id">The ID of the doctor to update.</param>
    /// <param name="doctor">The updated doctor data.</param>
    /// <returns>The updated doctor.</returns>
    Doctor Update(int id, Doctor doctor);

    /// <summary>
    /// Deletes a doctor by its identifier.
    /// </summary>
    /// <param name="id">The doctor ID.</param>
    /// <returns><c>true</c> if the doctor was deleted; otherwise, <c>false</c>.</returns>
    bool Delete(int id);
}