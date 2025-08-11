using MediatR;
using ECommerce.Application.Categories.Dtos;

namespace ECommerce.Application.Categories.Commands;

/// <summary>
/// Command to update an existing category.
/// </summary>
public record UpdateCategoryCommand(int Id, string Name, string? Description) : IRequest<CategoryDto?>;
