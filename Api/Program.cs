using System.Reflection;
using System.Text;
using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Infrastructure;
using Api.Application.Contracts.Persistence;
using Api.Application.Hubs;
using Api.Application.Services;
using Api.Data;
using Api.Data.Models;
using Api.Data.Repositories;
using Api.Infrastructure;
using Api.Infrastructure.Models;
using Api.Middleware;
using Api.Models;
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

builder.Services.AddIdentity<User, Role>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


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
    
    o.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // Если запрос идёт к SignalR Hub, извлеките токен из query string
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/api/v1/notificationHub"))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

#endregion

#region Repositories

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
builder.Services.AddScoped(typeof(IItemHistoryRepository), typeof(ItemHistoryRepository));
builder.Services.AddScoped(typeof(IAssignmentRepository), typeof(AssignmentRepository));
builder.Services.AddScoped(typeof(IAssignmentToUserRepository), typeof(AssignmentToUserRepository));

#endregion
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddSignalR();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:63343", "https://nirvana-dev.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
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
    
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hotel Management System",
        Version = "v1"
    });
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == StatusCodes.Status401Unauthorized)
    {
        response.ContentType = "application/json";
        await response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new CustomProblemDetails
        {
            Type = "UnauthorizedException",
            Title = "You should login to access this resource",
            Status = 401
        }));
    }
    else if (response.StatusCode == StatusCodes.Status403Forbidden)
    {
        response.ContentType = "application/json";
        await response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new CustomProblemDetails
        {
            Type = "ForbiddenException",
            Title = "You can't access this resource",
            Status = 403
        }));
    }
});
// Use global exception handler
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{
    // Show more detailed errors in development
    // IdentityModelEventSource.ShowPII = true; 
}

app.UseHttpsRedirection();
// Use "all" CORS policy, specified above
// app.UseCors("all");
app.UseCors("AllowSpecificOrigin");
app.UseWebSockets();
// Use authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationHub>("api/v1/notificationHub");

app.Run();


