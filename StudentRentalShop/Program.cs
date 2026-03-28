// See https://aka.ms/new-console-template for more information

using DefaultNamespace;
using StudentRentalShop.equipment.dto;
using StudentRentalShop.rental;
using StudentRentalShop.rental.model;
using StudentRentalShop.service;
using StudentRentalShop.user;
using StudentRentalShop.user.dto;
using StudentRentalShop.user.model;

EquipmentService equipmentService = EquipmentService.Instance();
UserService userService = UserService.Instance();
RentalService rentalService = RentalService.Instance();

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
RentalRequest req2 = new RentalRequest("Jack", "Nicholson", "MSI GP66",2);
RentalRequest req3 = new RentalRequest("Jack", "Nicholson", "MSI GP666", 7);
RentalRequest req4 = new RentalRequest("Jack", "Nicholson", "DJI Osmo",7);
RentalRequest req5 = new RentalRequest("Jack", "Nicholson", "Optoma HD2", 7); 

equipmentService.SetUnavailable("MSI GP66");
Console.WriteLine(rentalService.Rent(Req1));
Console.WriteLine(rentalService.Return(req2));
Console.WriteLine(rentalService.Rent(Req1));
Console.WriteLine(rentalService.Rent(req4));


// rentalService.PrintEquipmentReport();
// rentalService.printRentalReport();
// rentalService.printUsersReport();


rentalService.printRentalsFor("Jack", "Nicholson");
rentalService.printOverdueRentalsFor("Jack", "Nicholson");