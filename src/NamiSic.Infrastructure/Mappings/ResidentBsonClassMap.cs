using MongoDB.Bson.Serialization;
using NamiSic.Domain.Entities;

namespace NamiSic.Infrastructure.Mappings;

public class ResidentBsonClassMap : BsonClassMap<Resident>
{
    public ResidentBsonClassMap()
    {
        AutoMap();
        SetIgnoreExtraElements(true);
        MapIdMember(p => p.Id);
        MapMember(p => p.Name).SetElementName("name");
        MapMember(p => p.DocumentType).SetElementName("document_type")
            .SetIgnoreIfNull(true);
        MapMember(p => p.DocumentNumber).SetElementName("document_number")
            .SetIgnoreIfNull(true);
        MapMember(p => p.Email).SetElementName("email")
            .SetIgnoreIfNull(true);
        MapMember(p => p.Cellphone).SetElementName("cellphone")
            .SetIgnoreIfNull(true);
        MapMember(p => p.ResidentType).SetElementName("resident_type")
            .SetIgnoreIfNull(true);
        MapMember(p => p.ApartmentNumber).SetElementName("apartment_number");
        MapMember(p => p.Vehicles).SetElementName("vehicles")
            .SetIgnoreIfNull(true);
    }
}
