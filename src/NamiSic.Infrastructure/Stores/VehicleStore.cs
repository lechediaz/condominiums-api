using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NamiSic.Application.Common.Stores;
using NamiSic.Domain.Entities;
using NamiSic.Infrastructure.Stores;

namespace NamiSic.Api.Stores;

/// <summary>
/// Implements the custom methods to perform the storage of vehicles.
/// </summary>
public class VehicleStore : StoreBase<Resident>, IVehicleStore
{
    public VehicleStore(IMongoDatabase database) : base("residents", database)
    {

    }

    public Task AddVehicleAsync(string id, Vehicle vehicle)
    {
        FilterDefinition<Resident> filter = CreateFilterById(id);
        UpdateDefinition<Resident> update = Builders<Resident>.Update
            .Push(r => r.Vehicles, vehicle);
        return Collection.UpdateOneAsync(filter, update);
    }

    public Task DeleteVehicleAsync(string id, string plateNumber)
    {
        ObjectId residentId = ObjectId.Parse(id);
        FilterDefinitionBuilder<Resident> filterBuilder = Builders<Resident>.Filter;
        plateNumber = plateNumber.ToUpperInvariant();
        FilterDefinition<Resident> filter = filterBuilder.And(
            filterBuilder.Eq("Id", residentId),
            filterBuilder.ElemMatch(r => r.Vehicles, v => v.PlateNumber == plateNumber)
        );
        UpdateDefinition<Resident> update = Builders<Resident>.Update
            .PullFilter(r => r.Vehicles, v => v.PlateNumber == plateNumber);
        return Collection.UpdateOneAsync(filter, update);
    }

    public async Task<List<string>> FilterPlateNumbersAsync(string plateNumberHint)
    {
        plateNumberHint = plateNumberHint.ToLower().Trim();
        List<string> plateNumbers = await Collection.AsQueryable()
            .SelectMany(r => r.Vehicles.Select(v => v.PlateNumber))
            .Where(p => p.ToLower().Trim().StartsWith(plateNumberHint))
            .ToListAsync();
        return plateNumbers;
    }

    public async Task<Resident?> FindResidentByVehiclePlateNumberAsync(string plateNumber, string? ignoreId = null)
    {
        plateNumber = plateNumber.ToLower().Trim();
        FilterDefinitionBuilder<Resident> filterBuilder = Builders<Resident>.Filter;
        FilterDefinition<Resident> baseFilter = Builders<Resident>.Filter.ElemMatch(
            r => r.Vehicles,
            v => v.PlateNumber.ToLower() == plateNumber
        );
        FilterDefinition<Resident> filter = baseFilter;
        if (!string.IsNullOrEmpty(ignoreId))
        {
            ObjectId objectId = ObjectId.Parse(ignoreId);
            filter = filterBuilder.And(baseFilter, filterBuilder.Ne("Id", objectId));
        }
        Resident? resident = await Collection.Find(filter).FirstOrDefaultAsync();
        return resident;
    }

    public async Task<Vehicle?> GetVehicleByPlateNumberAsync(string plateNumber)
    {
        plateNumber = plateNumber.Trim().ToLower();
        Vehicle? vehicle = await Collection.AsQueryable()
            .SelectMany(r => r.Vehicles)
            .FirstOrDefaultAsync(v => v.PlateNumber.Trim().ToLower() == plateNumber);
        return vehicle;
    }

    public async Task<List<Vehicle>> GetVehiclesAsync(string id)
    {
        FilterDefinition<Resident> filter = CreateFilterById(id);
        Resident? resident = await Collection.Find(filter).FirstOrDefaultAsync();
        return resident?.Vehicles ?? new List<Vehicle>();
    }

    public Task UpdateVehicleAsync(string id, string initialPlateNumber, Vehicle vehicle)
    {
        ObjectId residentId = ObjectId.Parse(id);
        FilterDefinitionBuilder<Resident> filterBuilder = Builders<Resident>.Filter;
        initialPlateNumber = initialPlateNumber.ToUpperInvariant();
        FilterDefinition<Resident> filter = filterBuilder.And(
            filterBuilder.Eq("Id", residentId),
            filterBuilder.ElemMatch(r => r.Vehicles, v => v.PlateNumber == initialPlateNumber)
        );
        UpdateDefinition<Resident> update = Builders<Resident>.Update
            .Set(r => r.Vehicles.FirstMatchingElement(), vehicle);
        return Collection.UpdateOneAsync(filter, update);
    }

    public async Task<bool> ValidateIfVehicleExistsAsync(string plateNumber)
    {
        plateNumber = plateNumber.Trim().ToLower();
        FilterDefinition<Resident> filter = Builders<Resident>.Filter.ElemMatch(
            r => r.Vehicles,
            v => v.PlateNumber.Trim().ToLower() == plateNumber
        );
        long count = await Collection.CountDocumentsAsync(filter);
        return count > 0;
    }
}
