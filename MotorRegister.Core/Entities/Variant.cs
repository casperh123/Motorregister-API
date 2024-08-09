using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Variant
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public Variant() {}

    public Variant(XmlVariant variant)
    {
        Id = variant.Id;
        Name = variant.Name;
    }
}