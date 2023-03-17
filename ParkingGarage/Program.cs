using ParkingGarage.BL;
using ParkingGarage.DAL.ConnectionLogic.cs.SP;
using ParkingGarage.DAL.ConnectionLogic.SP;
using ParkingGarage.DAL.ConnectionLogic.SP.Interfaces;
using ParkingGarage.Models.Payloads;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IParkingGarage<PaymentResponse, PaymentRequest>, PaymentLogic>();
builder.Services.AddScoped<IParkingGarage<ParkingSpaceResponse>, ParkingSpaceLogic>();
builder.Services.AddScoped<IParkingGarage<ReservationResponse, ReservationRequest>, ReservationLogic>();

builder.Services.AddSingleton<ICarSP, CarSP>();
builder.Services.AddSingleton<IParkingSpaceSP, ParkingSpaceSP>();
builder.Services.AddSingleton<IReservationSP, ReservationSP>();

builder.Services.AddSingleton<IDictionary<string, IStoredProcedure>>(service =>
    new Dictionary<string, IStoredProcedure>
    {
        { "CarSP", service.GetRequiredService<ICarSP>() },
        { "ParkingSpaceSP", service.GetRequiredService<IParkingSpaceSP>() },
        { "ReservationSP", service.GetRequiredService<IReservationSP>() }
    }
);

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
