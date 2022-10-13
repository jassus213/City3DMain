using UnityEngine;

public class SettingsController : MonoBehaviour
{ 
    [SerializeField] private AudioSource _audioSource;
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void StatusFullScreen(bool statusFullScreen)
    {
        Screen.fullScreen = statusFullScreen;
    }
    
    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
