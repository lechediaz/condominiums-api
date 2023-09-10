using AutoMapper;
using NamiSic.Domain.Entities;

namespace NamiSic.Api.Models.DTOs.Vehicles;

public class VehiclesProfile : Profile
{
    public VehiclesProfile()
    {
        CreateMap<CreateVehicleDto, Vehicle>();
        CreateMap<UpdateVehicleDto, Vehicle>();
        CreateMap<Vehicle, VehicleDto>();
    }
}
