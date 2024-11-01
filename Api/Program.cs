using System.Reflection;
using System.Text;
using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Infrastructure;
using Api.Application.Contracts.Persistence;
using Api.Application.Services;
using Api.Data;
using Api.Data.Models;
using Api.Data.Repositories;
using Api.Infrastructure;
using Api.Infrastructure.Models;
using Api.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

#region Identity

builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("BackendDbConnectionString"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = configuration["JwtSettings:Issuer"],
        ValidAudience = configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))

    };
});

#endregion

#region Repositories

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
// Add HttpContext to interact with current request
builder.Services.AddHttpContextAccessor();
// Add Swagger to the project
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add JWT Authentication description to Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "Jwt Auth header using the bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    // Add JWT Authentication requirement to Swagger
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();
// Use global exception handler
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Show more detailed errors in development
    IdentityModelEventSource.ShowPII = true; 
}

app.UseHttpsRedirection();
// Use "all" CORS policy, specified above
app.UseCors("all");
// Use authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


