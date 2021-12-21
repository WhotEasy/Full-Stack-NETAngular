using ECommerceAPI.DataAcces;
using ECommerceAPI.DataAcces.Repositories;
using ECommerceAPI.Services.Implementations;
using ECommerceAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services)
        {
            services.AddScoped<ECommerceDbConext>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
