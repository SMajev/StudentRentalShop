using StudentRentalShop.equipment.dto;

namespace DefaultNamespace;

public class EquipmentFactory
{
    public static Equipment create(EquipmentDto equipmentDto)
    {
        return equipmentDto switch
        {
            LaptopDto dto => new Laptop(dto.Name, dto.RamGb, dto.Cpu),
            CameraDto dto => new Camera(dto.Name, dto.ResolutionMp, dto.IsDigital),
            ProjectorDto dto => new Projector(dto.Name, dto.Lumens, dto.Is4K),

            _ => throw new ArgumentException("Unknown type")
        };
    } 
}