using AutoMapper;
using NamiSic.Domain.Entities;

namespace NamiSic.Api.Models.DTOs.Residents;

public class ResidentsProfile : Profile
{
    public ResidentsProfile()
    {
        CreateMap<CreateResidentDto, Resident>();
        CreateMap<UpdateResidentDto, Resident>();
        CreateMap<Resident, ResidentDto>()
            .ForMember(dest => dest.Id, config => config.MapFrom(src => src.Id.ToString()));
    }
}
