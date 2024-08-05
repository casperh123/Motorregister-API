using MotorRegister.Core.Repository;
using MotorRegister.Indexer;
using MotorRegister.Infrastrucutre;
using MotorRegister.Infrastrucutre.FtpDownloader;
using MotorRegister.Infrastrucutre.Repository;
using MotorRegister.Infrastrucutre.XmlDeserialization;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<MotorRegisterDbContext>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddSingleton(
    new FtpClient(
        "ftp://5.44.137.84", 
        "dmr-ftp-user", 
        "dmrpassword"
    )
);

builder.Services.AddSingleton(
    provider => 
        new XmlDeserializer(
            1046, 
            provider.GetRequiredService<ILogger<XmlDeserializer>>()
        )
);
builder.Services.AddSingleton<RegisterFileDownloader>(
    provider => 
        new RegisterFileDownloader(
            provider.GetRequiredService<FtpClient>(), 
            provider.GetRequiredService<ILogger<RegisterFileDownloader>>()
        )
);

builder.Services.AddHostedService<WeeklyIndexingService>(
    provider =>
        new WeeklyIndexingService(
            provider,
            provider.GetRequiredService<ILogger<WeeklyIndexingService>>(),
            DateTimeOffset.Now, 
            7
        )
);

var host = builder.Build();
host.Run();