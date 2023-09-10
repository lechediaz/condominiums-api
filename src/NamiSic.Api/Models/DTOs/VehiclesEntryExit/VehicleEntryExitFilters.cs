using System.ComponentModel.DataAnnotations;
using NamiSic.Api.Constants;

namespace NamiSic.Api.Models.DTOs.VehiclesEntryExit;

/// <summary>
/// Filters that can be used when querying vehicle entry and exit records.
/// </summary>
public class VehicleEntryExitFilters
{
    public string? PlateNumber { get; set; }
    [MatchesValues(VehicleEntryExitType.Entry, VehicleEntryExitType.Exit)]
    public string? Type { get; set; }
    [MatchesValues(Constants.VehicleType.Car, Constants.VehicleType.Motorcycle)]
    public string? VehicleType { get; set; }
    public DateTime? BeginCreationDate { get; set; }
    public DateTime? EndCreationDate { get; set; }
    public string? CreatedBy { get; set; }
    public bool CurrentUser { get; set; }
}
