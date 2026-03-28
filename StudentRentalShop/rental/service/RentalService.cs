using DefaultNamespace;
using StudentRentalShop.rental.model;
using StudentRentalShop.service;
using StudentRentalShop.user;
using StudentRentalShop.user.model;

namespace StudentRentalShop.rental;

public class RentalService
{
    private static RentalService _instance;
    
    private EquipmentService _equipmentService = EquipmentService.Instance();
    private UserService _userService = UserService.Instance();
    private Dictionary<Guid, List<RentRecord>> _rentalRecords = new Dictionary<Guid, List<RentRecord>>();
    
    
    public static RentalService Instance()
    {
        _instance ??= new RentalService();
        return _instance;
    }
    
    
    private RentalService()
    {
        
    }

    public IReadOnlyDictionary<Guid, List<RentRecord>> getRecords()
    {
        return _rentalRecords;
    }

    public string Rent(RentalRequest rentalRequest)
    {
        try
        {
            User user = _userService.GetUser(rentalRequest.FirstName, rentalRequest.LastName);
            if (!_rentalRecords.ContainsKey(user.Id)) _rentalRecords.Add(user.Id, new List<RentRecord>());
            if (_rentalRecords[user.Id].Count >= user.MaxLoans)
            {
                return "User is out of capacity";
            }
            RentRecord rentRecord = new RentRecord(
                user.Id,
                _equipmentService.RentEquipment(rentalRequest.EquipmentName),
                DateTime.Now,
                DateTime.Now.AddDays(7)
            );
            _rentalRecords[user.Id].Add(rentRecord);
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
            User user = _userService.GetUser(rentalRequest.FirstName, rentalRequest.LastName);
            RentRecord rec = GetRecord(user.Id, rentalRequest.EquipmentName);
            _rentalRecords[user.Id].Remove(rec);
        }
        catch (KeyNotFoundException e) 
        {
            return e.Message;
        }
        return "OK";
    }

    public RentRecord GetRecord(Guid userId, string equipmentName)
    {
        foreach (RentRecord rec in _rentalRecords[userId])
        {
            if (rec.EquipmentId == _equipmentService.GetEquipmentId(equipmentName))
            {
                return rec;
            }
        }
        throw new KeyNotFoundException("Record not found");
    }


    public void printRentalReport()
    {
        foreach (var (userId, records) in getRecords())
        {
            User user = _userService.GetUserById(userId);
            Console.WriteLine("User: " + user.FirstName + " " + user.LastName);
            foreach (RentRecord r in records)
            {
                Console.WriteLine($"  {_equipmentService.GetEquipmentById(r.EquipmentId).name} ({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})");
            }
            Console.WriteLine($"{records.Count} records");
        }
    }
    
}