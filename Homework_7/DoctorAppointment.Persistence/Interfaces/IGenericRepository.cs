using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Persistence.Interfaces;

/// <summary>
/// Defines generic CRUD operations for entities that inherit from <see cref="Auditable"/>.
/// </summary>
/// <typeparam name="TSource">The entity type.</typeparam>
public interface IGenericRepository<TSource> where TSource : Auditable
{
    /// <summary>
    /// Creates a new entity in the data store.
    /// </summary>
    /// <param name="source">The entity to create.</param>
    /// <returns>The created entity.</returns>
    TSource Create(TSource source);

    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    TSource? GetById(int id);

    /// <summary>
    /// Retrieves all entities from the data store.
    /// </summary>
    /// <returns>A collection of all entities.</returns>
    IEnumerable<TSource> GetAll();

    /// <summary>
    /// Updates an existing entity with new data.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to update.</param>
    /// <param name="source">The updated entity data.</param>
    /// <returns>The updated entity.</returns>
    TSource Update(int id, TSource source);

    /// <summary>
    /// Deletes the entity with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns><c>true</c> if deletion was successful; otherwise, <c>false</c>.</returns>
    bool Delete(int id);
}