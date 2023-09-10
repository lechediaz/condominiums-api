using System.ComponentModel.DataAnnotations;
using MediatR;

namespace NamiSic.Application.Vehicles.Commands.DeleteVehicle;

public class DeleteVehicleCommand : IRequest
{
    /// <summary>
    /// The resident's Id.
    /// </summary>
    [Required]
    public string ResidentId { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the license plate number of the vehicle to delete.
    /// </summary>
    [Required]
    public string PlateNumber { get; set; } = string.Empty;
}

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
{
    public Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
