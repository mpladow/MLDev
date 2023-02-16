using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Automapper.Mappings;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("defaultConnection");

            // configure identity
            builder.Services.AddIdentity<User, AppRole>()
            .AddEntityFrameworkStores<LOTOWDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<LOTOWDbContext>(options =>
                options.UseSqlServer(connString)
            );
            builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
            builder.Services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRespository>();
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            builder.Services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }




            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}