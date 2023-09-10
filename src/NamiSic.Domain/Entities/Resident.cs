using NamiSic.Domain.Common.Interfaces;

namespace NamiSic.Domain.Entities;

/// <summary>
/// Represents the information stored from a resident.
/// </summary>
public class Resident : IEntityWithId
{
    public string Id { get; set; }

    /// <summary>
    /// The resident's name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The resident's document type.
    /// </summary>
    public string? DocumentType { get; set; }

    /// <summary>
    /// The resident's document number.
    /// </summary>
    public string? DocumentNumber { get; set; }

    /// <summary>
    /// The resident's e-mail.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The resident's cellphone.
    /// </summary>
    public string? Cellphone { get; set; }

    /// <summary>
    /// The resident type. Could be "owner", "tenant" or "resident".
    /// </summary>
    public string? ResidentType { get; set; }

    /// <summary>
    /// House or apartment number where the resident lives.
    /// </summary>
    public string ApartmentNumber { get; set; } = string.Empty;

    /// <summary>
    /// Vehicles owned by the resident.
    /// </summary>
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
