using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class CameraDto : EquipmentDto
{
    public int ResolutionMp { get; set; }
    public bool IsDigital { get; set; }

    public CameraDto(string name, EquipmentType equipmentType, int resolutionMp, bool isDigital) : base(name, equipmentType)
    {
        ResolutionMp = resolutionMp;
        IsDigital = isDigital;
    }
}