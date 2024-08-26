using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Indexer;
using MotorRegister.Indexer.Indexing;
using MotorRegister.Infrastrucutre.Database;
using MotorRegister.Infrastrucutre.FtpDownloader;
using MotorRegister.Infrastrucutre.Repository;
using MotorRegister.Infrastrucutre.XmlDeserialization;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

string environment = builder.Environment.EnvironmentName;
string databaseFileName = "MotorRegister.db";

// Ensure the database is created and get the connection
SqliteConnection sqliteConnection = DatabaseInitializer.EnsureDatabaseCreated(environment, databaseFileName);
builder.Services.AddSingleton(sqliteConnection);

// Configure DbContext
builder.Services.AddDbContext<MotorRegisterDbContext>(options =>
    options.UseSqlite($"Data Source={sqliteConnection.DataSource}"));


//This information is public information from MotorStyrelsen, and thus not kept as a secret.
builder.Services.AddSingleton(
    new FtpClient(
        "ftp://5.44.137.84", 
        "dmr-ftp-user", 
        "dmrpassword"
    )
);

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<RegisterFileDownloader>();
builder.Services.AddScoped<XmlDeserializer>();
builder.Services.AddScoped<VehicleIndexer>();
builder.Services.AddLogging();

builder.Services.AddHostedService<WeeklyIndexingService>();


builder.Logging.SetMinimumLevel(LogLevel.Error);
IHost host = builder.Build();

using IServiceScope scope = host.Services.CreateScope();
MotorRegisterDbContext dbContext = scope.ServiceProvider.GetRequiredService<MotorRegisterDbContext>();
dbContext.Database.Migrate();

host.Run();