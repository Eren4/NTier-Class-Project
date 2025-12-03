using AutoMapper;
using Project.Bll.Dtos;
using Project.WebApi.Models.RequestModels.AppUserProfiles;
using Project.WebApi.Models.RequestModels.AppUsers;
using Project.WebApi.Models.RequestModels.Categories;
using Project.WebApi.Models.RequestModels.Orders;
using Project.WebApi.Models.RequestModels.Products;
using Project.WebApi.Models.ResponseModels.AppUserProfiles;
using Project.WebApi.Models.ResponseModels.AppUsers;
using Project.WebApi.Models.ResponseModels.Categories;
using Project.WebApi.Models.ResponseModels.Orders;
using Project.WebApi.Models.ResponseModels.Products;

namespace Project.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();

            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();
        }
    }
}
