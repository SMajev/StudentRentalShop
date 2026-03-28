namespace DefaultNamespace;


public class Camera : Equipment
{
    public int ResolutionMp { get; set; }
    public bool IsDigital { get; set; }
    
    public Camera(string name, int resolutionMp, bool isDigital) : base(name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
        if (resolutionMp <= 0) throw new ArgumentException(nameof(resolutionMp));
        if (resolutionMp < 1) throw new ArgumentException(nameof(resolutionMp));
        ResolutionMp = resolutionMp;
        IsDigital = isDigital;
    }
    
}