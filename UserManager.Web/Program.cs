
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserManager.Domain.Entities;
using UserManager.Infrastructure.DAL;
using AutoMapper;
using UserManager.Application.Mapping;
using UserManager.Application.Helpers;
using UserManager.Application.Interface;
using UserManager.Application.Services;

namespace UserManager.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("UserrDb"))
        );
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            var app = builder.Build();

           
                app.UseSwagger();
                app.UseSwaggerUI();
            
            ExceptionHandlerMiddleware.ConfigureExceptionHandler(app);
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}