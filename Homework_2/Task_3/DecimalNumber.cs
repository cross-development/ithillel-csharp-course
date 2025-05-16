namespace Task_3;

/// <summary>
/// Represents a decimal number and provides methods to convert it
/// to binary, hexadecimal, and octal string representations.
/// </summary>
public struct DecimalNumber
{
    /// <summary>
    /// The internal integer value representing the decimal number.
    /// </summary>
    private readonly int _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="DecimalNumber"/> struct with the specified integer value.
    /// </summary>
    /// <param name="value">The decimal integer value.</param>
    public DecimalNumber(int value)
    {
        _value = value;
    }

    /// <summary>
    /// Converts the decimal number to its binary string representation.
    /// </summary>
    /// <returns>A string representing the number in binary format.</returns>
    public string ToBinary() => Convert.ToString(_value, 2);

    /// <summary>
    /// Converts the decimal number to its hexadecimal string representation.
    /// </summary>
    /// <returns>A string representing the number in hexadecimal format.</returns>
    public string ToHexadecimal() => Convert.ToString(_value, 16);

    /// <summary>
    /// Converts the decimal number to its octal string representation.
    /// </summary>
    /// <returns>A string representing the number in octal format.</returns>
    public string ToOctal() => Convert.ToString(_value, 8);

    /// <summary>
    /// Returns the string representation of the decimal number.
    /// </summary>
    /// <returns>A string representing the decimal number.</returns>
    public override string ToString() => _value.ToString();
}