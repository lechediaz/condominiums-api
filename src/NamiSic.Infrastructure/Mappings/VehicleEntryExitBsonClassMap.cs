using MongoDB.Bson.Serialization;
using NamiSic.Domain.Entities;

namespace NamiSic.Infrastructure.Mappings;

public class VehicleEntryExitBsonClassMap : BsonClassMap<VehicleEntryExitRecord>
{
    public VehicleEntryExitBsonClassMap()
    {
        AutoMap();
        SetIgnoreExtraElements(true);
        MapIdMember(p => p.Id);
        MapMember(p => p.PlateNumber).SetElementName("plate_number");
        MapMember(p => p.Type).SetElementName("type");
        MapMember(p => p.VehicleType).SetElementName("vehicle_type")
            .SetIgnoreIfNull(true);
        MapMember(p => p.Remarks).SetElementName("remarks");
        MapMember(p => p.CreationDate).SetElementName("creation_date");
        MapMember(p => p.CreatedBy).SetElementName("created_by");
    }
}
