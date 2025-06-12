using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Repository for managing <see cref="Patient"/> entities in the persistence layer.
/// Provides CRUD operations for patients through the generic repository pattern.
/// </summary>
public sealed class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    /// <summary>
    /// Gets the entity type for patient entities.
    /// </summary>
    protected override EntityType EntityType => EntityType.Patient;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatientRepository"/> class.
    /// </summary>
    /// <param name="strategy">The data format strategy for <see cref="Patient"/> entities.</param>
    /// <param name="context">The application context providing access to the data storage.</param>
    public PatientRepository(IDataFormatStrategy<Patient> strategy, IApplicationContext context)
        : base(strategy, context)
    {
        InitializePaths();
    }
}