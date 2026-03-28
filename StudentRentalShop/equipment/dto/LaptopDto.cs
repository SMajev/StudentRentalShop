using DefaultNamespace;

namespace StudentRentalShop.equipment.dto;

public class LaptopDto : EquipmentDto
{
    public int RamGb { get; }
    public int Cpu { get; set; }

    public LaptopDto(string name, int ramGb, int cpu) : base(name, EquipmentType.Laptop)
    {
        RamGb = ramGb;
        Cpu = cpu;
    }
}