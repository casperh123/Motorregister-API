using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record NormType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public NormType() {}

    public NormType(XmlNormType normType)
    {
        Id = normType.Id;
        Name = normType.Name;
    }
}