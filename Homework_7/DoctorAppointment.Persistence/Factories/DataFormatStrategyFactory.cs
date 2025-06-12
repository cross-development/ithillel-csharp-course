using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Persistence.Interfaces;
using DoctorAppointment.Persistence.Strategies;

namespace DoctorAppointment.Persistence.Factories;

/// <summary>
/// Factory for creating data format strategy instances based on the specified format type.
/// </summary>
public static class DataFormatStrategyFactory
{
    /// <summary>
    /// Creates and returns a data format strategy for the specified format type.
    /// </summary>
    /// <typeparam name="T">The type of objects the strategy will handle.</typeparam>
    /// <param name="format">The data format type to create a strategy for.</param>
    /// <returns>An implementation of IDataFormatStrategy for the specified format.</returns>
    /// <exception cref="NotSupportedException">Thrown when the specified format is not supported.</exception>
    public static IDataFormatStrategy<T> Create<T>(DataFormatType format) where T : class
    {
        return format switch
        {
            DataFormatType.Json => new JsonDataFormatStrategy<T>(),
            DataFormatType.Xml => new XmlDataFormatStrategy<T>(),
            _ => throw new NotSupportedException($"Data format '{format}' is not supported.")
        };
    }
}