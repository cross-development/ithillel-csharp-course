namespace Task_1;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Demonstration of working with Money and Product classes:");

            // Creating a Money object with normalization: (10, 150) becomes 11.50
            var money = new Money(10, 150);
            Console.Write("Current amount of money: ");
            money.Display();

            // Initial product info
            Console.WriteLine("Creating a new product with initial price 15.75:");

            var product = new Product("Apple", 15, 75);
            product.DisplayInfo();

            // Applying a discount of 3.30
            Console.WriteLine("Applying a discount of 3.30:");

            product.ReducePrice(3, 30);
            product.DisplayInfo();

            // Applying an additional discount of 1.50 using a Money object
            Console.WriteLine("Applying an additional discount of 1.50:");

            var discount = new Money(1, 50);
            product.ReducePrice(discount);
            product.DisplayInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
