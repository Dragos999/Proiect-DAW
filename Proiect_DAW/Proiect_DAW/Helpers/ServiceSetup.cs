using Proiect_DAW.Helpers.JwtUtilsDir;
using Proiect_DAW.Repositories.DistributorRepo;
using Proiect_DAW.Repositories.ItemRepo;
using Proiect_DAW.Repositories.OrderRepo;
using Proiect_DAW.Repositories.ReviewRepo;
using Proiect_DAW.Repositories.UserRepo;
using Proiect_DAW.Services.DistributorService;
using Proiect_DAW.Services.ItemService;
using Proiect_DAW.Services.OrderService;
using Proiect_DAW.Services.ReviewService;
using Proiect_DAW.Services.UserService;

namespace Proiect_DAW.Helpers
{
    public static class ServiceSetup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IItemRepo, ItemRepo>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            services.AddTransient<IReviewRepo, ReviewRepo>();
            services.AddTransient<IDistributorRepo, DistributorRepo>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IDistributorService, DistributorService>();
            return services;
        }
        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
