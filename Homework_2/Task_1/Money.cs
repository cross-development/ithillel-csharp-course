namespace Task_1;


/// <summary>
/// Represents a monetary amount consisting of whole units and cents.
/// </summary>
public class Money
{
    /// <summary>
    /// The whole units part of the money amount.
    /// </summary>
    private int _units;

    /// <summary>
    /// The cents part of the money amount.
    /// </summary>
    private int _cents;

    /// <summary>
    /// Gets the whole part of the money amount.
    /// </summary>
    public int Units
    {
        get => _units;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Units cannot be negative.");
            }

            _units = value;
        }
    }

    /// <summary>
    /// Gets the fractional part (cents) of the money amount.
    /// </summary>
    public int Cents
    {
        get => _cents;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Cents cannot be negative.");
            }

            _cents = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class with specified units and cents.
    /// </summary>
    /// <param name="units">Whole units of money.</param>
    /// <param name="cents">Cents of money.</param>
    public Money(int units = 0, int cents = 0)
    {
        SetAmount(units, cents);
    }

    /// <summary>
    /// Sets the monetary amount with given units and cents.
    /// </summary>
    /// <param name="units">Whole units to set.</param>
    /// <param name="cents">Cents to set.</param>
    /// <exception cref="ArgumentException">Thrown when units or cents are negative.</exception>
    public void SetAmount(int units, int cents)
    {
        if (units < 0 || cents < 0)
        {
            throw new ArgumentException("Values cannot be negative.");
        }

        int totalCents = units * 100 + cents;

        Units = totalCents / 100;
        Cents = totalCents % 100;
    }

    /// <summary>
    /// Decreases the money amount by the specified discount in units and cents.
    /// </summary>
    /// <param name="discountUnits">Units part of the discount.</param>
    /// <param name="discountCents">Cents part of the discount.</param>
    /// <exception cref="ArgumentException">Thrown when discount values are negative.</exception>
    public void Decrease(int discountUnits, int discountCents)
    {
        if (discountUnits < 0 || discountCents < 0)
        {
            throw new ArgumentException("Discount values must be non-negative.");
        }

        int currentTotal = Units * 100 + Cents;
        int discountTotal = discountUnits * 100 + discountCents;
        int newTotal = currentTotal - discountTotal;

        if (newTotal < 0)
        {
            newTotal = 0;
        }

        SetAmount(newTotal / 100, newTotal % 100);
    }

    /// <summary>
    /// Decreases the money amount by another <see cref="Money"/> instance.
    /// </summary>
    /// <param name="discount">Money instance to subtract.</param>
    /// <exception cref="ArgumentNullException">Thrown when discount is null.</exception>
    public void Decrease(Money discount)
    {
        ArgumentNullException.ThrowIfNull(discount);

        Decrease(discount.Units, discount.Cents);
    }

    /// <summary>
    /// Displays the money amount in the console.
    /// </summary>
    public void Display()
    {
        Console.WriteLine(ToString());
    }

    /// <summary>
    /// Returns a string representation of the money amount in format "units.cents".
    /// </summary>
    /// <returns>String formatted as "units.cents".</returns>
    public override string ToString()
    {
        return $"{Units}.{Cents:D2}";
    }
}