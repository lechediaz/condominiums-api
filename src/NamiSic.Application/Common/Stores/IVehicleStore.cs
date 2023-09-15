using NamiSic.Domain.Entities;

namespace NamiSic.Application.Common.Stores;

/// <summary>
/// Defines the custom methods to perform the storage of vehicles.
/// </summary>
public interface IVehicleStore : IStore<Resident>
{
    /// <summary>
    /// Allows to find a resident by searching for a vehicle with a license plate number.
    /// </summary>
    /// <param name="plateNumber">The license plate number to search.</param>
    /// <param name="ignoreId">Resident ID to ignore.</param>
    /// <returns>The resident found, otherwise <see langword="null"/></returns>
    Task<Resident?> FindResidentByVehiclePlateNumberAsync(string plateNumber, string? ignoreId = null);

    /// <summary>
    /// Allows to obtain all the vehicles that belong to a resident by ID.
    /// </summary>
    /// <param name="id">Resident's id.</param>
    Task<List<Vehicle>> GetVehiclesAsync(string id);

    /// <summary>
    /// Allows adding a vehicle to a resident.
    /// </summary>
    /// <param name="id">Resident's id.</param>
    /// <param name="vehicle">Vehicle information.</param>
    Task AddVehicleAsync(string id, Vehicle vehicle);

    /// <summary>
    /// Allows updating a vehicle to a resident.
    /// </summary>
    /// <param name="id">Resident's id.</param>
    /// <param name="initialPlateNumber">Vehicles's initial plate number.</param>
    /// <param name="vehicle">Vehicle information.</param>
    Task UpdateVehicleAsync(string id, string initialPlateNumber, Vehicle vehicle);

    /// <summary>
    /// Allows updating a vehicle to a resident.
    /// </summary>
    /// <param name="id">Resident's id.</param>
    /// <param name="plateNumber">Vehicles's initial plate number.</param>
    Task DeleteVehicleAsync(string id, string plateNumber);

    /// <summary>
    /// Allows to filter the plate numbers of vehicles given a portion of this.
    /// </summary>
    /// <param name="plateNumberHint">Plate number portion.</param>
    /// <returns>List of plate numbers.</returns>
    Task<List<string>> FilterPlateNumbersAsync(string plateNumberHint);

    /// <summary>
    /// Allows to validate if a vehicle exists by searching for its license plate number.
    /// </summary>
    /// <param name="plateNumber">The license plate number to search.</param>
    /// <returns><see langword="true"/> if vehicle exists otherwise <see langword="false"/>.</returns>
    Task<bool> ValidateIfVehicleExistsAsync(string plateNumber);

    /// <summary>
    /// Allows to search a vehicle for its license plate number.
    /// </summary>
    /// <param name="plateNumber">The license plate number to search.</param>
    /// <returns>The vehicle record.</returns>
    Task<Vehicle?> GetVehicleByPlateNumberAsync(string plateNumber);
}
