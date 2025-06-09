using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Application.Interfaces;

/// <summary>
/// Service interface for managing <see cref="Patient"/> entities.
/// Provides CRUD operations for patients.
/// </summary>
public interface IPatientService
{
    /// <summary>
    /// Creates a new patient.
    /// </summary>
    /// <param name="patient">The patient to create.</param>
    /// <returns>The created patient.</returns>
    Patient Create(Patient patient);

    /// <summary>
    /// Retrieves a patient by its identifier.
    /// </summary>
    /// <param name="id">The patient ID.</param>
    /// <returns>The patient if found; otherwise, null.</returns>
    Patient? GetById(int id);

    /// <summary>
    /// Retrieves all patients.
    /// </summary>
    /// <returns>An enumerable collection of patients.</returns>
    IEnumerable<Patient> GetAll();

    /// <summary>
    /// Updates an existing patient.
    /// </summary>
    /// <param name="id">The ID of the patient to update.</param>
    /// <param name="patient">The updated patient data.</param>
    /// <returns>The updated patient.</returns>
    Patient Update(int id, Patient patient);

    /// <summary>
    /// Deletes a patient by its identifier.
    /// </summary>
    /// <param name="id">The patient ID.</param>
    /// <returns><c>true</c> if the patient was deleted; otherwise, <c>false</c>.</returns>
    bool Delete(int id);
}