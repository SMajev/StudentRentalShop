namespace StudentRentalShop.rental.model;

public class RentRecord
{
    public Guid UserId;
    public Guid EquipmentId {get; set;}
    public DateTime DateFrom;
    public DateTime DateTo;

    public RentRecord(Guid userId, Guid equipmentId, DateTime dateFrom, DateTime dateTo)
    {
        UserId = userId;
        DateFrom = dateFrom;
        DateTo = dateTo;
        EquipmentId = equipmentId;
    }
}