namespace DefaultNamespace;

public class Factory
{
    public enum EquipmentType
    {
        Laptop,
        Camera,
        Projector
    }


    public static Equipment create(EquipmentType equipmentType)
    {
        return equipmentType switch
        {
            EquipmentType.Laptop => new Laptop(),
            EquipmentType.Camera => new Camera(),
            EquipmentType.Projector => new Projector(),
            _ => throw new ArgumentException("Unknown type")
        };
    } 
}