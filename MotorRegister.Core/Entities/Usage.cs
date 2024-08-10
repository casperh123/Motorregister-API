using System.ComponentModel;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;


namespace MotorRegister.Core.Entities;

public record Usage
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Usage() {}

    public Usage(KoeretoejAnvendelseStruktur type)
    {
        Id = type.Id.ToString();
        Name = type.Name;
    }
}