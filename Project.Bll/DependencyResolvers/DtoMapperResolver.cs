using Microsoft.Extensions.DependencyInjection;
using Project.Bll.MappingProfiles;

namespace Project.Bll.DependencyResolvers
{
    public static class DtoMapperResolver
    {
        public static void AddDtoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
