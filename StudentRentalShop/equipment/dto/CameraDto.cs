using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class CameraDto : EquipmentDto
{
    public int ResolutionMp { get; }
    public bool IsDigital { get; }

    public CameraDto(string name, int resolutionMp, bool isDigital) : base(name, EquipmentType.Camera)
    {
        ResolutionMp = resolutionMp;
        IsDigital = isDigital;
    }
}