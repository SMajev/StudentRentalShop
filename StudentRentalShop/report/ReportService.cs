using DefaultNamespace;
using StudentRentalShop.rental;
using StudentRentalShop.rental.model;
using StudentRentalShop.service;
using StudentRentalShop.user;
using StudentRentalShop.user.model;

namespace StudentRentalShop.report;

public class ReportService
{
    private static ReportService _instance; 
    
    private RentalService _rentalService = RentalService.Instance();
    private UserService _userService = UserService.Instance();
    private EquipmentService _equipmentService = EquipmentService.Instance();


    private ReportService()
    {
    }

    public static ReportService Instance()
    {
        _instance ??= new ReportService();
        return _instance;
    }

    public void printRentalReportByUser()
    {
        Console.WriteLine("-------------- Rentals --------------");
        foreach (var (userId, records) in _rentalService.GetRecordsByUser())
        {
            User user = _userService.GetUserById(userId);
            Console.WriteLine("User: " + user.FirstName + " " + user.LastName);
            foreach (RentRecord r in records)
            {
                Console.WriteLine($"  {_equipmentService.GetEquipmentById(r.EquipmentId).name} ({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})");
            }
            Console.WriteLine($"{records.Count} records\n");
        }
    }

    public void printAvailableEquipmentReport()
    {   
        Console.WriteLine("-------------- Available Equipment ---------------");
        IReadOnlyList<Equipment> equipments = _equipmentService.GetAvailableEquipments();
        foreach (Equipment equipment in equipments)
        {
            Console.WriteLine(equipment.GetType().ToString().Split(".")[1] + " " + equipment.name);
        }
        Console.WriteLine($"{equipments.Count} records\n");
    }

    public void printActiveRentals()
    {
        Console.WriteLine("-------------- Active Rentals --------------");
        IReadOnlyList<RentRecord> recs = _rentalService.GetActiveRecord();
        foreach (RentRecord rec in recs)
        {
            User user = _userService.GetUserById(rec.UserId);
            
            Console.WriteLine($"  " +
                              $"{_equipmentService.GetEquipmentById(rec.EquipmentId).name} " +
                              $"({rec.DateFrom:dd.MM} - {rec.DateTo:dd.MM})" +
                              $" rented to: {user.FirstName} {user.LastName}"
                              );
            
        }
        Console.WriteLine($"{recs.Count} records\n");
    }
    
    public void PrintEquipmentReport()
    {
        Console.WriteLine("-------------- Equipment --------------");
        foreach (Equipment equipment in _equipmentService.GetEquipments())
        {
            string type = equipment.GetType().ToString().Split(".")[1];
            Console.WriteLine($"Name: {equipment.name}, Type: {type}, ID: {equipment.Id}");
        }
        Console.WriteLine($"{_equipmentService.GetEquipments().Count} equipments\n");
    }

    public void printUsersReport()
    {
        Console.WriteLine("-------------- Users --------------");
        foreach (User user in _userService.GetUsers())
        {
            Console.WriteLine($"Name: {user.FirstName + " " + user.LastName}, Type: {user.GetType().ToString().Split(".")[3]}, ID: {user.Id}");
        }
        Console.WriteLine($"{_userService.GetUsers().Count} users\n");
    }

    public void printRentalsFor(String firstName, String lastName)
    {
        User user = _userService.GetUserByNameLastName(firstName, lastName);
        Console.WriteLine("-------------- User --------------");
        Console.WriteLine("User: " + user.FirstName + " " + user.LastName);
        IReadOnlyList<RentRecord> records = _rentalService.GetActiveUserRecord(user.Id);
        foreach (RentRecord r in records)
        {
            Console.WriteLine($"  {_equipmentService.GetEquipmentById(r.EquipmentId).name} ({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})");
        }
        Console.WriteLine($"{records.Count} records\n");
    }
    
    public void printOverdueRentalsFor()
    {
        Console.WriteLine("-------------- Overdue --------------");
        int counter = 0;
        foreach (RentRecord r in _rentalService.GetOverdueRecords())
        {
            Console.WriteLine($"  {_equipmentService.GetEquipmentById(r.EquipmentId).name} ({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})");
        }
        Console.WriteLine($"{counter} records\n");
    }


    public void PrintRentalGeneralHistory()
    {
        Console.WriteLine("-------------- History --------------");
        int counter = 0;
        foreach (RentRecord r in _rentalService.getRecords())
        {
            Console.WriteLine($"" +
                              $"{_equipmentService.GetEquipmentById(r.EquipmentId).name} " +
                              $"({r.DateFrom:dd.MM} - {r.DateTo:dd.MM})" +
                              $" status: {_equipmentService.GetEquipmentById(r.EquipmentId).status}"
                              );
        }
        Console.WriteLine($"{counter} records\n");
    } 
}