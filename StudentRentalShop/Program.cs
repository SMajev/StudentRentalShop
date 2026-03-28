// See https://aka.ms/new-console-template for more information


using StudentRentalShop.equipment.dto;
using StudentRentalShop.rental;
using StudentRentalShop.report;
using StudentRentalShop.service;
using StudentRentalShop.user;
using StudentRentalShop.user.dto;
using StudentRentalShop.user.modelenum;

EquipmentService equipmentService = EquipmentService.Instance();
UserService userService = UserService.Instance();
RentalService rentalService = RentalService.Instance();
ReportService reportService = ReportService.Instance();

userService.AddUser(new UserDto("Tom", "Cruise", UserType.Student));
userService.AddUser(new UserDto("Jack", "Nicholson", UserType.Student));
userService.AddUser(new UserDto("Huhg", "Jackman", UserType.Employee));
userService.AddUser(new UserDto("Eva", "Green", UserType.Employee));
userService.AddUser(new UserDto("Margot", "Robbie", UserType.Student));

equipmentService.AddEquipment(new LaptopDto("MSI GP66", 16, 16));
equipmentService.AddEquipment(new CameraDto("DJI Osmo", 10000, true));
equipmentService.AddEquipment(new ProjectorDto("Optoma HD2", 10000, true));
equipmentService.AddEquipment(new LaptopDto("Dell Alienware", 16, 32));
equipmentService.AddEquipment(new LaptopDto("MacBook pro", 16, 16));

RentalRequest Req1 = new RentalRequest("Jack", "Nicholson", "MSI GP66", 7);
RentalRequest Req2 = new RentalRequest("Jack", "Nicholson", "MSI GP66");
RentalRequest Req3 = new RentalRequest("Jack", "Nicholson", "MSI GP666", 7);
RentalRequest Req4 = new RentalRequest("Jack", "Nicholson", "DJI Osmo",7);
RentalRequest Req5 = new RentalRequest("Jack", "Nicholson", "Optoma HD2", 7);

Console.WriteLine("RentOperation: " + rentalService.Rent(Req1));
Console.WriteLine("RentOperation: " + rentalService.Rent(Req2));
Console.WriteLine("RentOperation: " + rentalService.Rent(Req3));
Console.WriteLine("RentOperation: " + rentalService.Rent(Req4));
Console.WriteLine("RentOperation: " + rentalService.Rent(Req5));

reportService.printRentalReport();

reportService.PrintEquipmentReport();

reportService.printUsersReport();

reportService.printRentalsFor("Jack", "Nicholson");


reportService.printOverdueRentalsFor();