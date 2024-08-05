using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record Variant
{
    public long Id { get; set; } 
    public string Name { get; set; }
    
    public Variant() { }
    
    public Variant(XmlVariant xmlType)
    {
        Id = long.Parse(xmlType.Id);
        Name = xmlType.Name;
    }
}