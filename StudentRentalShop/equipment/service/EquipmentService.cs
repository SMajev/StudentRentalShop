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

    public Guid GetEquipmentId(string name)
    {
        return GetEquipment(name).Id;
    }
    
    public void AddEquipment(EquipmentDto equipmentDto)
    {
        _equipments.Add(EquipmentFactory.create(equipmentDto));
    }

    public Guid RentEquipment(string name)
    {
        Equipment equipment = GetEquipment(name);
        if (equipment.status != EquipmentStatus.Available)
        {
            throw new InvalidOperationException(equipment.name + " Equipment is not available");
        }
        equipment.status = EquipmentStatus.Borrowed;
        return equipment.Id;
    }

    public string ReturnEquipment(string name)
    {
        Equipment equipment = GetEquipment(name);
        if (equipment.status == EquipmentStatus.Available)
        {
            throw new InvalidOperationException(equipment.name + " is already returned.");
        }
        equipment.status = EquipmentStatus.Available;
        return equipment.Id.ToString();
    }
    
    public void SetUnavailable(string name)
    {
        Equipment equipment = GetEquipment(name);
        if (equipment.status == EquipmentStatus.Unavailable)
        {
            Console.WriteLine(equipment.name + " is already unavailable.");
            return;
        }
        equipment.status = EquipmentStatus.Unavailable;
    }

    
    private Equipment GetEquipment(string name)
    {
        foreach (Equipment equipment in _equipments)
        {   
            if (equipment.name == name)
            {
                return equipment;
            }
        }
        throw new KeyNotFoundException("Equipment not found");
    }
    
    
    public Equipment GetEquipmentById(Guid id)
    {
        foreach (Equipment equipment in _equipments)
        {   
            if (equipment.Id == id)
            {
                return equipment;
            }
        }
        throw new KeyNotFoundException("Equipment not found");
    }
}