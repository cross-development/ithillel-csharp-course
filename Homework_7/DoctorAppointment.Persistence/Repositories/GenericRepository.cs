using Newtonsoft.Json;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Persistence.Configuration;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// Provides a generic implementation of basic CRUD operations for a given entity type.
/// Uses JSON file storage to persist entities.
/// </summary>
/// <typeparam name="TSource">The type of entity, which must inherit from <see cref="Auditable"/>.</typeparam>
public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
{
    /// <summary>
    /// Gets or sets the file path where the data is stored.
    /// </summary>
    protected abstract string Path { get; set; }

    /// <summary>
    /// Gets or sets the last used unique identifier for the entity.
    /// </summary>
    protected abstract int LastId { get; set; }

    /// <summary>
    /// Creates a new entity, assigns it an ID and creation date, and stores it in the data file.
    /// </summary>
    /// <param name="source">The entity to be created.</param>
    /// <returns>The created entity with updated ID and timestamp.</returns>
    public TSource Create(TSource source)
    {
        source.Id = ++LastId;
        source.CreatedAt = DateTime.UtcNow;

        var sources = GetAll().Append(source);

        File.WriteAllText(Path, JsonConvert.SerializeObject(sources, Formatting.Indented));
        SaveLastId();

        return source;
    }

    /// <summary>
    /// Retrieves a single entity by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified ID, or null if not found.</returns>
    public TSource? GetById(int id)
    {
        return GetAll().FirstOrDefault(s => s.Id == id);
    }

    /// <summary>
    /// Retrieves all entities from the data file.
    /// </summary>
    /// <returns>A collection of all entities.</returns>
    public IEnumerable<TSource> GetAll()
    {
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }

        var json = File.ReadAllText(Path);

        if (string.IsNullOrWhiteSpace(json))
        {
            File.WriteAllText(Path, "[]");
            json = "[]";
        }

        return JsonConvert.DeserializeObject<List<TSource>>(json)!;
    }

    /// <summary>
    /// Updates an existing entity by ID and overwrites it in the data file.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="source">The updated entity data.</param>
    /// <returns>The updated entity with a new timestamp.</returns>
    public TSource Update(int id, TSource source)
    {
        source.Id = id;
        source.UpdatedAt = DateTime.UtcNow;

        var sources = GetAll().Select(s => s.Id == id ? source : s);

        File.WriteAllText(Path, JsonConvert.SerializeObject(sources, Formatting.Indented));

        return source;
    }

    /// <summary>
    /// Deletes an entity with the specified ID from the data file.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <returns>True if the entity was found and deleted; otherwise, false.</returns>
    public bool Delete(int id)
    {
        var existingSource = GetById(id);

        if (existingSource is null)
        {
            return false;
        }

        var sources = GetAll().Where(s => s.Id != id).ToList();

        File.WriteAllText(Path, JsonConvert.SerializeObject(sources, Formatting.Indented));

        return true;
    }

    /// <summary>
    /// Saves the current last used ID. Must be implemented by the concrete repository.
    /// </summary>
    protected abstract void SaveLastId();

    /// <summary>
    /// Reads and deserializes application configuration from the appsettings file.
    /// </summary>
    /// <returns>The deserialized <see cref="AppSettingsConfiguration"/> object.</returns>
    protected AppSettingsConfiguration ReadFromAppSettings()
    {
        var appSettings = File.ReadAllText(Constants.AppSettingsPath);

        return JsonConvert.DeserializeObject<AppSettingsConfiguration>(appSettings)!;
    }
}