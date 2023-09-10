using FluentValidation;

namespace NamiSic.Application.Residents.Commands.UpdateResident;

public class UpdateResidentCommandValidor : AbstractValidator<UpdateResidentCommand>
{
    public UpdateResidentCommandValidor()
    {
    }
}
