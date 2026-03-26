namespace DefaultNamespace;

public class Equipment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
    
}
