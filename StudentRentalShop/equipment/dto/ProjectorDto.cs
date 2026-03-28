using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class ProjectorDto : EquipmentDto
{
    public int Lumens { get; }
    public bool Is4K { get; }

    public ProjectorDto(string name,  int lumens, bool is4K) : base(name, EquipmentType.Camera)
    {
        Lumens = lumens;
        Is4K = is4K;
    }
}