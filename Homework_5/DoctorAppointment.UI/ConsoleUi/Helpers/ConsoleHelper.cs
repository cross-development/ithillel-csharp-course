namespace DoctorAppointment.UI.ConsoleUi.Helpers;

/// <summary>
/// Provides helper methods for reading various types of input from the console,
/// with support for optional default values and input validation.
/// </summary>
public static class ConsoleHelper
{
    /// <summary>
    /// Reads an integer value from the console.
    /// Prompts the user with a message and optionally displays a default value.
    /// Repeats until a valid integer is entered or default is accepted.
    /// </summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="defaultValue">An optional default integer value.</param>
    /// <returns>The integer value read from the user input or the default value.</returns>
    public static int ReadInt(string prompt, int? defaultValue = null)
    {
        Console.Write($"{prompt}{(defaultValue.HasValue ? $" ({defaultValue.Value})" : "")}: ");

        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return defaultValue ?? ReadInt(prompt, defaultValue);
        }

        return int.TryParse(input, out var result) ? result : ReadInt(prompt, defaultValue);
    }

    /// <summary>
    /// Reads a string value from the console.
    /// Prompts the user with a message and optionally displays a default value.
    /// Can optionally allow empty input.
    /// </summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="defaultValue">An optional default string value.</param>
    /// <param name="allowEmpty">Indicates whether empty input is allowed.</param>
    /// <returns>The string value read from the user input or the default value.</returns>
    public static string ReadString(string prompt, string? defaultValue = null, bool allowEmpty = false)
    {
        Console.Write($"{prompt}{(defaultValue != null ? $" ({defaultValue})" : "")}: ");

        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return defaultValue ?? (allowEmpty ? string.Empty : ReadString(prompt, defaultValue, allowEmpty));
        }

        return input;
    }

    /// <summary>
    /// Reads a decimal value from the console.
    /// Prompts the user with a message and optionally displays a default value.
    /// Repeats until a valid decimal is entered or default is accepted.
    /// </summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="defaultValue">An optional default decimal value.</param>
    /// <returns>The decimal value read from the user input or the default value.</returns>
    public static decimal ReadDecimal(string prompt, decimal? defaultValue = null)
    {
        Console.Write($"{prompt}{(defaultValue.HasValue ? $" ({defaultValue.Value})" : "")}: ");

        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return defaultValue ?? ReadDecimal(prompt, defaultValue);
        }

        return decimal.TryParse(input, out var result) ? result : ReadDecimal(prompt, defaultValue);
    }

    /// <summary>
    /// Reads a DateTime value from the console.
    /// Prompts the user with a message and optionally displays a default value.
    /// Repeats until a valid DateTime is entered or default is accepted.
    /// </summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="defaultValue">An optional default DateTime value.</param>
    /// <returns>The DateTime value read from the user input or the default value.</returns>
    public static DateTime ReadDateTime(string prompt, DateTime? defaultValue = null)
    {
        Console.Write($"{prompt}{(defaultValue.HasValue ? $" ({defaultValue.Value})" : "")}: ");

        var input = Console.ReadLine();

        if (DateTime.TryParse(input, out var dt))
        {
            return dt;
        }

        return defaultValue ?? ReadDateTime(prompt, defaultValue);
    }

    /// <summary>
    /// Reads an enum value of type <typeparamref name="T"/> from the console.
    /// Displays all possible enum options to the user, prompts for input,
    /// and optionally uses a default value.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="defaultValue">An optional default enum value.</param>
    /// <returns>The enum value parsed from user input or the default value.</returns>
    public static T ReadEnum<T>(string prompt, T? defaultValue = null) where T : struct, Enum
    {
        Console.WriteLine($"{prompt} Options:");

        var options = Enum.GetNames<T>();

        for (var i = 1; i <= options.Length; i++)
        {
            Console.WriteLine($"{i} - {options[i - 1]}");
        }

        Console.Write($"{prompt}{(defaultValue.HasValue ? $" ({defaultValue.Value})" : "")}: ");

        var input = Console.ReadLine();

        return Enum.TryParse(input, true, out T result) ? result : defaultValue.GetValueOrDefault();
    }
}