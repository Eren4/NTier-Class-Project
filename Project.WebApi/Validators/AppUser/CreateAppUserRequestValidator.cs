using FluentValidation;
using Project.WebApi.Models.RequestModels.AppUsers;

namespace Project.WebApi.Validators.AppUser
{ 
    public class CreateAppUserRequestValidator : AbstractValidator<CreateAppUserRequestModel>
    {
        public CreateAppUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.")
                .MaximumLength(100);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Sifre boş geçilemez")
                .MaximumLength(100);
        }
    }
}
