using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.Facilities;
using PlantVisit.Service.Booking;
using PlantVisit.Service.User;
using PlantVisit.Service.PFMap;
using PlantVisit.Service.Plant;
using PlantVisit.Service.Visit;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", optional: false)
       .Build();

string? connection = config.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<PlantVisitDBContext>(options =>
                options.UseSqlServer(connection));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFacilities, Facility>();
builder.Services.AddScoped<IBooking, Booking>();
builder.Services.AddScoped<IPFMapping, PFMapping>();
builder.Services.AddScoped<IPlant, Plant>();
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IVisit,Visit>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
