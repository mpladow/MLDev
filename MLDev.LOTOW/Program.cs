using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MLDev.LOTOW.Data;
using MLDev.LOTOW.Models;
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
            builder.Services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<LOTOWDbContext>()
            .AddDefaultTokenProviders();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<LOTOWDbContext>(options =>
                options.UseSqlServer(connString)
            );

            builder.Services.AddScoped<ICharacterService, CharacterService>();
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