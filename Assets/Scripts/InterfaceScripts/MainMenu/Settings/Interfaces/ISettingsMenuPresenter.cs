public interface ISettingsMenuPresenter
{
    void OnFullscreenToggle(bool value);
    void OnVolumeChange(float volume);

    void OnQualityChange(int value);
    void OnBackClick();
}