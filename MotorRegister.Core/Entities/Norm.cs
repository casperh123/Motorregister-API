using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Norm
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Norm() {}

    public Norm(XmlNormType normType)
    {
        Id = normType.Id.ToString();
        Name = normType.Name;
    }
}