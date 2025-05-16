namespace Task_2.MusicalInstruments;

/// <summary>
/// Represents the base class for all musical instruments, 
/// including common properties such as name, description, and history.
/// </summary>
public abstract class MusicalInstrument
{
    /// <summary>
    /// The name of the musical instrument.
    /// </summary>
    private readonly string _name;

    /// <summary>
    /// A brief description of the instrument.
    /// </summary>
    private readonly string _description;

    /// <summary>
    /// Historical information about the instrument.
    /// </summary>
    private readonly string _history;

    /// <summary>
    /// Initializes a new instance of the <see cref="MusicalInstrument"/> class.
    /// </summary>
    /// <param name="name">The name of the instrument.</param>
    /// <param name="description">A brief description of the instrument.</param>
    /// <param name="history">The historical background of the instrument.</param>
    /// <exception cref="ArgumentException">Thrown when the name is null, empty, or whitespace.</exception>
    protected MusicalInstrument(string name, string description, string history)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The name of the tool cannot be empty!");
        }

        _name = name;
        _description = description;
        _history = history;
    }

    /// <summary>
    /// Plays the sound of the instrument (to be implemented in derived classes).
    /// </summary>
    public abstract void Sound();

    /// <summary>
    /// Displays the name of the musical instrument.
    /// </summary>
    public virtual void Show()
    {
        Console.WriteLine($"Musical instrument: {_name}");
    }

    /// <summary>
    /// Displays the description of the musical instrument.
    /// </summary>
    public virtual void Desc()
    {
        Console.WriteLine($"Description: {_description}");
    }

    /// <summary>
    /// Displays the historical information about the musical instrument.
    /// </summary>
    public virtual void History()
    {
        Console.WriteLine($"History: {_history}");
    }
}