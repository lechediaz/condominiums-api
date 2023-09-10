using MediatR;

namespace NamiSic.Application.Vehicles.Queries.GetVehiclesFromResident;

public class GetVehiclesFromResidentQuery : IRequest<List<VehicleDto>>
{

}

public class GetVehiclesFromResidentQueryHandler : IRequestHandler<GetVehiclesFromResidentQuery, List<VehicleDto>>
{
    public Task<List<VehicleDto>> Handle(GetVehiclesFromResidentQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
