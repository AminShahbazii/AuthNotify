
using MassTransit;
using NotificationService.Consumers;
using NotificationService.Interfaces;
using NotificationService.Middleware;
using NotificationService.Services;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables();


builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});


builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<UserRegisteredConsumer>();


    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration["MessageBroker:Host"] ?? throw new InvalidOperationException("RabbitMQ host not configured"),  h =>
        {
            h.Username(builder.Configuration["MessageBroker:Username"] ?? throw new InvalidOperationException("RabbitMQ user name not configured"));
            h.Password(builder.Configuration["MessageBroker:Password"] ?? throw new InvalidOperationException("RabbitMQ password not configured"));
        });

        configurator.ReceiveEndpoint("notification-user-registered-queue", configure =>
        {
            configure.ConfigureConsumer<UserRegisteredConsumer>(context);
        });


    });
});

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference();

app.UseMiddleware<CorrelationIdMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
