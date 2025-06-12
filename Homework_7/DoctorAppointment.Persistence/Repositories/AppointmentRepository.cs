using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Repository for managing <see cref="Appointment"/> entities in the persistence layer.
/// Provides CRUD operations for appointments through the generic repository pattern.
/// </summary>
public sealed class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    /// <summary>
    /// Gets the entity type for appointment entities.
    /// </summary>
    protected override EntityType EntityType => EntityType.Appointment;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentRepository"/> class.
    /// </summary>
    /// <param name="strategy">The data format strategy for <see cref="Appointment"/> entities.</param>
    /// <param name="context">The application context providing access to data storage.</param>
    public AppointmentRepository(IDataFormatStrategy<Appointment> strategy, IApplicationContext context)
        : base(strategy, context)
    {
        InitializePaths();
    }
}