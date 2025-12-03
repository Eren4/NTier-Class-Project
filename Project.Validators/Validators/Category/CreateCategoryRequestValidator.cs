using FluentValidation;
using Project.WebApi.Models.RequestModels.Categories;

namespace Project.WebApi.Validators.Category
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
