namespace Task_2;

/// <summary>
/// Represents a city with a name and a population.
/// </summary>
public class City
{
    private int _population;

    /// <summary>
    /// Gets or sets the name of the city.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the population of the city.
    /// Throws <see cref="ArgumentException"/> if a negative value is assigned.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the population is negative.</exception>
    public int Population
    {
        get => _population;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Population cannot be negative.");
            }

            _population = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="City"/> class with the specified name and population.
    /// </summary>
    /// <param name="name">The name of the city.</param>
    /// <param name="population">The population of the city.</param>
    public City(string name, int population)
    {
        Name = name;
        Population = population;
    }

    /// <summary>
    /// Increases the population of a city by a given amount.
    /// </summary>
    /// <param name="city">The city whose population is to be increased.</param>
    /// <param name="amount">The amount to increase the population by.</param>
    /// <returns>A new <see cref="City"/> object with updated population.</returns>
    public static City operator +(City city, int amount)
    {
        return new City(city.Name, city.Population + amount);
    }

    /// <summary>
    /// Decreases the population of a city by a given amount.
    /// </summary>
    /// <param name="city">The city whose population is to be decreased.</param>
    /// <param name="amount">The amount to decrease the population by.</param>
    /// <returns>A new <see cref="City"/> object with updated population.</returns>
    public static City operator -(City city, int amount)
    {
        return new City(city.Name, city.Population - amount);
    }

    /// <summary>
    /// Determines whether two <see cref="City"/> objects have the same population.
    /// </summary>
    public static bool operator ==(City city1, City city2)
    {
        if (ReferenceEquals(city1, city2))
        {
            return true;
        }

        if (ReferenceEquals(city1, null) || ReferenceEquals(city2, null))
        {
            return false;
        }

        return city1.Population == city2.Population;
    }

    /// <summary>
    /// Determines whether two <see cref="City"/> objects have different populations.
    /// </summary>
    public static bool operator !=(City city1, City city2)
    {
        return !(city1 == city2);
    }

    /// <summary>
    /// Determines whether the population of one city is greater than another.
    /// </summary>
    public static bool operator >(City city1, City city2)
    {
        return city1.Population > city2.Population;
    }

    /// <summary>
    /// Determines whether the population of one city is less than another.
    /// </summary>
    public static bool operator <(City city1, City city2)
    {
        return city1.Population < city2.Population;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is City city)
        {
            return this == city;
        }

        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return Population.GetHashCode();
    }

    /// <summary>
    /// Returns a string representation of the city.
    /// </summary>
    /// <returns>A string in the format "Name (Population: value)".</returns>
    public override string ToString()
    {
        return $"{Name} (Population: {Population})";
    }
}