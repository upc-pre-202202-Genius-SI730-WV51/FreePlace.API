using FreePlace.API.Booking.Domain.Repositories;
using FreePlace.API.Booking.Domain.Services;
using FreePlace.API.Booking.Persistence.Repositories;
using FreePlace.API.ParkingLots.Domain.Repositories;
using FreePlace.API.ParkingLots.Domain.Services;
using FreePlace.API.ParkingLots.Persistence.Repositories;
using FreePlace.API.ParkingLots.Services;
using FreePlace.API.Security.Authorization.Handlers.Implementations;
using FreePlace.API.Security.Authorization.Handlers.Interfaces;
using FreePlace.API.Security.Authorization.Middleware;
using FreePlace.API.Security.Authorization.Settings;
using FreePlace.API.Shared.Domain.Repositories;
using FreePlace.API.Shared.Domain.Services;
using FreePlace.API.Shared.Persistence.Contexts;
using FreePlace.API.Shared.Persistence.Repositories;
using FreePlace.API.Shared.Services;
using Microsoft.OpenApi.Models;


using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
    {
        // Add API Documentation Information
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "FreePlace API",
            Description = "FreePlace RESTful API",
            TermsOfService = new Uri("https://freeplace.com"),
            Contact = new OpenApiContact
            {
                Name = "FreePlace.studio",
                Url = new Uri("https://FreePlace.studio")
            },
            License = new OpenApiLicense
            {
                Name = "FreePlace Resources License",
                Url = new Uri("https://FreePlace.com/license")
            }
        });
        options.EnableAnnotations();
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//

/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, IBookingService>();
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(
    typeof(FreePlace.API.Shared.Mapping.ModelToResourceProfile),
    typeof(FreePlace.API.Shared.Mapping.ResourceToModelProfile));

builder.Services.AddSwaggerGen(options =>
    {
        // Add API Documentation Information
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "FreePlace API",
            Description = "FreePlace RESTful API",
            TermsOfService = new Uri("https://freeplace.com"),
            Contact = new OpenApiContact
            {
                Name = "FreePlace.studio",
                Url = new Uri("https://FreePlace.studio")
            },
            License = new OpenApiLicense
            {
                Name = "FreePlace Resources License",
                Url = new Uri("https://FreePlace.com/license")
            }
        });
        options.EnableAnnotations();
    }
);


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

*/