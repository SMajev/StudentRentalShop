using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class ProjectorDto : EquipmentDto
{
    public int Lumens { get; set; }
    public bool Is4K { get; set; }

    public ProjectorDto(string name, EquipmentType equipmentType, int lumens, bool is4K) : base(name, equipmentType)
    {
        Lumens = lumens;
        Is4K = is4K;
    }
}