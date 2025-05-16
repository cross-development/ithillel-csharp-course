namespace Task_1;

/// <summary>
/// Represents a product with a name and price.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the price of the product.
    /// </summary>
    public Money Price { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified name and price.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="price">The price of the product.</param>
    /// <exception cref="ArgumentException">Thrown when the product name is null or whitespace.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the price is null.</exception>
    public Product(string name, Money price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty or whitespace.");
        }

        ArgumentNullException.ThrowIfNull(price);

        Name = name;
        Price = price;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified name and price components.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="units">Whole units of the price.</param>
    /// <param name="cents">Cents of the price.</param>
    public Product(string name, int units, int cents)
        : this(name, new Money(units, cents))
    {
    }

    /// <summary>
    /// Reduces the price by the specified discount amount.
    /// </summary>
    /// <param name="discountUnits">Units part of the discount.</param>
    /// <param name="discountCents">Cents part of the discount.</param>
    public void ReducePrice(int discountUnits, int discountCents)
    {
        Price.Decrease(discountUnits, discountCents);
    }

    /// <summary>
    /// Reduces the price by the specified discount.
    /// </summary>
    /// <param name="discount">The discount as a <see cref="Money"/> instance.</param>
    public void ReducePrice(Money discount)
    {
        Price.Decrease(discount);
    }

    /// <summary>
    /// Displays information about the product.
    /// </summary>
    public void DisplayInfo()
    {
        Console.WriteLine($"Product Name: {Name}, Price: {Price}");
    }
}
