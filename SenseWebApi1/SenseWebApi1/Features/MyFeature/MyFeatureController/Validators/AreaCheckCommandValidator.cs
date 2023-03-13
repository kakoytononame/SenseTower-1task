using FluentValidation;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.AreasCommands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Validators
{
    public class AreaCheckCommandValidator:AbstractValidator<AreaCheckCommand>
    {
        public AreaCheckCommandValidator()
        {
            RuleFor(p=>p.AreaId).NotEmpty();
        }
    }
}
