using AutoMapper;
using NamiSic.Application.Vehicles.Commands.CreateVehicle;
using NamiSic.Application.Vehicles.Commands.UpdateVehicle;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.Vehicles.Mappings;

public class VehiclesProfile : Profile
{
    public VehiclesProfile()
    {
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<UpdateVehicleCommand, Vehicle>();
    }
}
