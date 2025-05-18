namespace Homework_3;

/// <summary>
/// Entry point class demonstrating usage of the MyArray class and its implemented interfaces.
/// </summary>
internal class Program
{
    /// <summary>
    /// The main entry point of the application.
    /// Demonstrates:
    /// - Creating and manipulating arrays using MyArray class,
    /// - Filling arrays with random values,
    /// - Accessing and modifying elements,
    /// - Using search, min, max, average calculations,
    /// - Sorting arrays in ascending and descending order.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    private static void Main(string[] args)
    {
        // TASK 1 - usage
        Console.WriteLine("// TASK 1 - usage");
        var array1 = new MyArray(5);

        array1.FillRandom();

        Console.WriteLine($"First element: {array1[0]}");

        array1[2] = 555;

        array1.Show("Modified array:");

        Console.WriteLine("All elements:");

        foreach (int x in array1)
        {
            Console.WriteLine(x);
        }

        Console.WriteLine("Length: " + array1.Length);

        // TASK 2 - usage
        Console.WriteLine("\n// TASK 2 - usage");
        MyArray array2 = new MyArray(10);

        array2.FillRandom();

        array2.Show("Randomized array:");

        Console.WriteLine("Max value: " + array2.Max());

        Console.WriteLine("Min value: " + array2.Min());

        Console.WriteLine("Average value: " + array2.Avg());

        Console.Write("Enter number to search: ");

        if (int.TryParse(Console.ReadLine(), out int searchValue))
        {
            bool found = array2.Search(searchValue);
            Console.WriteLine(found ? "Value found!" : "Value not found.");
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }

        // TASK 3 - usage
        Console.WriteLine("\n// TASK 3 - usage");
        MyArray array3 = new MyArray(15);

        array3.FillRandom();

        array3.Show("Original array:");

        array3.SortAsc();
        array3.Show("Sorted ascending:");

        array3.SortDesc();
        array3.Show("Sorted descending:");

        Console.Write("Sort ascending again? (y/n): ");

        string input = Console.ReadLine();

        bool isAsc = input?.ToLower() == "y";

        array3.SortByParam(isAsc);
        array3.Show(isAsc ? "Sorted by parameter: ascending" : "Sorted by parameter: descending");
    }
}