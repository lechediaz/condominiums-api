using MongoDB.Bson.Serialization;
using NamiSic.Domain.Entities;

namespace NamiSic.Infrastructure.Mappings;

public class VehicleBsonClassMap : BsonClassMap<Vehicle>
{
    public VehicleBsonClassMap()
    {
        AutoMap();
        SetIgnoreExtraElements(true);
        MapMember(p => p.Type).SetElementName("type");
        MapMember(p => p.PlateNumber).SetElementName("plate_number");
    }
}
