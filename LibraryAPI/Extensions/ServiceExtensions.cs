using System.Text;
using BusinessLogic.DTOModels.BooksDto;
using BusinessLogic.DTOModels.BooksDto.Validation;
using BusinessLogic.DTOModels.UsersDto;
using BusinessLogic.DTOModels.UsersDto.Validation;
using BusinessLogic.Services.Implementations;
using BusinessLogic.Services.Interfaces;
using Entities.EF;
using Entities.Models;
using Entities.Repositories.Implementations;
using Entities.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryAPI.ExceptionsHandler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace LibraryAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("LibraryAPI");

        services.AddDbContext<LibraryDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(RegisterUserDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(LoginUserDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(BookAddDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(BookEditDtoValidator).Assembly);
    }

    public static void AddSwaggerWithJwt(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            }); 
        });
    }

    public static void AddAuthenticationJwt(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config["JwtSettings:Issuer"],
                ValidAudience = config["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(config["JwtSettings:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILibraryRepository<User>, EFUserRepository>();
        services.AddScoped<ILibraryRepository<Book>, EFBookRepository>();

        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
    
    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, EFUnitOfWork>();
    }
    
    public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)  
    {  
        app.UseMiddleware<ExceptionHandlerMiddleware>();  
    }  
}