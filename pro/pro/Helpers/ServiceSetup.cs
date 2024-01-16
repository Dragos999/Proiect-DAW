using pro.Repositories.DistributorRepo;
using pro.Repositories.ItemRepo;
using pro.Repositories.OrderRepo;
using pro.Repositories.ReviewRepo;
using pro.Repositories.UserRepo;
using pro.Services.DistributorService;
using pro.Services.ItemService;
using pro.Services.OrderService;
using pro.Services.ReviewService;
using pro.Services.UserService;

namespace pro.Helpers
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
    }
}
