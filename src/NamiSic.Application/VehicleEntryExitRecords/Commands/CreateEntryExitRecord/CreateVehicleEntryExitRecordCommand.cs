using System.ComponentModel.DataAnnotations;
using MediatR;

namespace NamiSic.Application.VehicleEntryExitRecords.Commands.CreateEntryExitRecord;

/// <summary>
/// Represents the information necessary to record a vehicle entry or exit.
/// </summary>
public class CreateVehicleEntryExitRecordCommand : IRequest<int>
{
    /// <summary>
    /// Indicates the license plate number of the vehicle.
    /// </summary>
    [Required]
    [MaxLength(8)]
    public string PlateNumber { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the type of vehicle. Possible values are "entry" or "exit".
    /// </summary>
    [Required]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// indicates any observation about the event.
    /// </summary>
    public string? Remarks { get; set; }
}

public class CreateVehicleEntryExitRecordCommandHandler : IRequestHandler<CreateVehicleEntryExitRecordCommand, int>
{
    public Task<int> Handle(CreateVehicleEntryExitRecordCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
