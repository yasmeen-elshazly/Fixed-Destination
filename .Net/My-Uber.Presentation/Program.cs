
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using My_Uber.Repositories.Contract;
using My_Uber.Repositories.Repositories;
using My_Uber.Services.MP;
using My_Uber.Services;
using System.Threading.Tasks;
using My_Uber.Context.Context;

namespace Building.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IBuildingService, BuildingService>();
            builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();

            builder.Services.AddDbContext<MyUberDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Configure identity options if needed
            })
            .AddEntityFrameworkStores<MyUberDbContext>()
            .AddDefaultTokenProviders();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


            });

            builder.Services.AddAutoMapper(typeof(MapperProfile)); // Register the mapping profile

            // Configure CORS policy to allow requests from localhost:3000
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowReactApp");
            // Uncomment if authentication is added
            // app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
