namespace DoctorAppointment.Persistence.Interfaces;

/// <summary>
/// Defines a strategy for reading and writing data in a specific format.
/// </summary>
/// <typeparam name="T">The type of data objects to be read or written.</typeparam>
public interface IDataFormatStrategy<T>
{
    /// <summary>
    /// Reads data from the specified file path and converts it to a collection of objects.
    /// </summary>
    /// <param name="path">The file path to read data from.</param>
    /// <returns>A collection of objects of type T parsed from the file.</returns>
    /// <exception cref="System.IO.FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="System.IO.IOException">Thrown when an I/O error occurs while reading the file.</exception>
    /// <exception cref="System.FormatException">Thrown when the file contains data that cannot be parsed into type T.</exception>
    IEnumerable<T> Read(string path);

    /// <summary>
    /// Writes a collection of objects to the specified file path in the format defined by the strategy.
    /// </summary>
    /// <param name="path">The file path to write data to.</param>
    /// <param name="data">The collection of objects to write to the file.</param>
    /// <exception cref="System.IO.IOException">Thrown when an I/O error occurs while writing to the file.</exception>
    /// <exception cref="System.ArgumentNullException">Thrown when data is null.</exception>
    void Write(string path, IEnumerable<T> data);
}