using System.ComponentModel;
using DefaultNamespace;
using StudentRentalShop.rental.model;
using StudentRentalShop.service;
using StudentRentalShop.user;
using StudentRentalShop.user.model;

namespace StudentRentalShop.rental;

public class RentalService
{
    private static RentalService _instance;
    
    private readonly EquipmentService _equipmentService = EquipmentService.Instance();
    private readonly UserService _userService = UserService.Instance();
    private readonly List<RentRecord> _records = [];
    private const int PenaltyPerDayPln = 10;
    
    
    private RentalService() {}
    
    public static RentalService Instance()
    {
        _instance ??= new RentalService();
        return _instance;
    }
    
    public IReadOnlyList<RentRecord> getRecords()
    {
        return _records;
    }

    public string Rent(RentalRequest rentalRequest)
    {
        try
        {
            User user = _userService.GetUserByNameLastName(rentalRequest.FirstName, rentalRequest.LastName);
            if (GetUserRecords(user.Id).Count >= user.MaxLoans)
            {
                return "User is out of capacity";
            }
            RentRecord rentRecord = new RentRecord(
                user.Id,
                _equipmentService.RentEquipment(rentalRequest.EquipmentName),
                DateTime.Now,
                DateTime.Now.AddDays(rentalRequest.RentalDurationDays)
            );
            _records.Add(rentRecord);
        }
        catch (KeyNotFoundException e) 
        {
            return e.Message;
        }
        catch (InvalidOperationException e)
        {
            return e.Message;
        }
        return "OK";
    }



    public string Return(RentalRequest rentalRequest)
    {
        try
        {
            User user = _userService.GetUserByNameLastName(rentalRequest.FirstName, rentalRequest.LastName);
            Equipment equipment = _equipmentService.GetEquipmentByName(rentalRequest.EquipmentName);
            RentRecord rec = GetRecord(user.Id, equipment.Id);
            _equipmentService.ReturnEquipment(equipment.Id);
            rec.DateReturned = DateTime.Now;
            
            if (IsOverdue(rec.DateTo))
            {
                int delayDays = (DateTime.Now - rec.DateTo).Days;
                int penalty = delayDays * PenaltyPerDayPln;
                return $"Late return: {delayDays} days. Penalty: {penalty}";
            }
            return "Returned on time.";
        }
        catch (KeyNotFoundException e) 
        {
            return e.Message;
        }
    }
    

    
    private List<RentRecord> GetActiveRecord(Guid userId, Guid equipmentID)
    {
        return GetUserRecords(userId)
                   .Where(rec => rec.isActive())
                   .ToList();
    }

    public List<RentRecord> GetOverdueRecords()
    {
        return _records
            .Where(rec => IsOverdue(rec.DateTo))
            .ToList();  
    }
    
    private RentRecord GetRecord(Guid userId, Guid equipmentID)
    {
        return GetUserRecords(userId)
            .FirstOrDefault(rec => rec.UserId == userId && rec.EquipmentId == equipmentID)
             ?? throw new KeyNotFoundException("Record not found");
    }

    public IReadOnlyList<RentRecord> GetUserRecords(Guid userId)
    {
        return _records
            .Where(rec => rec.UserId == userId)
            .ToList();
    }
    
    public IReadOnlyDictionary<Guid, List<RentRecord>> GetRecordsByUser()
    {
        return _records
            .GroupBy(rec => rec.UserId)
            .ToDictionary(group => group.Key, group => group.ToList());
    }



    private bool IsOverdue(DateTime dateTo)
    {
        return DateTime.Now > dateTo;
    }
}