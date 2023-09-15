using MongoDB.Bson;
using MongoDB.Driver;
using NamiSic.Application.Common.Stores;
using NamiSic.Application.Residents.Queries.GetResidentsFiltered;
using NamiSic.Domain.Entities;

namespace NamiSic.Infrastructure.Stores;

/// <summary>
/// Implements the custom methods to perform the storage of residents.
/// </summary>
public class ResidentStore : StoreBase<Resident>, IResidentStore
{
    public ResidentStore(IMongoDatabase database) : base("residents", database)
    {

    }

    public async Task<bool> ExistsByDocumentAsync(string documentType, string documentNumber, string? ignoreId = null)
    {
        FilterDefinitionBuilder<Resident> filterBuilder = Builders<Resident>.Filter;
        FilterDefinition<Resident> baseFilter = filterBuilder.And(
            filterBuilder.Eq(f => f.DocumentType, documentType),
            filterBuilder.Eq(f => f.DocumentNumber, documentNumber)
        );
        FilterDefinition<Resident> filter = baseFilter;

        if (!string.IsNullOrEmpty(ignoreId))
        {
            ObjectId residentId = ObjectId.Parse(ignoreId);
            filter = filterBuilder.And(filterBuilder.Ne("Id", residentId), baseFilter);
        }

        long count = await Collection.CountDocumentsAsync(filter);
        return count > 0;
    }

    public async Task<List<Resident>> GetAsync(GetResidentsFilteredQuery filters)
    {
        FilterDefinitionBuilder<Resident> filterBuilder = Builders<Resident>.Filter;
        List<FilterDefinition<Resident>> composedFilters = new List<FilterDefinition<Resident>>();
        SortDefinition<Resident> sort = Builders<Resident>.Sort
            .Ascending(r => r.Name)
            .Ascending(r => r.ApartmentNumber);

        if (!string.IsNullOrEmpty(filters.DocumentType))
        {
            composedFilters.Add(filterBuilder.Eq(f => f.DocumentType, filters.DocumentType));
        }

        if (!string.IsNullOrEmpty(filters.Cellphone))
        {
            composedFilters.Add(filterBuilder.Regex(f => f.Cellphone, new BsonRegularExpression(filters.Cellphone, "i")));
        }

        if (!string.IsNullOrEmpty(filters.DocumentNumber))
        {
            composedFilters.Add(filterBuilder.Regex(f => f.DocumentNumber, new BsonRegularExpression(filters.DocumentNumber, "i")));
        }

        if (!string.IsNullOrEmpty(filters.ApartmentNumber))
        {
            composedFilters.Add(filterBuilder.Regex(f => f.ApartmentNumber, new BsonRegularExpression(filters.ApartmentNumber, "i")));
        }

        if (!string.IsNullOrEmpty(filters.Email))
        {
            composedFilters.Add(filterBuilder.Regex(f => f.Email, new BsonRegularExpression(filters.Email, "i")));
        }

        if (!string.IsNullOrEmpty(filters.Name))
        {
            composedFilters.Add(filterBuilder.Regex(f => f.Name, new BsonRegularExpression(filters.Name, "i")));
        }

        if (!string.IsNullOrEmpty(filters.ResidentType))
        {
            composedFilters.Add(filterBuilder.Eq(f => f.ResidentType, filters.ResidentType));
        }

        FilterDefinition<Resident> filter = filterBuilder.Empty;

        if (composedFilters.Count == 1)
        {
            filter = composedFilters.First();
        }

        if (composedFilters.Count > 1)
        {
            filter = composedFilters.Aggregate((current, next) => filterBuilder.And(current, next));
        }

        return await Collection.Find(filter).Sort(sort).ToListAsync();
    }

    public Task UpdateOneAsync(Resident resident)
    {
        FilterDefinition<Resident> filter = Builders<Resident>.Filter.Eq(r => r.Id, resident.Id);
        UpdateDefinition<Resident> update = Builders<Resident>.Update
            .Set(r => r.Name, resident.Name)
            .Set(r => r.ApartmentNumber, resident.ApartmentNumber);

        if (!string.IsNullOrEmpty(resident.Cellphone))
        {
            update = update.Set(f => f.Cellphone, resident.Cellphone);
        }

        if (!string.IsNullOrEmpty(resident.DocumentNumber))
        {
            update = update.Set(f => f.DocumentNumber, resident.DocumentNumber);
        }

        if (!string.IsNullOrEmpty(resident.DocumentType))
        {
            update = update.Set(f => f.DocumentType, resident.DocumentType);
        }

        if (!string.IsNullOrEmpty(resident.Email))
        {
            update = update.Set(f => f.Email, resident.Email);
        }

        if (!string.IsNullOrEmpty(resident.ResidentType))
        {
            update = update.Set(f => f.ResidentType, resident.ResidentType);
        }

        return Collection.UpdateOneAsync(filter, update);
    }
}
