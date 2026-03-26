// See https://aka.ms/new-console-template for more information

using DefaultNamespace;
using StudentRentalShop.equipment.dto;
using StudentRentalShop.service;

Console.WriteLine("Hello, World!");


EquipmentService equipmentService = EquipmentService.GetInstance();

List<EquipmentDto> dtos = new List<EquipmentDto>
{
    new LaptopDto("MSI GP66", EquipmentType.Laptop, 16, 12),
    new CameraDto("DJI Osmo", EquipmentType.Camera, 10000, true),
    new ProjectorDto("Optoma HD2", EquipmentType.Projector, 80000, true)
};

foreach (var dto in dtos)
{
    equipmentService.AddEquipment(dto);
}

var equipments = equipmentService.GetEquipments();

foreach (var equipment in equipments)
{
    Console.WriteLine(equipment.name);
}