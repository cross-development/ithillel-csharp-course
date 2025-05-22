namespace Task_3;

/// <summary>
/// Demonstrates the usage of the <see cref="CreditCard"/> class.
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point of the program. Creates credit cards, displays their data,
    /// performs a deposit operation, and compares their balances.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    private static void Main(string[] args)
    {
        CreditCard card1 = new CreditCard("1234-5678-9012-3456", "123", 15_000);
        CreditCard card2 = new CreditCard("9876-5432-1098-7654", "456", 20_000);

        Console.WriteLine(card1);
        Console.WriteLine(card2);

        CreditCard card3 = card1 + 5_000;
        Console.WriteLine($"After deposit: {card3}");

        Console.WriteLine($"card1 < card2: {card1 < card2}");
    }
}