using FluentValidation;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.ImagesCommands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Validators
{
    public class ImageCheckCommandValidator:AbstractValidator<ImageCheckCommand>
    {
        public ImageCheckCommandValidator()
        {
            RuleFor(p => p.ImageId).NotEmpty();
        }
    }
}
