using AutoMapper;
using NamiSic.Application.VehicleEntryExitRecords.Commands.CreateEntryExitRecord;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.VehicleEntryExitRecords.Mappings;

public class VehicleEntryExitRecordsProfile : Profile
{
    public VehicleEntryExitRecordsProfile()
    {
        CreateMap<CreateVehicleEntryExitRecordCommand, VehicleEntryExitRecord>();
    }
}
