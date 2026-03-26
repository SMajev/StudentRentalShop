namespace DefaultNamespace;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public int Cpu { get; set; }

    public Laptop(string name, int ramGb, int cpu) : base(name)
    {
        RamGb = ramGb;
        Cpu = cpu;
    }
    
    public Laptop(string name) : base(name)
    {
    }
}
