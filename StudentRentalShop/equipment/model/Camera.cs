namespace DefaultNamespace;


public class Camera : Equipment
{
    public Camera(string name, int resolutionMp, bool isDigital) : base(name)
    {
        ResolutionMp = resolutionMp;
        IsDigital = isDigital;
    }
    
    public Camera(string name) : base(name)
    {
    }

    public int ResolutionMp { get; set; }
    public bool IsDigital { get; set; }
}