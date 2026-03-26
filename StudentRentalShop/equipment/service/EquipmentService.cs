using DefaultNamespace;
using StudentRentalShop.equipment.dto;

namespace StudentRentalShop.service;

public class EquipmentService
{
    private static EquipmentService _instance = null;
    
    List<Equipment> _equipments;
    
    private EquipmentService()
    {
        _equipments = new List<Equipment>();
    }

    public static EquipmentService GetInstance()
    {
        if (_instance == null)
        {
            _instance = new EquipmentService();
        }
        return _instance;
    }

    public IReadOnlyList<Equipment> GetEquipments()
    {
        return _equipments;
    }

    public void AddEquipment(EquipmentDto equipmentDto)
    {
        _equipments.Add(EquipmentFactory.create(equipmentDto));
    }

    public void RentEquipment(string name)
    {
        Equipment equipment = GetEquipment(name);
        if (equipment.status != EquipmentStatus.Available)
        {
            Console.WriteLine(equipment.name + " is not available.");
            return;
        }
        equipment.status = EquipmentStatus.Borrowed;
    }

    public void ReturnEquipment(string name)
    {
        Equipment equipment = GetEquipment(name);
        if (equipment.status == EquipmentStatus.Available)
        {
            Console.WriteLine(equipment.name + " is already returned.");
            return;
        }
        equipment.status = EquipmentStatus.Available;
    }
    
    public void setUnavailable(string name)
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
    
    
}