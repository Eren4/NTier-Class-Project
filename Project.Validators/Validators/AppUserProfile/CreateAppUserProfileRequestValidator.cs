using FluentValidation;
using Project.WebApi.Models.RequestModels.AppUserProfiles;

namespace Project.WebApi.Validators.AppUserProfile
{
    public class CreateAppUserProfileRequestValidator : AbstractValidator<CreateAppUserProfileRequestModel>
    {
        public CreateAppUserProfileRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş geçilemez")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş geçilemez")
                .MaximumLength(100);
        }
    }
}
