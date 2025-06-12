using System.Xml.Serialization;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.Persistence.Strategies;

/// <summary>
/// A strategy for reading and writing data in XML format.
/// </summary>
/// <typeparam name="T">The type of objects to serialize/deserialize.</typeparam>
public class XmlDataFormatStrategy<T> : IDataFormatStrategy<T>
{
    /// <summary>
    /// Reads data from an XML file at the specified path.
    /// </summary>
    /// <param name="path">The file path to read from.</param>
    /// <returns>A collection of objects read from the file.</returns>
    /// <remarks>
    /// If the file does not exist, an empty collection will be created at the specified path.
    /// </remarks>
    public IEnumerable<T> Read(string path)
    {
        if (!File.Exists(path))
        {
            Write(path, new List<T>());
        }

        using var stream = File.OpenRead(path);

        var serializer = new XmlSerializer(typeof(List<T>));

        return (List<T>)serializer.Deserialize(stream)!;
    }

    /// <summary>
    /// Writes a collection of objects to an XML file at the specified path.
    /// </summary>
    /// <param name="path">The file path to write to.</param>
    /// <param name="data">The collection of objects to write.</param>
    public void Write(string path, IEnumerable<T> data)
    {
        using var stream = File.Create(path);

        var serializer = new XmlSerializer(typeof(List<T>));
        serializer.Serialize(stream, data.ToList());
    }
}