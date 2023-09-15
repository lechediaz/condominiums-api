using NamiSic.Application.VehicleEntryExitRecords.Queries.GetVehicleEntryExitRecordsFiltered;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.Common.Stores;

/// <summary>
/// Defines the custom methods to perform the storage of vehicle entry or exit.
/// </summary>
public interface IVehicleEntryExitRecordStore : IStore<VehicleEntryExitRecord>
{
    /// <summary>
    /// Allows to query vehicle entry and exit records by using filters.
    /// </summary>
    /// <param name="filters">filters to be performed in the query.</param>
    /// <returns>Records of vehicle entries and exits matching the given filters.</returns>
    Task<List<VehicleEntryExitRecord>> FilterAsync(GetVehicleEntryExitRecordsFilteredQuery filters);
}
