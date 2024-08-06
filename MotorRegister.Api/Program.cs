using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Infrastrucutre.Database;
using MotorRegister.Infrastrucutre.FtpDownloader;
using MotorRegister.Infrastrucutre.Repository;
using MotorRegister.Infrastrucutre.XmlDeserialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

string environment = builder.Environment.EnvironmentName;
string databaseFileName = "MotorRegister.db";

// Ensure the database is created and get the connection
SqliteConnection sqliteConnection = DatabaseInitializer.EnsureDatabaseCreated(environment, databaseFileName);
builder.Services.AddSingleton(sqliteConnection);

// Configure DbContext
builder.Services.AddDbContext<MotorRegisterDbContext>(options =>
    options.UseSqlite($"Data Source={sqliteConnection.DataSource}"));

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseResponseCompression();
app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<MotorRegisterDbContext>();
dbContext.Database.Migrate();

app.Run();