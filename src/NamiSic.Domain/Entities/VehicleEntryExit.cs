using NamiSic.Domain.Common.Interfaces;

namespace NamiSic.Domain.Entities;

/// <summary>
/// Represents an entry or exit of vehicle.
/// </summary>
public class VehicleEntryExit : IEntityWithId
{
    public string Id { get; set; }

    /// <summary>
    /// Indicates the license plate number of the vehicle.
    /// </summary>
    public string PlateNumber { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the type of record. Possible values are "entry" or "exit".
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the type of vehicle. Possible values are "car" or "motorcycle".
    /// </summary>
    public string? VehicleType { get; set; }

    /// <summary>
    /// indicates any observation about the event.
    /// </summary>
    public string? Remarks { get; set; }

    /// <summary>
    /// Indicates the date when the record was created
    /// </summary>
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates the user who created the record.
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;
}
