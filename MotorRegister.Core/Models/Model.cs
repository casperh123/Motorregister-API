using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record Model
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Vehicle> Vehicles { get; set; }
    
    public Model() {}
    
    public Model(XmlModel xmlModel)
    {
        Id = int.Parse(xmlModel.Id);
        Name = xmlModel.Name;
    }
}