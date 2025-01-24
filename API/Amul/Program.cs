using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlantVisit.EFCoreModel;
using PlantVisit.Service.Facilities;
using PlantVisit.Service.Booking;
using PlantVisit.Service.PFMapping;
using PlantVisit.Service.Plant;
using PlantVisit.Service.UserDta;
using PlantVisit.Service.VisitSlot;
using System.Numerics;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFacilities, Facilities>();
//builder.Services.AddScoped<IBooking, Booking>();
//builder.Services.AddScoped<IPFMapping, PFMapping>();
//builder.Services.AddScoped<IPlantList, PlantList>();
//builder.Services.AddScoped<IUserData, UserData>();
//builder.Services.AddScoped<IVisitSlot,VisitSlot>();
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
