using MotorRegister.Core.XmlModels;

namespace MotorRegister.Core.Models;

public record Model
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Constructor to initialize from XmlModel
    public Model(XmlModel xmlModel)
    {
        Id = int.Parse(xmlModel.Id); // Assuming XML ID can be parsed to int
        Name = xmlModel.Name;
    }
}