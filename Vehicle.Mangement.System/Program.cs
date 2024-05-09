using MongoDB.Driver;
using Vehicle.Management.System.Helpers;
using Vehicle.Management.System.Models.Configuration;
using Vehicle.Management.System.Services.Database;
using Vehicle.Management.System.Services.Vehicle;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDatabaseContext, DatabaseContext>();
builder.Services.AddSingleton<IVehicleService, VehicleService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.Configure<VehicleDataBaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var connectionString = builder.Configuration.GetSection("ConnectionStrings:ConnectionUrl").Value;
    return new MongoClient(connectionString);
});


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
