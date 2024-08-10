using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record Variant
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Variant() {}

    public Variant(XmlVariant variant)
    {
        Id = variant.Id.ToString();
        Name = variant.Name;
    }
}