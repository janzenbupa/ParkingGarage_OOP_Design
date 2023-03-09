using ParkingGarage.BL;
using ParkingGarage.BL.SharedLogic;
using ParkingGarage.DAL.ConnectionLogic.SP;
using ParkingGarage.Models.Payloads;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IParkingGarage<PaymentResponse, PaymentRequest>, PaymentLogic>();
builder.Services.AddScoped<IParkingGarage<ParkingSpaceResponse>, ParkingSpaceLogic>();
builder.Services.AddScoped<IParkingGarage<ReservationResponse, ReservationRequest>, ReservationLogic>();
builder.Services.AddSingleton<IShare, Logic>();
builder.Services.AddSingleton<IStoredProcedure, CarSP>();

builder.Configuration.AddJsonFile("appsettings.json", false);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
