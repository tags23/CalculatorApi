using Calculator.Api.Entities.Requests;
using Calculator.Api.Interfaces;
using Calculator.Api.Middlewares;
using Calculator.Api.Services;
using Calculator.Api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Calculator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Injected services
            builder.Services.AddTransient<ICalculatorService, CalculatorService>();
            builder.Services.AddScoped<ICountriesService, CountriesService>();

            // Validators
            builder.Services.AddScoped<IValidator<TwoDigitCalculationRequest>, TwoDigitCalculationDataValidator>();
            builder.Services.AddScoped<IValidator<SmallestOrBiggestDigitRequest>, SmallestOrBiggestDigitRequesttValidator>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<AuthorizationMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}