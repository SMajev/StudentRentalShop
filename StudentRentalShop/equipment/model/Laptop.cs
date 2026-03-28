namespace DefaultNamespace;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public int Cpu { get; set; }

    public Laptop(string name, int ramGb, int cpu) : base(name)
    {
        if (ramGb < 0) throw new ArgumentOutOfRangeException(nameof(ramGb));
        if (cpu < 0) throw new ArgumentOutOfRangeException(nameof(cpu));
        RamGb = ramGb;
        Cpu = cpu;
    }
    
}
