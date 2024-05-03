namespace ConsoleProgramWIthObjects;

/// <summary>
/// A user entity.
/// </summary>
public sealed class User
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    public User()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="age">User's age.</param>
    public User(int age)
    {
        Age = age;
    }

    /// <summary>
    /// Gets or sets a user's first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a user's last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets a user's age.
    /// </summary>
    public int Age { get; private set; }

    /// <summary>
    /// Gets or sets a user's gender.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Overrides the default ToString() method to provide a custom string representation of the user object.
    /// </summary>
    /// <returns>A formatted string containing the user's name, age, and gender.</returns>
    public override string ToString()
    {
        var usersAgeDescription = Age < 10 ? "I am a baby" : $"I am {Age} years old";

        return $"Hi, my name is {FirstName} and last name {LastName}. {usersAgeDescription}. I am {Gender}";
    }
}