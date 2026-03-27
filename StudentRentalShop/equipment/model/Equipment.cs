using System.ComponentModel;

namespace DefaultNamespace;

public class Equipment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string name { get; set; }
    public EquipmentStatus status { get; set; } = EquipmentStatus.Available;

    public Equipment(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
        this.name = name;
        status = EquipmentStatus.Available;
    }
}
