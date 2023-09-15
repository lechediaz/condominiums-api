using MongoDB.Driver;
using NamiSic.Application.Common.Stores;
using NamiSic.Application.VehicleEntryExitRecords.Queries.GetVehicleEntryExitRecordsFiltered;
using NamiSic.Domain.Entities;
using NamiSic.Infrastructure.Stores;

namespace NamiSic.Api.Stores;

/// <summary>
/// Implements the custom methods to perform the storage of vehicle entry or exit.
/// </summary>
public class VehicleEntryExitStore : StoreBase<VehicleEntryExitRecord>, IVehicleEntryExitRecordStore
{
    public VehicleEntryExitStore(IMongoDatabase database) : base("vehicle_entry_exit", database)
    {
    }

    public Task<List<VehicleEntryExitRecord>> FilterAsync(GetVehicleEntryExitRecordsFilteredQuery filters)
    {
        FilterDefinitionBuilder<VehicleEntryExitRecord> filterBuilder = Builders<VehicleEntryExitRecord>.Filter;
        SortDefinition<VehicleEntryExitRecord> sorting = Builders<VehicleEntryExitRecord>.Sort.Descending(v => v.CreationDate);
        var filterConditions = new List<FilterDefinition<VehicleEntryExitRecord>>();

        if (!string.IsNullOrEmpty(filters.CreatedBy))
        {
            string createdBy = filters.CreatedBy.Trim().ToLower();
            filterConditions.Add(filterBuilder.Where(v => v.CreatedBy.Trim().ToLower() == createdBy));
        }

        if (!string.IsNullOrEmpty(filters.PlateNumber))
        {
            string plateNumber = filters.PlateNumber.Trim().ToLower();
            filterConditions.Add(filterBuilder.Where(v => v.PlateNumber.Trim().ToLower() == plateNumber));
        }

        if (!string.IsNullOrEmpty(filters.Type))
        {
            string type = filters.Type.Trim().ToLower();
            filterConditions.Add(filterBuilder.Where(v => v.Type.Trim().ToLower() == type));
        }

        if (!string.IsNullOrEmpty(filters.VehicleType))
        {
            string vehicleType = filters.VehicleType.Trim().ToLower();
            filterConditions.Add(filterBuilder.Where(v => v.VehicleType != null && v.VehicleType.Trim().ToLower() == vehicleType));
        }

        if (filters.BeginCreationDate != null)
        {
            filterConditions.Add(filterBuilder.Gte(v => v.CreationDate, filters.BeginCreationDate));
        }

        if (filters.EndCreationDate != null)
        {
            filterConditions.Add(filterBuilder.Lte(v => v.CreationDate, filters.EndCreationDate));
        }

        FilterDefinition<VehicleEntryExitRecord> compoundFilters = filterBuilder.And(filterConditions);
        return Collection.Find(compoundFilters).Sort(sorting).ToListAsync();
    }
}
