using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ECommerce.API.Controllers;

/// <summary>
/// Base controller for all API controllers in the ECommerce application.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    /// <summary>
    /// Gets the IMediator instance for handling requests.
    /// </summary>
    protected IMediator Mediator => _mediator
        ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator service is unavailable");
}
