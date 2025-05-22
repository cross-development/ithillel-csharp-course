using System.Text.RegularExpressions;

namespace Task_3;

/// <summary>
/// Represents a credit card with a number, CVC code, and balance.
/// Supports validation and comparison operations.
/// </summary>
public class CreditCard
{
    private string _cardNumber;
    private string _cvcCode;
    private decimal _balance;

    /// <summary>
    /// Gets or sets the card number in the format "1234-5678-9012-3456".
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the card number is null, empty, or not in the correct format.</exception>
    public string CardNumber
    {
        get => _cardNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d{4}(-\d{4}){3}$"))
            {
                throw new ArgumentException("Card number must be in the format '1234-5678-9012-3456'.");
            }

            _cardNumber = value;
        }
    }

    /// <summary>
    /// Gets or sets the CVC code, which must be a 3-digit string.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the CVC code is null, empty, or not a 3-digit number.</exception>
    public string CvcCode
    {
        get => _cvcCode;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d{3}$"))
            {
                throw new ArgumentException("CVC code must be a 3-digit non-negative number string.");
            }

            _cvcCode = value;
        }
    }

    /// <summary>
    /// Gets or sets the card balance. Must be a non-negative value.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the balance is negative.</exception>
    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Balance cannot be negative.");
            }

            _balance = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreditCard"/> class with the specified card number, CVC code, and balance.
    /// </summary>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="cvvCode">The CVC code.</param>
    /// <param name="balance">The initial balance.</param>
    public CreditCard(string cardNumber, string cvvCode, decimal balance)
    {
        CardNumber = cardNumber;
        CvcCode = cvvCode;
        Balance = balance;
    }

    /// <summary>
    /// Adds a specified amount to the credit card balance.
    /// </summary>
    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        return new CreditCard(card.CardNumber, card.CvcCode, card.Balance + amount);
    }

    /// <summary>
    /// Subtracts a specified amount from the credit card balance.
    /// </summary>
    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        return new CreditCard(card.CardNumber, card.CvcCode, card.Balance - amount);
    }

    /// <summary>
    /// Checks whether two credit cards have the same CVC code.
    /// </summary>
    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        if (ReferenceEquals(card1, card2))
        {
            return true;
        }

        if (ReferenceEquals(card1, null) || ReferenceEquals(card2, null))
        {
            return false;
        }

        return card1.CvcCode == card2.CvcCode;
    }

    /// <summary>
    /// Checks whether two credit cards do not have the same CVC code.
    /// </summary>
    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return !(card1 == card2);
    }

    /// <summary>
    /// Compares whether the balance of one card is less than another.
    /// </summary>
    public static bool operator <(CreditCard card1, CreditCard card2)
    {
        return card1.Balance < card2.Balance;
    }

    /// <summary>
    /// Compares whether the balance of one card is greater than another.
    /// </summary>
    public static bool operator >(CreditCard card1, CreditCard card2)
    {
        return card1.Balance > card2.Balance;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is CreditCard card)
        {
            return this == card;
        }

        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return CvcCode?.GetHashCode() ?? 0;
    }

    /// <summary>
    /// Returns a string representation of the credit card.
    /// </summary>
    /// <returns>A string containing the card number, cvc code, and formatted balance.</returns>
    public override string ToString()
    {
        return $"Card Number: {CardNumber}, CVC: {CvcCode}, Balance: {Balance:C}";
    }
}