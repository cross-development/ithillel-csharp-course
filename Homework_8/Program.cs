using Homework_8;

/// <summary>
/// Main program class that simulates customer arrivals and starts the barber thread.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    public static void Main()
    {
        var shop = new BarberShop(waitingRoomSeats: 3);

        var barberThread = new Thread(shop.BarberWork) { IsBackground = true };
        barberThread.Start();

        var customerId = 1;
        var rand = new Random();

        while (true)
        {
            // New customer every 1-3 seconds
            Thread.Sleep(rand.Next(1000, 3000));

            var id = customerId++;
            var customerThread = new Thread(() => shop.CustomerArrives(id));
            customerThread.Start();
        }
    }
}
