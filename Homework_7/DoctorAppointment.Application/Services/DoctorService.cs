using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Application.Services;

/// <summary>
/// Service implementation for managing <see cref="Doctor"/> entities.
/// Delegates CRUD operations to the injected <see cref="IDoctorRepository"/>.
/// </summary>
public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="doctor">The doctor to create.</param>
    /// <returns>The created doctor.</returns>
    public Doctor Create(Doctor doctor)
    {
        return doctorRepository.Create(doctor);
    }

    /// <summary>
    /// Retrieves a doctor by its identifier.
    /// </summary>
    /// <param name="id">The doctor ID.</param>
    /// <returns>The doctor if found; otherwise, null.</returns>
    public Doctor? GetById(int id)
    {
        return doctorRepository.GetById(id);
    }

    /// <summary>
    /// Retrieves all doctors.
    /// </summary>
    /// <returns>An enumerable collection of doctors.</returns>
    public IEnumerable<Doctor> GetAll()
    {
        return doctorRepository.GetAll();
    }

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="id">The ID of the doctor to update.</param>
    /// <param name="doctor">The updated doctor data.</param>
    /// <returns>The updated doctor.</returns>
    public Doctor Update(int id, Doctor doctor)
    {
        return doctorRepository.Update(id, doctor);
    }

    /// <summary>
    /// Deletes a doctor by its identifier.
    /// </summary>
    /// <param name="id">The doctor ID.</param>
    /// <returns><c>true</c> if the doctor was deleted; otherwise, <c>false</c>.</returns>
    public bool Delete(int id)
    {
        return doctorRepository.Delete(id);
    }
}