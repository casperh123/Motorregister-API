using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record NormType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public NormType() {}

    public NormType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public NormType(XmlNormType normType)
    {
        Id = normType.Id;
        Name = normType.Name;
    }
}