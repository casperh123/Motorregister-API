using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Type
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public Type() {}

    public Type(XmlType type)
    {
        Id = type.Id;
        Name = type.Name;
    }
}