namespace StudentRentalShop.rental;

public class RentalRequest
{
    public string FirstName { get; }
    public string LastName { get; } 
    public string EquipmentName { get; }

    public RentalRequest(string firstName, string lastName, string equipmentName)
    {
        FirstName = firstName;
        LastName = lastName;
        EquipmentName = equipmentName;
    }
    
    
}