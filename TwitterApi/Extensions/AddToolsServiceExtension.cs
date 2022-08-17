using AspNetCoreRateLimit;
using BusinessLogic.BusinessLogics.AuthBl;
using BusinessLogic.BusinessLogics.TweetBl;
using BusinessLogic.BusinessLogics.UserBl;
using BusinessLogic.Contracts;
using BusinessLogic.Repository;
using BusinessLogic.Utils;
using Filters;

namespace FinalPorject.Extensions
{
    public static class AddToolsServiceExtension
    {
        public static void AddTools(this IServiceCollection services)
        {
            services.AddScoped<GenerateToken>();
            services.AddScoped<Mapper>();
            services.AddScoped<ShamasiCalendar>();
            services.AddScoped<HashPassword>();
            services.AddScoped<CreatePairToken>();
            services.AddScoped<GenerateToken>();
            services.AddScoped<StandardResultFilter>();
            services.AddCorsConfig();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<ITweetRepository, TweetRepository>();
            services.AddTransient<ITweetUserRepository, TweetUserRepository>();

            services.AddTransient<IAuthBl, AuthBl>();
            services.AddTransient<IUserBl, UserBl>();
            services.AddTransient<ITweetBl, TweetBl>();


            services.AddOptions();
            services.AddMemoryCache();
            services.AddInMemoryRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


        }
    }
}
