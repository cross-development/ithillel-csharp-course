namespace Task_2.MusicalInstruments;

/// <summary>
/// Represents a cello, a large string instrument played with a bow.
/// </summary>
public class Cello : MusicalInstrument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Cello"/> class.
    /// </summary>
    /// <param name="name">The name of the cello.</param>
    public Cello(string name)
        : base(
            name,
            "A large string instrument played with a bow",
            "Developed in the early 16th century")
    {
    }

    /// <summary>
    /// Plays the characteristic sound of a cello.
    /// </summary>
    public override void Sound()
    {
        Console.WriteLine("Cello plays a deep, rich sound");
    }
}