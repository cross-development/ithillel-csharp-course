namespace Task_3;

/// <summary>
/// Entry point for the application that demonstrates conversion of a decimal number
/// to binary, octal, and hexadecimal numeral systems.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main method that initializes a <see cref="DecimalNumber"/> instance
    /// and outputs its representations in different numeral systems.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    private static void Main(string[] args)
    {
        var number = new DecimalNumber(255);

        Console.WriteLine($"Decimal: {number}");
        Console.WriteLine($"Binary: {number.ToBinary()}");
        Console.WriteLine($"Octal: {number.ToOctal()}");
        Console.WriteLine($"Hexadecimal: {number.ToHexadecimal()}");
    }
}