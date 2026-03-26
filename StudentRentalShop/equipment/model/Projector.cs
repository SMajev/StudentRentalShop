namespace DefaultNamespace;

public class Projector : Equipment
{
    public Projector(string name, int lumens, bool is4K) : base(name)
    {
        Lumens = lumens;
        Is4K = is4K;
    }

    public Projector(string name) : base(name)
    {
    }

    public int Lumens { get; set; }
    public bool Is4K { get; set; }
}
