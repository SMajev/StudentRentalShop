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
    
    private const int PenaltyPerDayPln = 10;
    
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
                DateTime.Now.AddDays(rentalRequest.RentalDurationDays)
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
            _equipmentService.ReturnEquipment(rentalRequest.EquipmentName);
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
        Console.WriteLine("-------------- Rentals --------------");
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
    
    public void PrintEquipmentReport()
    {
        Console.WriteLine("-------------- Equipment --------------");
        foreach (Equipment equipment in _equipmentService.GetEquipments())
        {
            Console.WriteLine(equipment.Id
                              + " " + equipment.name
                              + " " + equipment.GetType().ToString().Split(".")[1]
            );
        }
    }
    
    public void printUsersReport()
    {
        Console.WriteLine("-------------- Users --------------");
        foreach (User user in _userService.GetUsers())
        {
            Console.WriteLine(
                user.Id
                + ", " + user.FirstName
                + ", " + user.LastName
                + ", " + user.GetType().ToString().Split(".")[3]
            );
        }
    }

    public void printRentalsFor(String firstName, String lastName)
    {
        User user = _userService.GetUser(firstName, lastName);
        Console.WriteLine("-------------- User --------------");
        Console.WriteLine("User: " + user.FirstName + " " + user.LastName);
        foreach (RentRecord r in _rentalRecords[user.Id])
        {
            Console.WriteLine($"  {_equipmentService.GetEquipmentById(r.EquipmentId).name} ({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})");
        }
        Console.WriteLine($"{_rentalRecords[user.Id].Count} records");
    }
    
    public void printOverdueRentalsFor(String firstName, String lastName)
    {
        User user = _userService.GetUser(firstName, lastName);
        Console.WriteLine("-------------- Overdue --------------");
        int counter = 0;
        foreach (RentRecord r in _rentalRecords.SelectMany(x => x.Value))
        {
            if (IsOverdue(r.DateTo))
            {
                Console.WriteLine($"  {_equipmentService.GetEquipmentById(r.EquipmentId).name} ({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})");
            }
            
        }
        Console.WriteLine($"{counter} records");
    }

    private bool IsOverdue(DateTime dateTo)
    {
        return DateTime.Now > dateTo;
    }
}