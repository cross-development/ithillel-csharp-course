namespace Homework_6;

/// <summary>
/// Entry point for the Homework_6 application.
/// Demonstrates the usage of the <see cref="Play"/> and <see cref="Store"/> classes,
/// including their disposal logic.
/// </summary>
internal class Program
{
    /// <summary>
    /// The main entry point of the application.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Testing Play ===");

        // Create and use a Play object inside a using block to ensure proper disposal
        using (var play = new Play("Hamlet", "William Shakespeare", "Tragedy", 1603))
        {
            play.ShowInfo();
        }

        Console.WriteLine("\n=== Testing Store ===");

        // Create and use a Store object, and then manually dispose it
        var store = new Store("MegaMart", "123 Main Street", StoreType.Clothing);

        store.ShowInfo();
        store.Dispose();
    }
}