using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Application.Services;

/// <summary>
/// Service implementation for managing <see cref="Patient"/> entities.
/// Delegates CRUD operations to the injected <see cref="IPatientRepository"/>.
/// </summary>
public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    /// <summary>
    /// Creates a new patient.
    /// </summary>
    /// <param name="patient">The patient to create.</param>
    /// <returns>The created patient.</returns>
    public Patient Create(Patient patient)
    {
        return patientRepository.Create(patient);
    }

    /// <summary>
    /// Retrieves a patient by its identifier.
    /// </summary>
    /// <param name="id">The patient ID.</param>
    /// <returns>The patient if found; otherwise, null.</returns>
    public Patient? GetById(int id)
    {
        return patientRepository.GetById(id);
    }

    /// <summary>
    /// Retrieves all patients.
    /// </summary>
    /// <returns>An enumerable collection of patients.</returns>
    public IEnumerable<Patient> GetAll()
    {
        return patientRepository.GetAll();
    }

    /// <summary>
    /// Updates an existing patient.
    /// </summary>
    /// <param name="id">The ID of the patient to update.</param>
    /// <param name="patient">The updated patient data.</param>
    /// <returns>The updated patient.</returns>
    public Patient Update(int id, Patient patient)
    {
        return patientRepository.Update(id, patient);
    }

    /// <summary>
    /// Deletes a patient by its identifier.
    /// </summary>
    /// <param name="id">The patient ID.</param>
    /// <returns><c>true</c> if the patient was deleted; otherwise, <c>false</c>.</returns>
    public bool Delete(int id)
    {
        return patientRepository.Delete(id);
    }
}