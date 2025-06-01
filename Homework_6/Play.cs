namespace Homework_6;

/// <summary>
/// Represents a theatrical play with basic metadata such as title, author, genre, and year.
/// Implements <see cref="IDisposable"/> to allow explicit resource cleanup.
/// </summary>
public class Play : IDisposable
{
    /// <summary>
    /// Field to track whether the instance has been disposed.
    /// </summary>
    private bool _disposed = false;

    /// <summary>
    /// Gets or sets the title of the play.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the play.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets the genre of the play.
    /// </summary>
    public string Genre { get; set; }

    /// <summary>
    /// Gets or sets the year the play was written or released.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Play"/> class with the specified title, author, genre, and year.
    /// </summary>
    /// <param name="title">The title of the play.</param>
    /// <param name="author">The author of the play.</param>
    /// <param name="genre">The genre of the play.</param>
    /// <param name="year">The year the play was created or released.</param>
    public Play(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    /// <summary>
    /// Displays the basic information of the play to the console.
    /// </summary>
    public void ShowInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}");
    }

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="Play"/> class.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="Play"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // Free managed resources here, if any
            Console.WriteLine($"Disposing Play: {Title}");
        }

        // Free unmanaged resources here, if any

        _disposed = true;
    }

    /// <summary>
    /// Finalizer that ensures resources are released if Dispose is not called explicitly.
    /// </summary>
    ~Play()
    {
        Dispose(false);
    }
}
