using System.ComponentModel.DataAnnotations;
using MediatR;

namespace NamiSic.Application.Vehicles.Commands.UpdateVehicle;

public class UpdateVehicleCommand : IRequest
{
    /// <summary>
    /// Indicates the initial license plate number of the vehicle.
    /// </summary>
    [Required]
    [MaxLength(8)]
    public string InitialPlateNumber { get; set; } = string.Empty;

    /// <summary>
    /// The resident's Id.
    /// </summary>
    [Required]
    public string ResidentId { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the type of vehicle. Possible values are "car" or "motorcycle". Default value is "car".
    /// </summary>
    [Required]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the license plate number of the vehicle.
    /// </summary>
    [Required]
    [MaxLength(8)]
    public string PlateNumber { get; set; } = string.Empty;
}

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
{
    public Task Handle(UpdateVehicleCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
