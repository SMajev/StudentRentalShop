using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class LaptopDto : EquipmentDto
{
    public int RamGb { get; set; }
    public int Cpu { get; set; }

    public LaptopDto(string name, EquipmentType equipmentType, int ramGb, int cpu) : base(name, equipmentType)
    {
        RamGb = ramGb;
        Cpu = cpu;
    }
}