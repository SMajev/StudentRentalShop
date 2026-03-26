using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class EquipmentDto
{
    public string Name { get; set; }
    public EquipmentType EquipmentType { get; set; }

    public EquipmentDto(string name, EquipmentType equipmentType)
    {
        Name = name;
        EquipmentType = equipmentType;
    }
}