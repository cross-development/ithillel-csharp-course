using DoctorAppointment.Domain.Interfaces;
using DoctorAppointment.Persistence.Factories;
using DoctorAppointment.Persistence.Interfaces;

namespace DoctorAppointment.UI.Infrastructure;

/// <summary>
/// Resolves and delegates to the appropriate data format strategy based on the application context.
/// </summary>
/// <typeparam name="T">The type of data to read or write.</typeparam>
/// <param name="context">The application context containing format information.</param>
public class FormatStrategyResolver<T>(IApplicationContext context)
    : IDataFormatStrategy<T> where T : class
{
    private readonly IDataFormatStrategy<T> _inner = DataFormatStrategyFactory.Create<T>(context.Format);

    /// <summary>
    /// Reads data of type <typeparamref name="T"/> from the specified path using the resolved format strategy.
    /// </summary>
    /// <param name="path">The path to read data from.</param>
    /// <returns>A collection of data items of type <typeparamref name="T"/>.</returns>
    public IEnumerable<T> Read(string path) => _inner.Read(path);

    /// <summary>
    /// Writes data of type <typeparamref name="T"/> to the specified path using the resolved format strategy.
    /// </summary>
    /// <param name="path">The path to write data to.</param>
    /// <param name="data">The collection of data items to write.</param>
    public void Write(string path, IEnumerable<T> data) => _inner.Write(path, data);
}