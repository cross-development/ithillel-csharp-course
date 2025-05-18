namespace Homework_3.Interfaces;

/// <summary>
/// Defines methods for displaying the contents of a data structure.
/// </summary>
public interface IOutput
{
    /// <summary>
    /// Displays the contents of the data structure.
    /// </summary>
    void Show();

    /// <summary>
    /// Displays a message followed by the contents of the data structure.
    /// </summary>
    /// <param name="info">The informational message to display before the data.</param>
    void Show(string info);
}