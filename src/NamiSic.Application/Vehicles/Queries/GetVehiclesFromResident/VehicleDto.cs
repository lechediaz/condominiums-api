using NamiSic.Application.Common.Mappings;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.Vehicles.Queries.GetVehiclesFromResident;

/// <summary>
/// Represents the information of a vehicle when it is queried.
/// </summary>
public class VehicleDto : IMapFrom<Vehicle>
{
    public string Type { get; set; }
    public string PlateNumber { get; set; }
}
