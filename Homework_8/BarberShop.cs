namespace Homework_8;

/// <summary>
/// Represents a barbershop with one barber, one barber chair,
/// and a limited number of waiting room seats.
/// </summary>
public class BarberShop
{
    /// <summary>
    /// The maximum number of seats available in the waiting room.
    /// </summary>
    private readonly int _waitingRoomSeats;

    /// <summary>
    /// Queue that holds the waiting customers' IDs.
    /// </summary>
    private readonly Queue<int> _waitingCustomers = new();

    /// <summary>
    /// Object used for locking critical sections.
    /// </summary>
    private readonly object _lockObject = new();

    /// <summary>
    /// Indicates whether the barber is currently sleeping.
    /// </summary>
    private bool _barberSleeping = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="BarberShop"/> class.
    /// </summary>
    /// <param name="waitingRoomSeats">The number of seats in the waiting room.</param>
    public BarberShop(int waitingRoomSeats)
    {
        _waitingRoomSeats = waitingRoomSeats;
    }

    /// <summary>
    /// Called when a customer arrives at the barbershop.
    /// Adds them to the queue or dismisses them if no seats are available.
    /// </summary>
    /// <param name="customerId">The ID of the arriving customer.</param>
    public void CustomerArrives(int customerId)
    {
        lock (_lockObject)
        {
            if (_waitingCustomers.Count < _waitingRoomSeats)
            {
                Console.WriteLine($"Customer {customerId} enters the barbershop and waits.");
                _waitingCustomers.Enqueue(customerId);

                if (!_barberSleeping) return;

                Console.WriteLine($"Customer {customerId} wakes up the barber.");
                Monitor.Pulse(_lockObject); // Wake up the barber
            }
            else
            {
                Console.WriteLine($"Customer {customerId} leaves (no free seats).");
            }
        }
    }

    /// <summary>
    /// The barber's main working loop.
    /// If there are no customers, the barber sleeps.
    /// Otherwise, he cuts the next customer's hair.
    /// </summary>
    public void BarberWork()
    {
        while (true)
        {
            var customerId = -1;

            lock (_lockObject)
            {
                while (_waitingCustomers.Count == 0)
                {
                    Console.WriteLine("Barber goes to sleep (no customers).");

                    _barberSleeping = true;
                    Monitor.Wait(_lockObject); // Wait for a customer
                }

                _barberSleeping = false;

                customerId = _waitingCustomers.Dequeue();
            }

            // Simulate haircut
            Console.WriteLine($"Barber is cutting hair of customer {customerId}.");
            Thread.Sleep(3000); // Simulate time taken to cut hair
            Console.WriteLine($"Barber finished cutting hair of customer {customerId}.");
        }
    }
}