

interface ISettingsMenuView
{
    void SetPresenter(ISettingsMenuPresenter presenter);

    void Show(bool show);

    void SetFullScreen(bool value);
    void SetVolume(float value);
    void SetQuality(int value);
}