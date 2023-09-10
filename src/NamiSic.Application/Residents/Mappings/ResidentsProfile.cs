using AutoMapper;
using NamiSic.Application.Residents.Commands.CreateResident;
using NamiSic.Application.Residents.Commands.UpdateResident;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.Residents.Mappings;

public class ResidentsProfile : Profile
{
    public ResidentsProfile()
    {
        CreateMap<CreateResidentCommand, Resident>();
        CreateMap<UpdateResidentCommand, Resident>();
    }
}
