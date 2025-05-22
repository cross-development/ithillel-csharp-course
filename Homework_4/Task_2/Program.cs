namespace Task_2;

/// <summary>
/// The main entry point of the application that demonstrates the usage of the <see cref="City"/> class.
/// </summary>
internal class Program
{
    /// <summary>
    /// The main method where the program execution begins.
    /// Demonstrates creating city objects and using overloaded operators.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    private static void Main(string[] args)
    {
        City city1 = new City("Kyiv", 2_800_000);
        City city2 = new City("Lviv", 750_000);

        Console.WriteLine(city1);
        Console.WriteLine(city2);

        City city3 = city1 + 50_000;
        Console.WriteLine($"After population has been increased: {city3}");

        Console.WriteLine($"city1 > city2: {city1 > city2}");
    }
}