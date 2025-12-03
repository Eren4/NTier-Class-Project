using FluentValidation;
using Project.WebApi.MappingProfiles;
using Project.WebApi.Validators.AppUser;
using Project.WebApi.Validators.AppUserProfile;
using Project.WebApi.Validators.Category;
using Project.WebApi.Validators.Order;
using Project.WebApi.Validators.Product;

namespace Project.WebApi.ValidatorResolvers
{
    public static class ValidatorResolver
    {
        public static void AddValidatorService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateAppUserRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateAppUserProfileRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
        }
    }
}
