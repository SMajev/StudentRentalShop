namespace DefaultNamespace;

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public bool Is4K { get; set; }
    
    public Projector(string name, int lumens, bool is4K) : base(name)
    {
        if (lumens < 0) throw new ArgumentOutOfRangeException(nameof(lumens));
        Lumens = lumens;
        Is4K = is4K;
    }
}
