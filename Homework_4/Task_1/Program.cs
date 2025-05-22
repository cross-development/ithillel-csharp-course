namespace Task_1;

/// <summary>
/// Demonstrates usage of the <see cref="Employee"/> class and its operator overloads.
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point of the program. Creates and compares <see cref="Employee"/> objects, and demonstrates salary operations.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    private static void Main(string[] args)
    {
        Employee emp1 = new Employee("John", 25_000);
        Employee emp2 = new Employee("Jane", 30_000);

        Console.WriteLine(emp1);
        Console.WriteLine(emp2);

        Employee emp3 = emp1 + 5_000;
        Console.WriteLine($"After promotion: {emp3}");

        Console.WriteLine($"emp1 == emp2: {emp1 == emp2}");
        Console.WriteLine($"emp1 < emp2: {emp1 < emp2}");
    }
}
