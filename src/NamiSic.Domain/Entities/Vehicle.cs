namespace NamiSic.Domain.Entities;

/// <summary>
/// Represents the information stored from a vehicle.
/// </summary>
public class Vehicle
{
    private string _plateNumber = string.Empty;

    /// <summary>
    /// Indicates the type of vehicle. Possible values are "car" or "motorcycle". Default value is "car".
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the license plate number of the vehicle.
    /// </summary>
    public string PlateNumber { get => _plateNumber; set => _plateNumber = value.ToUpperInvariant(); }
}
