using NamiSic.Application.Common.Mappings;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.VehicleEntryExitRecords.Queries.GetVehicleEntryExitRecordsFiltered;

/// <summary>
/// Information to be displayed when querying vehicle entry/exit records.
/// </summary>
public class VehicleEntryExitRecordDto : IMapFrom<VehicleEntryExitRecord>
{
    public string Id { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? VehicleType { get; set; }
    public string? Remarks { get; set; }
    public DateTime CreationDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}
