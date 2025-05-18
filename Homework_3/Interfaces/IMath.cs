namespace Homework_3.Interfaces;

/// <summary>
/// Defines mathematical operations for an array-like structure.
/// </summary>
public interface IMath
{
    /// <summary>
    /// Returns the maximum value contained in the data structure.
    /// </summary>
    /// <returns>The largest integer value.</returns>
    int Max();

    /// <summary>
    /// Returns the minimum value contained in the data structure.
    /// </summary>
    /// <returns>The smallest integer value.</returns>
    int Min();

    /// <summary>
    /// Calculates the average value of the elements in the data structure.
    /// </summary>
    /// <returns>The average value as a <see cref="float"/>.</returns>
    float Avg();

    /// <summary>
    /// Searches for a specific value in the data structure.
    /// </summary>
    /// <param name="valueToSearch">The value to search for.</param>
    /// <returns><c>true</c> if the value exists; otherwise, <c>false</c>.</returns>
    bool Search(int valueToSearch);
}