using System.Collections;
using Homework_3.Interfaces;

namespace Homework_3;

/// <summary>
/// Represents a custom integer array with additional functionality such as sorting,
/// mathematical operations, and formatted output.
/// Implements <see cref="IOutput"/>, <see cref="IMath"/>, <see cref="ISort"/>, and <see cref="IEnumerable"/>.
/// </summary>
public class MyArray : IOutput, IMath, ISort, IEnumerable
{
    /// <summary>
    /// Internal storage for the array elements.
    /// </summary>
    private int[] _array;

    /// <summary>
    /// Gets the number of elements in the array.
    /// </summary>
    public int Length => _array.Length;

    /// <summary>
    /// Provides indexed access to array elements.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <returns>The element at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is invalid.</exception>
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }

            return _array[index];
        }
        set
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }

            _array[index] = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyArray"/> class with a specified size.
    /// </summary>
    /// <param name="size">The size of the array.</param>
    /// <exception cref="ArgumentException">Thrown when the size is not positive.</exception>
    public MyArray(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Array size must be positive.");

        _array = new int[size];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyArray"/> class using an existing array.
    /// </summary>
    /// <param name="initialValues">The array to copy values from.</param>
    /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
    public MyArray(int[] initialValues)
    {
        ArgumentNullException.ThrowIfNull(initialValues);

        _array = new int[initialValues.Length];
        Array.Copy(initialValues, _array, initialValues.Length);
    }

    /// <summary>
    /// Fills the array with random integers within the specified range.
    /// </summary>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The exclusive upper bound.</param>
    public void FillRandom(int min = 0, int max = 100)
    {
        Random rnd = new Random();

        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = rnd.Next(min, max);
        }
    }

    /// <summary>
    /// Displays the contents of the array to the console.
    /// </summary>
    public void Show()
    {
        foreach (var item in _array)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Displays a custom message followed by the contents of the array.
    /// </summary>
    /// <param name="info">The message to display before the array contents.</param>
    public void Show(string info)
    {
        Console.WriteLine(info);
        Show();
    }

    /// <summary>
    /// Finds the maximum value in the array.
    /// </summary>
    /// <returns>The maximum integer in the array.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
    public int Max()
    {
        if (_array.Length == 0)
        {
            throw new InvalidOperationException("Array is empty");
        }

        int max = _array[0];

        for (int i = 1; i < _array.Length; i++)
        {
            if (_array[i] > max)
            {
                max = _array[i];
            }
        }

        return max;
    }

    /// <summary>
    /// Finds the minimum value in the array.
    /// </summary>
    /// <returns>The minimum integer in the array.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
    public int Min()
    {
        if (_array.Length == 0)
        {
            throw new InvalidOperationException("Array is empty");
        }

        int min = _array[0];

        for (int i = 1; i < _array.Length; i++)
        {
            if (_array[i] < min)
            {
                min = _array[i];
            }
        }

        return min;
    }

    /// <summary>
    /// Calculates the average of all elements in the array.
    /// </summary>
    /// <returns>The average value as a float.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the array is empty.</exception>
    public float Avg()
    {
        if (_array.Length == 0)
        {
            throw new InvalidOperationException("Array is empty");
        }

        float sum = _array.Aggregate<int, float>(0, (current, t) => current + t);

        return sum / _array.Length;
    }

    /// <summary>
    /// Checks if a specific value exists in the array.
    /// </summary>
    /// <param name="valueToSearch">The value to search for.</param>
    /// <returns><c>true</c> if the value exists; otherwise, <c>false</c>.</returns>
    public bool Search(int valueToSearch)
    {
        return _array.Any(value => value == valueToSearch);
    }

    /// <summary>
    /// Sorts the array in ascending order.
    /// </summary>
    public void SortAsc()
    {
        Array.Sort(_array);
    }

    /// <summary>
    /// Sorts the array in descending order.
    /// </summary>
    public void SortDesc()
    {
        Array.Sort(_array, (a, b) => b.CompareTo(a));
    }

    /// <summary>
    /// Sorts the array in ascending or descending order based on a parameter.
    /// </summary>
    /// <param name="isAsc">If <c>true</c>, sorts in ascending order; otherwise, descending.</param>
    public void SortByParam(bool isAsc)
    {
        if (isAsc)
        {
            SortAsc();
        }
        else
        {
            SortDesc();
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the array.
    /// </summary>
    /// <returns>An enumerator for the array.</returns>
    public IEnumerator GetEnumerator() => _array.GetEnumerator();
}