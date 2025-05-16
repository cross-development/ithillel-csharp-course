namespace Task_2.MusicalInstruments;

/// <summary>
/// Represents a ukulele, a small four-stringed Hawaiian guitar.
/// </summary>
public class Ukulele : MusicalInstrument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ukulele"/> class.
    /// </summary>
    /// <param name="name">The name of the ukulele.</param>
    public Ukulele(string name)
        : base(
            name,
            "A small four-stringed Hawaiian guitar",
            "Originated in the 19th century in Hawaii")
    {
    }

    /// <summary>
    /// Plays the characteristic sound of a ukulele.
    /// </summary>
    public override void Sound()
    {
        Console.WriteLine("Ukulele produces a bright, cheerful sound");
    }
}