using MotorRegister.Indexer;
using MotorRegister.Infrastrucutre.FtpDownloader;

var builder = Host.CreateApplicationBuilder(args);

//"ftp://5.44.137.84", "dmr-ftp-user", "dmrpassword"

builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<FtpClient>();
builder.Services.AddSingleton<RegisterFileDownloader>();

var host = builder.Build();

host.Run();
