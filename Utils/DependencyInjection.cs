using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaTicketManagementSystem.Utils
{
    public static class DependencyInjection
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IProducersService, ProducersService>();
            services.AddScoped<ICinemasService, CinemasService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IMasterService, MasterService>();
        }
    }
}
