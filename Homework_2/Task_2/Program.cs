using Task_2.MusicalInstruments;

namespace Task_2;

/// <summary>
/// Entry point of the musical instruments demo application.
/// </summary>
internal class Program
{
    /// <summary>
    /// The main method that creates and demonstrates different musical instruments.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        MusicalInstrument[] instruments =
        [
            new Violin("Super Violin"),
            new Trombone("Powerful Trombone"),
            new Ukulele("Incredible Ukulele"),
            new Cello("Wonderful Cello")
        ];

        foreach (var instrument in instruments)
        {
            instrument.Show();
            instrument.Sound();
            instrument.Desc();
            instrument.History();

            Console.WriteLine();
        }
    }
}