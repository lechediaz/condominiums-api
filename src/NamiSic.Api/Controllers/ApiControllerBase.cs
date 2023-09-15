﻿using NamiSic.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NamiSic.Api.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
