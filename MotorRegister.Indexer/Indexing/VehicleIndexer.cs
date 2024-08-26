using System.Threading.Channels;
using MotorRegister.Core.Entities;
using MotorRegister.Core.Repository;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.FtpDownloader;
using MotorRegister.Infrastrucutre.XmlDeserialization;
using Microsoft.Extensions.Logging;

namespace MotorRegister.Indexer.Indexing;

public class VehicleIndexer
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly RegisterFileDownloader _registerFileDownloader;
    private readonly XmlDeserializer _xmlDeserializer;
    private readonly ILogger<VehicleIndexer> _logger;
    private const int BatchSize = 10000;

    public VehicleIndexer(IVehicleRepository vehicleRepository, RegisterFileDownloader registerFileDownloader, XmlDeserializer xmlDeserializer, ILogger<VehicleIndexer> logger)
    {
        _vehicleRepository = vehicleRepository;
        _registerFileDownloader = registerFileDownloader;
        _xmlDeserializer = xmlDeserializer;
        _logger = logger;
    }

    public async Task IndexXmlToDatabaseAsync(CancellationToken stoppingToken)
    {
        // (string zipFilePath, string fileName) = await _registerFileDownloader.DownloadAndSaveRegisterFileAsync(Directory.GetCurrentDirectory());

        string zipFilePath = "./MotorRegister.zip";
        string fileName = "ESStatistikListeModtag.xml";

        Channel<Vehicle> channel = Channel.CreateBounded<Vehicle>(new BoundedChannelOptions(BatchSize * 8)
        {
            SingleWriter = true,
            SingleReader = true,
            FullMode = BoundedChannelFullMode.Wait
        });

        Task producerTask = StartProducerAsync(channel, zipFilePath, fileName, stoppingToken);
        Task consumerTask = StartConsumerAsync(channel, stoppingToken);

        await Task.WhenAll(producerTask, consumerTask);

        _logger.LogInformation("Indexing completed at: {time}", DateTimeOffset.Now);
    }

    private async Task StartProducerAsync(Channel<Vehicle> channel, string zipFilePath, string fileName, CancellationToken stoppingToken)
    {
        try
        {
            await foreach (XmlVehicle xmlVehicle in _xmlDeserializer.DeserializeMotorRegisterAsync(zipFilePath, fileName).WithCancellation(stoppingToken))
            {
                Vehicle vehicle = new Vehicle(xmlVehicle);
                await channel.Writer.WriteAsync(vehicle, stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Producer task was canceled.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the producer task.");
        }
        finally
        {
            channel.Writer.Complete();
        }
    }

    private async Task StartConsumerAsync(Channel<Vehicle> channel, CancellationToken stoppingToken)
    {
        List<Vehicle> vehicleBatch = new List<Vehicle>();
        long dataBaseOperationTime = 0;
        int totalVehiclesProcessed = 0;

        try
        {
            await foreach (Vehicle vehicle in channel.Reader.ReadAllAsync(stoppingToken))
            {
                vehicleBatch.Add(vehicle);

                if (vehicleBatch.Count >= BatchSize)
                {
                    dataBaseOperationTime += await _vehicleRepository.AddVehiclesAsyncWithBenchmark(vehicleBatch);
                    totalVehiclesProcessed += vehicleBatch.Count;
                    _logger.LogInformation($"Processed {vehicleBatch.Count} vehicles. Total: {totalVehiclesProcessed}. DB time: {dataBaseOperationTime} ms.");
                    vehicleBatch.Clear();
                }
            }

            // Process any remaining vehicles in the batch
            if (vehicleBatch.Count > 0)
            {
                dataBaseOperationTime += await _vehicleRepository.AddVehiclesAsyncWithBenchmark(vehicleBatch);
                totalVehiclesProcessed += vehicleBatch.Count;
                _logger.LogInformation($"Processed remaining {vehicleBatch.Count} vehicles. Total: {totalVehiclesProcessed}. DB time: {dataBaseOperationTime} ms.");
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Consumer task was canceled.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the consumer task.");
        }
    }
}
