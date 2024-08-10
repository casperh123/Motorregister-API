using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record Vehicle
{
    public string Id { get; set; }
    public string VehicleTypeName { get; set; }
    public string? UsageId { get; set; }
    public Usage? Usage { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? RegistrationNumberExpirationDate { get; set; }
    public Information Information { get; set; }
    public string RegistrationStatus { get; set; }
    public string RegistrationStatusDate { get; set; }
    public List<InspectionResult> InspectionResults { get; set; }
    public List<Permission> Permissions { get; set; }
    public List<DriveType> DriveTypes { get; set; }

    
    public Vehicle() {}

    public Vehicle(Statistik vehicle)
    {
        Id = vehicle.KoeretoejIdent.ToString();
        VehicleTypeName = vehicle.KoeretoejArtNavn;
        Usage = new Usage(vehicle.KoeretoejAnvendelseStruktur);
        UsageId = Usage.Id.ToString();
        RegistrationNumber = vehicle.RegistreringNummerNummer;
        RegistrationNumberExpirationDate = vehicle.RegistreringNummerUdloebDato;
        Information = new Information(vehicle.KoeretoejOplysningGrundStruktur);
        RegistrationStatus = vehicle.KoeretoejRegistreringStatus;
        RegistrationStatusDate = vehicle.KoeretoejRegistreringStatusDato;

        InspectionResults = [];
        Permissions = [];
        DriveTypes = [];

        
        InspectionResults.AddRange(vehicle.SynResultatStruktur.Select(inspectionResult => new InspectionResult(inspectionResult, Id)));

        Permissions.AddRange(
            vehicle.TilladelseSamling
                .Where(permission => permission?.Details != null)
                .Select(permission => new Permission(permission, Id))
        );

        
        if (vehicle.KoeretoejOplysningGrundStruktur?.Motor?.XmlDriveAssembly?.Drives != null)
        {
            DriveTypes.AddRange(vehicle.KoeretoejOplysningGrundStruktur.Motor.XmlDriveAssembly.Drives
                .Where(driveType => driveType.Type != null)
                .Select(driveType => new DriveType(driveType.Type)));
        }

    }
}