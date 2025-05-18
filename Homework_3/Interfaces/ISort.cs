namespace Homework_3.Interfaces;

/// <summary>
/// Defines methods for sorting a collection of elements.
/// </summary>
public interface ISort
{
    /// <summary>
    /// Sorts the elements in ascending order.
    /// </summary>
    void SortAsc();

    /// <summary>
    /// Sorts the elements in descending order.
    /// </summary>
    void SortDesc();

    /// <summary>
    /// Sorts the elements based on the specified sorting direction.
    /// </summary>
    /// <param name="isAsc">If true, sorts in ascending order; otherwise, in descending order.</param>
    void SortByParam(bool isAsc);
}