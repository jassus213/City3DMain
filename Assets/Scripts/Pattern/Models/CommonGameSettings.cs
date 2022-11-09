public class CommonGameSettings
{
    private string _cityName;
    public string CityName => _cityName;
    
    private float _volume;
    public float Volume => _volume;

    private bool _isFullScreen;
    public bool IsFullScreen => _isFullScreen;
        
    private int _quality;
    public int Quality => _quality;

    public CommonGameSettings()
    {
        _volume = 0.5f;
        _isFullScreen = false;
        _quality = 2;
        
    }

    public void SetCityName(string name)
    {
        _cityName = name;
    }

    public void SetVolume(float volume)
    {
        _volume = volume;
    }

    public void SetFullScreen(bool value)
    {
        _isFullScreen = value;
    }
        
    public void SetQuality(int value)
    {
        _quality = value;
    }
    
}
