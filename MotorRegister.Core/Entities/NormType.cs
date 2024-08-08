using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record NormType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public NormType() {}

    public NormType(XmlNormType normType)
    {
        Id = normType.Id;
        Name = normType.Name;
    }
}