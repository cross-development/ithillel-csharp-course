using MediatR;
using ECommerce.Application.Categories.Dtos;

namespace ECommerce.Application.Categories.Commands;

/// <summary>
/// Command to create a new category.
/// </summary>
public record CreateCategoryCommand(string Name, string? Description) : IRequest<CategoryDto>;
