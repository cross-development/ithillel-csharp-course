using Newtonsoft.Json;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.Persistence.Configuration;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Repositories;

/// <summary>
/// A generic repository base class for persistence operations on auditable entities.
/// </summary>
/// <typeparam name="TSource">The type of entity managed by this repository.</typeparam>
/// <param name="strategy">The data format strategy used for reading and writing entities.</param>
/// <param name="context">The application context containing configuration settings.</param>
public abstract class GenericRepository<TSource>(IDataFormatStrategy<TSource> strategy, IApplicationContext context)
    : IGenericRepository<TSource> where TSource : Auditable
{
    /// <summary>
    /// Gets or sets the file path where the data is stored.
    /// </summary>
    protected string Path { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last used unique identifier for the entity.
    /// </summary>
    protected int LastId { get; private set; }

    /// <summary>
    /// Gets the type of the entity represented by this instance.
    /// </summary>
    protected abstract EntityType EntityType { get; }

    /// <summary>
    /// Creates a new entity, assigns it an ID and creation date, and stores it in the data file.
    /// </summary>
    /// <param name="source">The entity to be created.</param>
    /// <returns>The created entity with updated ID and timestamp.</returns>
    public TSource Create(TSource source)
    {
        source.Id = ++LastId;
        source.CreatedAt = DateTime.UtcNow;

        var sources = GetAll().Append(source).ToList();

        strategy.Write(Path, sources);
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
            strategy.Write(Path, new List<TSource>());
        }

        return strategy.Read(Path);
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

        var sources = GetAll().Select(s => s.Id == id ? source : s).ToList();

        strategy.Write(Path, sources);

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

        strategy.Write(Path, sources);

        return true;
    }

    /// <summary>
    /// Initializes the paths and identifiers required for entity processing.
    /// </summary>
    /// <remarks>This method retrieves configuration settings from the application and sets the  <see
    /// cref="Path"/> and <see cref="LastId"/> properties based on the entity table  associated with the current context
    /// and entity type.</remarks>
    protected void InitializePaths()
    {
        var config = ReadFromAppSettings();
        var table = config.GetEntityTable(context.Format, EntityType);

        Path = table.Path;
        LastId = table.LastId;
    }

    /// <summary>
    /// Saves the last processed entity ID to the application settings file.
    /// </summary>
    /// <remarks>This method updates the application settings with the current value of <see cref="LastId"/>
    /// for the specified entity type and format, and writes the updated configuration back to the settings file. Ensure
    /// that the application has write access to the settings file path defined in <see
    /// cref="Constants.AppSettingsPath"/>.</remarks>
    protected void SaveLastId()
    {
        var config = ReadFromAppSettings();
        var table = config.GetEntityTable(context.Format, EntityType);

        table.LastId = LastId;
        config.SetEntityTable(context.Format, EntityType, table);

        var json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(Constants.AppSettingsPath, json);
    }

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