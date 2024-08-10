using System;
using MotorRegister.Core.XmlModels;
using MotorRegister.Infrastrucutre.Database;

namespace MotorRegister.Core.Entities;

public record Type
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public Type() {}

    public Type(XmlType type)
    {
        Id = type.Id.ToString();
        Name = type.Name;
    }
}