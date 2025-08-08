using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.MassTransitConfiguration
{
    public static class MassTransitConfiguration
    {
        public static IServiceCollection AddMassTransitWithRabbitMQ(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host("rabbitmq", 5672,"/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    configurator.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));

                    configurator.UseTimeout(t =>
                    {
                        t.Timeout = TimeSpan.FromSeconds(10);
                    });

                });
            });

            return services;
        }
    }
}
