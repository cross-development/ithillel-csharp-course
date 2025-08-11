namespace ECommerce.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a requested resource is not found.
/// </summary>
public class NotFoundException(string resourceType, string resourceIdentifier)
    : Exception($"{resourceType} with id: {resourceIdentifier} doesn't exist")
{
}