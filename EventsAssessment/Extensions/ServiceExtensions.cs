using EventsAssessment.Data.Models;
using EventsAssessment.Repository.Implementation;
using EventsAssessment.Repository.Interfaces;
using EventsAssessment.Services.Implementation;
using EventsAssessment.Services.Interfaces;
using System.Diagnostics.Metrics;

namespace EventsAssessment.Extensions
{
    public static partial class ServiceExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register your services here
            // Example:
            services.AddDbContext<EventsAssessmentContext>();

            services.AddScoped(typeof(Repository.Interfaces.IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IShowTicketRepository, ShowTicketRepository>();


            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ILookupsService, LookupsService>();
            services.AddTransient<IShowTicketService, ShowTicketService>();

            return services;
        }

    }
}
