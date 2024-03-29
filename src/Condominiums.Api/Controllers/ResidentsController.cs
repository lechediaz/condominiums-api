using Condominiums.Api.Auth.Attributes;
using Condominiums.Api.Models.DTOs.Residents;
using Condominiums.Api.Services;
using Condominiums.Api.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace Condominiums.Api.Controllers;

/// <summary>
/// Endpoints that allows to manage Residents.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[AuthorizeRole(Constants.RoleNames.Administrator)]
public class ResidentsController : ControllerBase
{
    private readonly IResidentService _residentService;

    public ResidentsController(IResidentService residentService)
    {
        _residentService = residentService;
    }

    /// <summary>
    /// Allows to delete a Resident by Id.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        ServiceResult result = await _residentService.DeleteAsync(id);
        return this.ActionResultByServiceResult(result);
    }

    /// <summary>
    /// Allows to get all Residents.
    /// </summary>
    [ProducesResponseType(typeof(List<ResidentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetResidentsQuery filters)
    {
        ServiceResult<List<ResidentDto>> result = await _residentService.GetAsync(filters);
        return this.ActionResultByServiceResult(result);
    }

    /// <summary>
    /// Allows to search a Resident by Id.
    /// </summary>
    [ProducesResponseType(typeof(ResidentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        ServiceResult result = await _residentService.GetAsync(id);
        return this.ActionResultByServiceResult(result);
    }

    /// <summary>
    /// Allows to create a new Resident.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> Post(CreateResidentDto newResident)
    {
        ServiceResult result = await _residentService.CreateAsync(newResident);
        return this.ActionResultByServiceResult(result);
    }

    /// <summary>
    /// Allows to update a Resident.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, UpdateResidentDto residentToUpdate)
    {
        ServiceResult result = await _residentService.UpdateAsync(id, residentToUpdate);
        return this.ActionResultByServiceResult(result);
    }
}
