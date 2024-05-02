using System.Text.RegularExpressions;

namespace ConsoleProgramWIthObjects;

/// <summary>
/// Entry class of the program.
/// </summary>
public static class Program
{
    /// <summary>
    /// Delegate for methods that validate user input and output the result.
    /// </summary>
    /// <typeparam name="T">The type of the result to be output.</typeparam>
    /// <param name="input">The input string to be validated.</param>
    /// <param name="result">Output parameter containing the validated result.</param>
    /// <returns>True if the input string is valid and the result is successfully output; otherwise, false.</returns>
    private delegate bool ValidateDelegate<T>(string input, out T result);

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the program.</param>
    private static void Main(string[] args)
    {
        var user1 = CreateUser(5);
        Console.WriteLine(user1 + "\n");

        var user2 = CreateUser(15);
        Console.WriteLine(user2);

        Console.ReadKey();
    }

    /// <summary>
    /// Creates a new user object with the specified age, prompting the user for additional information such as first name, last name, and gender.
    /// </summary>
    /// <param name="age">The age of the user to be created.</param>
    /// <returns>A new User object initialized with the specified age and additional information provided by the user.</returns>
    private static User CreateUser(int age)
    {
        var user = new User(age);

        user.FirstName = GetUserInput<string>("Enter your first name: ", ValidateUserName);
        user.LastName = GetUserInput<string>("Enter your last name: ", ValidateUserName);
        user.Gender = GetUserInput<Gender>("Enter your gender (Male, Female, Unknown): ", ValidateUserGender);

        return user;
    }

    /// <summary>
    /// Validates user input as a name against a regular expression pattern.
    /// </summary>
    /// <param name="input">The input string to be validated as a name.</param>
    /// <param name="userChoice">Output parameter containing the validated user input if valid.</param>
    /// <returns>True if the input string matches the specified pattern; otherwise, false.</returns>
    private static bool ValidateUserName(string input, out string userChoice)
    {
        bool isValid = Regex.IsMatch(input, @"^[A-Za-z]+(?:[\s'-][A-Za-z]+)*$");

        userChoice = isValid ? input : string.Empty;

        return isValid;
    }

    /// <summary>
    /// Validates user input as a gender by attempting to parse it into the Gender enumeration.
    /// </summary>
    /// <param name="input">The input string to be validated as a gender.</param>
    /// <param name="userChoice">Output parameter with validated <see cref="Gender"/>.</param>
    /// <returns>True if the input string represents a valid gender; otherwise, false.</returns>
    private static bool ValidateUserGender(string input, out Gender userChoice)
    {
        return Enum.TryParse(input, out userChoice) && Enum.IsDefined(typeof(Gender), userChoice);
    }

    /// <summary>
    /// Prompts the user with a message and validates their input using a custom validation function.
    /// </summary>
    /// <param name="message">The message to display to the user as a prompt for input.</param>
    /// <param name="validate">A predicate function that validates the user's input.</param>
    /// <returns>The user's valid input as a string.</returns>
    private static T GetUserInput<T>(string message, ValidateDelegate<T> validate)
    {
        T userChoice = default!;
        bool isChoiceValid = false;

        do
        {
            Console.Write(message);

            string? userInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(userInput) && validate(userInput, out userChoice))
            {
                isChoiceValid = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid text.");
            }
        }
        while (!isChoiceValid);

        return userChoice;
    }
}
