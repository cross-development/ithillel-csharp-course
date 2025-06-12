using Newtonsoft.Json;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Strategies;

/// <summary>
/// Implements the data format strategy pattern for JSON serialization and deserialization.
/// </summary>
/// <typeparam name="T">The type of data to serialize and deserialize.</typeparam>
public class JsonDataFormatStrategy<T> : IDataFormatStrategy<T>
{
    /// <summary>
    /// Reads data from the specified file path and deserializes it from JSON.
    /// If the file doesn't exist, creates a new empty file.
    /// </summary>
    /// <param name="path">The file path to read from.</param>
    /// <returns>A collection of deserialized objects or an empty collection if the file is empty or invalid.</returns>
    public IEnumerable<T> Read(string path)
    {
        if (!File.Exists(path))
        {
            Write(path, new List<T>());
        }

        var json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
    }

    /// <summary>
    /// Serializes the provided data to JSON format and writes it to the specified file path.
    /// </summary>
    /// <param name="path">The file path to write to.</param>
    /// <param name="data">The data to serialize and write.</param>
    public void Write(string path, IEnumerable<T> data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(path, json);
    }
}