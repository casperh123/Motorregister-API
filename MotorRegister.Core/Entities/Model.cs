using System.ComponentModel.DataAnnotations;
using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Entities;

public record Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Model() {}

    public Model(XmlModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }
}