namespace StudentRentalShop.rental;

public class RentalRequest
{
    
    
    public string FirstName { get; }
    public string LastName { get; } 
    public string EquipmentName { get; }
    public int RentalDurationDays { get; }

    public RentalRequest(string firstName, string lastName, string equipmentName, int rentalDurationDays)
    {
        FirstName = firstName;
        LastName = lastName;
        EquipmentName = equipmentName;
        if (rentalDurationDays > 7) throw new ArgumentException("Rental duration days must be less than 7 days");
        RentalDurationDays = rentalDurationDays;
    }
    
    public RentalRequest(string firstName, string lastName, string equipmentName)
    {
        FirstName = firstName;
        LastName = lastName;
        EquipmentName = equipmentName;
    }
    
    
}