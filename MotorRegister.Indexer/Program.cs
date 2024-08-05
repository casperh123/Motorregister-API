using MotorRegister.Indexer;
using MotorRegister.Infrastrucutre.FtpDownloader;

var builder = Host.CreateApplicationBuilder(args);

// Configure your FTP client with correct settings
builder.Services.AddSingleton<FtpClient>(provider => new FtpClient("ftp://5.44.137.84", "dmr-ftp-user", "dmrpassword"));

// Ensure that RegisterFileDownloader is properly configured to use the FtpClient
builder.Services.AddSingleton<RegisterFileDownloader>(provider => 
    new RegisterFileDownloader(provider.GetRequiredService<FtpClient>(), provider.GetRequiredService<ILogger<RegisterFileDownloader>>())
);

// Configuring the WeeklyIndexingService with necessary dependencies
builder.Services.AddHostedService<WeeklyIndexingService>(provider =>
    new WeeklyIndexingService(
        provider.GetRequiredService<ILogger<WeeklyIndexingService>>(),
        provider.GetRequiredService<FtpClient>(),
        provider.GetRequiredService<RegisterFileDownloader>(),
        DateTimeOffset.Parse("2024-08-12T00:00:00Z"), // First run time
        7 // Interval in days
    ));

var host = builder.Build();
host.Run();