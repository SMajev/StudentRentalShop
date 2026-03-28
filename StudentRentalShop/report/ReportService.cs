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

    public void printRentalReport()
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
        IReadOnlyList<RentRecord> records = _rentalService.GetUserRecords(user.Id);
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
    
}