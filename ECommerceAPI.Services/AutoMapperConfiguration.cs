using Microsoft.Extensions.DependencyInjection;
using ECommerceAPI.Services.Profiles;
using ECommerceAPI.Entities;


namespace ECommerceAPI.Services
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            return services.AddAutoMapper(options =>
            {
                options.AddMaps(typeof(Category));
                options.AddMaps(typeof(Product));
                options.AddProfile<ProductProfile>();
                options.AddProfile<CategoryProfile>();

            });
        }
    }
}
