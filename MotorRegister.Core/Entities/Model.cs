using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Model
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Model() {}

    public Model(XmlModel model)
    {
        Id = model.Id.ToString();
        Name = model.Name;
    }
}