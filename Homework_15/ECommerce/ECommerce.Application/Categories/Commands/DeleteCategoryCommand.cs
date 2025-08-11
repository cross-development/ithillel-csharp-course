using MediatR;

namespace ECommerce.Application.Categories.Commands;

/// <summary>
/// Command to delete a category.
/// </summary>
public record DeleteCategoryCommand(int Id) : IRequest<int>;
