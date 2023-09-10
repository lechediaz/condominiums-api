using MongoDB.Bson;

namespace NamiSic.Api.Models.Base;

/// <summary>
/// Defines the Id field to an entity.
/// </summary>
public interface IHasId
{
    /// <summary>
    /// The entity's identifier.
    /// </summary>
    public ObjectId Id { get; set; }
}
