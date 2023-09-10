using FluentValidation;

namespace NamiSic.Application.VehicleEntryExitRecords.Commands.CreateEntryExitRecord;

public class CreateVehicleEntryExitRecordCommandValidator : AbstractValidator<CreateVehicleEntryExitRecordCommand>
{
    public CreateVehicleEntryExitRecordCommandValidator()
    {
    }
}
