using MediatR;

namespace NamiSic.Application.VehicleEntryExitRecords.Queries.GetVehicleEntryExitRecordsFiltered;

/// <summary>
/// Filters that can be used when querying vehicle entry and exit records.
/// </summary>
public class GetVehicleEntryExitRecordsFilteredQuery : IRequest<List<VehicleEntryExitRecordDto>>
{
    public string? PlateNumber { get; set; }
    public string? Type { get; set; }
    public string? VehicleType { get; set; }
    public DateTime? BeginCreationDate { get; set; }
    public DateTime? EndCreationDate { get; set; }
    public string? CreatedBy { get; set; }
    public bool CurrentUser { get; set; }
}

public class GetVehicleEntryExitRecordsFilteredQueryHandler : IRequestHandler<GetVehicleEntryExitRecordsFilteredQuery, List<VehicleEntryExitRecordDto>>
{
    public Task<List<VehicleEntryExitRecordDto>> Handle(GetVehicleEntryExitRecordsFilteredQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
