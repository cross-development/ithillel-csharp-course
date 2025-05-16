namespace Task_2.MusicalInstruments;

/// <summary>
/// Represents a violin, a type of string musical instrument.
/// </summary>
public class Violin : MusicalInstrument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Violin"/> class.
    /// </summary>
    /// <param name="name">The name of the violin.</param>
    public Violin(string name)
        : base(
            name,
            "A string instrument played with a bow",
            "Originated in Italy in the 16th century")
    {
    }

    /// <summary>
    /// Plays the characteristic sound of a violin.
    /// </summary>
    public override void Sound()
    {
        Console.WriteLine("Violin plays a melodic sound");
    }
}