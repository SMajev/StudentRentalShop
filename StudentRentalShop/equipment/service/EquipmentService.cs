using DefaultNamespace;

namespace StudentRentalShop.service;

public class EquipmentService
{
    private static EquipmentService _instance = null;
    
    List<Equipment> _equipments;
    
    private EquipmentService()
    {
        _equipments = new List<Equipment>();
    }

    public static EquipmentService getInstance()
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

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }

    public void rentEquipment(string name)
    {
        GetEquipment(name).status = EquipmentStatus.Available;
    }

    public void returnEquipment(string name)
    {
        GetEquipment(name).status = EquipmentStatus.Available;
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