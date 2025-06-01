namespace Homework_6;

/// <summary>
/// Represents a retail store with a name, address, and type.
/// Implements <see cref="IDisposable"/> for resource management.
/// </summary>
public class Store : IDisposable
{
    /// <summary>
    /// Field to track whether the instance has been disposed.
    /// </summary>
    private bool _disposed = false;

    /// <summary>
    /// Gets or sets the name of the store.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the store.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the type of the store (e.g., Grocery, Electronics).
    /// </summary>
    public StoreType Type { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Store"/> class with the specified name, address, and type.
    /// </summary>
    /// <param name="name">The name of the store.</param>
    /// <param name="address">The physical address of the store.</param>
    /// <param name="type">The type of the store, defined by the <see cref="StoreType"/> enum.</param>
    public Store(string name, string address, StoreType type)
    {
        Name = name;
        Address = address;
        Type = type;
    }

    /// <summary>
    /// Displays the store's details to the console.
    /// </summary>
    public void ShowInfo()
    {
        Console.WriteLine($"Store Name: {Name}, Address: {Address}, Type: {Type}");
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="Store"/> and optionally releases the managed resources.
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
            Console.WriteLine($"Disposing Store: {Name}");
        }

        // Free unmanaged resources here, if any

        _disposed = true;
    }

    /// <summary>
    /// Finalizer that ensures unmanaged resources are released if Dispose is not called.
    /// </summary>
    ~Store()
    {
        Dispose(false);
    }
}
