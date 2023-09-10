using AutoMapper;
using NamiSic.Domain.Entities;

namespace NamiSic.Api.Models.DTOs.VehiclesEntryExit;

public class VehicleEntryExitProfile : Profile
{
    public VehicleEntryExitProfile()
    {
        CreateMap<CreateVehicleEntryExitDto, VehicleEntryExit>();
        CreateMap<VehicleEntryExit, VehicleEntryExitDto>();
    }
}
