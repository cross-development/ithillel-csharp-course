namespace Task_2.MusicalInstruments;

/// <summary>
/// Represents a trombone, a brass instrument with a slide.
/// </summary>
public class Trombone : MusicalInstrument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Trombone"/> class.
    /// </summary>
    /// <param name="name">The name of the trombone.</param>
    public Trombone(string name)
        : base(
            name,
            "A brass instrument with a slide",
            "Developed in the 15th century")
    {
    }

    /// <summary>
    /// Plays the characteristic sound of a trombone.
    /// </summary>
    public override void Sound()
    {
        Console.WriteLine("Trombone produces a deep brass sound");
    }
}