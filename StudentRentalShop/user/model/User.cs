using DefaultNamespace;

namespace StudentRentalShop.user.model;

public abstract class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    List<Equipment> rentedEquipments;

    public abstract int maxLoans { get; }
    
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        rentedEquipments = new List<Equipment>();
    }
    
    public void addEquipmentToAccount(Equipment equipment)
    {
        if (rentedEquipments.Count >= maxLoans) throw  new Exception("Maximum number of equipments exceeded");
        rentedEquipments.Add(equipment);
    }

    public void removeEquipmentFromAccount(Equipment equipment)
    {
        rentedEquipments.Remove(equipment);
    }
}