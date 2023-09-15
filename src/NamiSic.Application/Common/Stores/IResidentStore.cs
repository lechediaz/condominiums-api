using NamiSic.Application.Residents.Queries.GetResidentsFiltered;
using NamiSic.Domain.Entities;

namespace NamiSic.Application.Common.Stores;

/// <summary>
/// Defines the custom methods to perform the storage of residents.
/// </summary>
public interface IResidentStore : IStore<Resident>
{
    /// <summary>
    /// Allows to get a list with all the residents.
    /// </summary>
    /// <param name="filters">Filters to apply.</param>
    /// <returns>Execution result with Resident information in Extra property if found.</returns>
    Task<List<Resident>> GetAsync(GetResidentsFilteredQuery filters);

    /// <summary>
    /// Allows to validate if a resident exists by its document type and document number.
    /// Optionally an Id can be specyfied to ignore it.
    /// </summary>
    /// <param name="documentType">The resident's document type to search.</param>
    /// <param name="documentNumber">The resident's document number to search.</param>
    /// <param name="ignoreId">Optional resident's Id to ignore.</param>
    /// <returns>True if the resident exist by its document type and document number.</returns>
    Task<bool> ExistsByDocumentAsync(string documentType, string documentNumber, string? ignoreId = null);

    /// <summary>
    /// Allows to update a resident.
    /// </summary>
    /// <param name="resident">The resident information to update.</param>
    Task UpdateOneAsync(Resident resident);
}
