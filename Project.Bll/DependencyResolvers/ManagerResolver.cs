using Microsoft.Extensions.DependencyInjection;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;

namespace Project.Bll.DependencyResolvers
{
    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager,OrderDetailManager>();
        }
    }
}
