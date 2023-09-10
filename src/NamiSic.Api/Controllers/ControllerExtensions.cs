using MediatR;
using Microsoft.AspNetCore.Mvc;
using NamiSic.Api.Filters;
using NamiSic.Api.Services.Base;

namespace NamiSic.Api.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ControllerExtensions : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    /// <summary>
    /// Allows to return an TActionResult type instance according the ServiceREsult given.
    /// </summary>
    /// <typeparam name="TServiceResult">Service result type.</typeparam>
    /// <param name="controller">The ControllerBase ref.</param>
    /// <param name="serviceResult">Service result.</param>
    /// <returns>IActionResult type instance.</returns>
    public IActionResult ActionResultByServiceResult<TServiceResult>(TServiceResult serviceResult)
    where TServiceResult : ServiceResult
    {
        Type serviceResultType = serviceResult.GetType();

        if (serviceResult.Success)
        {
            if (serviceResultType.IsGenericType)
            {
                object? objectValue = serviceResultType.GetProperty("Extra")?.GetValue(serviceResult);
                return Ok(objectValue);
            }

            return Ok();
        }

        return Problem(serviceResult.ErrorMessage, statusCode: serviceResult.HttpStatusCode);
    }
}
