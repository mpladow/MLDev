using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MLDev.AuthService.Services;
using MLDev.AuthSystem.Models.Authentication;
using MLDev.AuthSystem.Repositories;
using MLDev.AuthSystem.Repositories.Interfaces;
using MLDev.AuthSystem.Services;
using MLDev.AuthSystem.Services.Interfaces;
using MLDev.Data.Data;
using MLDev.LOTOW.Automapper.Mappings;
using MLDev.LOTOW.Repositories;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services;
using MLDev.LOTOW.Services.Interfaces;
using System.Text;

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

         if (builder.Environment.IsProduction())
            {
                builder.Configuration.AddAzureKeyVault(
                    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
                    new DefaultAzureCredential());
            }

            // configure jwt and auth
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JwtAuthentication:ValidIssuer"],
                        ValidAudience = builder.Configuration["JwtAuthentication:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtAuthentication:AccessTokenSecret"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            builder.Services.AddDbContext<LOTOWDbContext>(options =>
                options.UseSqlServer(connString));
            builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
            builder.Services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRespository>();
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            builder.Services.AddScoped<IClaimsService, ClaimsService>();
            builder.Services.AddScoped<IJWTokenService, JwTokenService>();
            //builder.Services.AddAutoMapper(AppDomain
            //    .CurrentDomain.GetAssemblies());
            //builder.Services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(typeof(UserMappingProfile));
            });
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