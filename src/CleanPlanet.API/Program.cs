using Serilog;
using Microsoft.OpenApi.Models;
using CleanPlanet.DAL.DbContexts;
using CleanPlanet.API.Extentions;
using CleanPlanet.API.Middlewares;
using CleanPlanet.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CleanPlanet.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanPlanet", Version = "v1" });
        });

        // Add Custom services
        builder.Services.AddServices();

        //Context
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // JWT
        builder.Services.AddJwt(builder.Configuration);
        builder.Services.ConfigureSwagger();

        builder.Services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        });

        //Logger
       var logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .Enrich.FromLogContext()
               .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        PathHelper.WebRootPath = Path.GetFullPath("wwwroot");
        PathHelper.CountryPath = Path.GetFullPath(builder.Configuration.GetValue<string>("FilePath:RegionsFilePath"));
        PathHelper.CountryPath = Path.GetFullPath(builder.Configuration.GetValue<string>("FilePath:CountriesFilePath"));
        PathHelper.CountryPath = Path.GetFullPath(builder.Configuration.GetValue<string>("FilePath:DictrictsFilePath"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            //c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanPlanet v1")
        }

        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}