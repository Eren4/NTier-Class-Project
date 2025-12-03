using FluentValidation;
using Project.WebApi.Models.RequestModels.Orders;

namespace Project.WebApi.Validators.Order
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(o => o.AppUserId)
                .NotEmpty()
                .WithMessage("Kullanıcı id olmalı");

            RuleFor(o => o.ShippingAddress)
                .NotEmpty()
                .WithMessage("Adres boş olamaz")
                .MaximumLength(500);
        }
    }
}
