using DefaultNamespace;
using StudentRentalShop.equipment.dto;

namespace StudentRentalShop.service;

public class EquipmentService
{
    private static EquipmentService _instance;
    
    List<Equipment> _equipments;
    
    private EquipmentService()
    {
        _equipments = new List<Equipment>();
    }

    public static EquipmentService Instance()
    {
        _instance ??= new EquipmentService();
        return _instance;
    }

    public IReadOnlyList<Equipment> GetEquipments()
    {
        return _equipments;
    }
    
    public IReadOnlyList<Equipment> GetAvailableEquipments()
    {
        return _equipments.Where(x => x.status == EquipmentStatus.Available).ToList();
    }
    
    public void AddEquipment(EquipmentDto equipmentDto)
    {
        _equipments.Add(EquipmentFactory.create(equipmentDto));
    }

    public Guid RentEquipment(string name)
    {
        Equipment equipment = GetEquipmentByName(name);
        if (equipment.status != EquipmentStatus.Available)
        {
            throw new InvalidOperationException(equipment.name + " Equipment is not available");
        }
        equipment.status = EquipmentStatus.Borrowed;
        return equipment.Id;
    }

    public void ReturnEquipment(Guid id)
    {
        Equipment equipment = GetEquipmentById(id);
        if (equipment.status == EquipmentStatus.Available)
        {
            throw new InvalidOperationException(equipment.name + " is already returned.");
        }
        equipment.status = EquipmentStatus.Available;
    }
    
    public void SetUnavailable(string name)
    {
        Equipment equipment = GetEquipmentByName(name);
        if (equipment.status == EquipmentStatus.Unavailable)
        {
            Console.WriteLine(equipment.name + " is already unavailable.");
            return;
        }
        equipment.status = EquipmentStatus.Unavailable;
    }

    
    public Equipment GetEquipmentByName(string name)
    {
        return _equipments.FirstOrDefault(x => x.name == name)
            ?? throw new KeyNotFoundException("Equipment not found");
    }
    
    
    public Equipment GetEquipmentById(Guid id)
    {
        return _equipments.FirstOrDefault(x => x.Id == id)
               ?? throw new KeyNotFoundException("Equipment not found");
    }
}