using MediatR;

namespace NamiSic.Application.Residents.Queries.GetResidentsFiltered;

public class GetResidentsFilteredQuery : IRequest<List<ResidentVm>>
{
    public string? Name { get; set; }
    public string? DocumentType { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Email { get; set; }
    public string? Cellphone { get; set; }
    public string? ResidentType { get; set; }
    public string? ApartmentNumber { get; set; }
}

public class GetResidentsFilteredQueryHandler : IRequestHandler<GetResidentsFilteredQuery, List<ResidentVm>>
{
    public Task<List<ResidentVm>> Handle(GetResidentsFilteredQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
