using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void StatusFullScreen(bool statusFullScreen)
    {
        Screen.fullScreen = statusFullScreen;
    }
}
