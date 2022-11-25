using System;
using Zenject;

public class SettingsMenuPresenter : ISettingsMenuPresenter, IInitializable, IDisposable
{
    private readonly ISettingsMenuView _settingsMenuView;
    private readonly SignalBus _signalBus;
    private readonly CommonGameSettings _commonGameSettings;

    public SettingsMenuPresenter(ISettingsMenuView settingsView, SignalBus signalBus, CommonGameSettings commonGameSettings)
    {
        _settingsMenuView = settingsView;
        _signalBus = signalBus;
        _commonGameSettings = commonGameSettings;
    }
    
    public void Initialize()
    {
        _settingsMenuView.SetPresenter(this);
        _settingsMenuView.SetQuality(_commonGameSettings.Quality);
        _settingsMenuView.SetVolume(_commonGameSettings.Volume);
        _settingsMenuView.SetFullScreen(_commonGameSettings.IsFullScreen);

        _signalBus.Subscribe<MainMenuSignals.OnSettingsMenu>(OnSettingsMenuCallback);
    }

    public void OnFullscreenToggle(bool value)
    {
        _settingsMenuView.SetFullScreen(value);
    }

    public void OnVolumeChange(float volume)
    {
        _settingsMenuView.SetVolume(volume);
    }

    public void OnQualityChange(int value)
    {
        _settingsMenuView.SetQuality(value);
    }

    public void OnBackClick()
    {
        _signalBus.Fire<MainMenuSignals.OnBackToStartMenu>();
        _settingsMenuView.Show(false);
    }

    private void OnSettingsMenuCallback(MainMenuSignals.OnSettingsMenu obj)
    {
        _settingsMenuView.Show(true);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<MainMenuSignals.OnSettingsMenu>(OnSettingsMenuCallback);
    }

   
}