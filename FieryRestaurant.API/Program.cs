using FieryRestaurant.Business.Mapping;
using FieryRestaurant.Business.Mapping.Implimentation;
using FieryRestaurant.Business.Mapping.Interface;
using FieryRestaurant.Repository.DataAccess;
using FieryRestaurant.Repository.Logger;
using FieryRestaurant.Repository.Repository.Implimentation;
using FieryRestaurant.Repository.Repository.Interface;
using FieryRestaurant.Service;
using FieryRestaurant.Service.Service.Implimentation;
using FieryRestaurant.Service.Service.Interface;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using NLog;

namespace FieryRestaurant.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FieryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FieryDbConnection")));
            builder.Services.AddOData();
            builder.Services.AddAutoMapper(typeof(FieryMapperProfile).Assembly);
            builder.Services.AddScoped<ILoggerManager, LoggerManager>();
            builder.Services.AddScoped<IFieryService, FieryService>();
            builder.Services.AddScoped<IFieryRepository, FieryRepository>();
            builder.Services.AddScoped<IFieryMapping, FieryMapping>();
            builder.Services.AddMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();
            app.UseEndpoints(endpoint =>
            {
                endpoint.EnableDependencyInjection();
                endpoint.Select().Count().Filter().OrderBy().MaxTop(100).SkipToken();
                endpoint.MapControllers();
            });

            app.Run();
        }
    }
}