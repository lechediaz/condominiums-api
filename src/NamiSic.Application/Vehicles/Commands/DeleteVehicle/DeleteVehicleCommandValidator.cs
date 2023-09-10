using FluentValidation;

namespace NamiSic.Application.Vehicles.Commands.DeleteVehicle;
public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleCommandValidator()
    {
    }
}
