using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Repository for managing <see cref="Doctor"/> entities in the persistence layer.
/// Provides CRUD operations for doctors through the generic repository pattern.
/// </summary>
public sealed class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    /// <summary>
    /// Gets the entity type for doctor entities.
    /// </summary>
    protected override EntityType EntityType => EntityType.Doctor;

    /// <summary>
    /// Initializes a new instance of the <see cref="DoctorRepository"/> class.
    /// </summary>
    /// <param name="strategy">The data format strategy for <see cref="Doctor"/> entities.</param>
    /// <param name="context">The application context providing access to the data storage.</param>
    public DoctorRepository(IDataFormatStrategy<Doctor> strategy, IApplicationContext context)
        : base(strategy, context)
    {
        InitializePaths();
    }
}