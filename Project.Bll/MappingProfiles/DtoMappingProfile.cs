using AutoMapper;
using Project.Bll.Dtos;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.MappingProfiles
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser,AppUserDto>().ReverseMap();
            CreateMap<AppUserProfile,AppUserProfileDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<OrderDetail,OrderDetailDto>().ReverseMap();
        }
    }
}
