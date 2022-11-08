using System;
using Zenject;

public class StartScreenPresenter : IStartMenuPresenter, IInitializable, IDisposable
{
    private readonly IStartMenuView _view;
    private readonly SignalBus _signalBus;

    public StartScreenPresenter(IStartMenuView screenView, SignalBus signalBus)
    {
        _view = screenView;
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        _view.SetPresenter(this);

        _signalBus.Subscribe<MainMenuSignals.OnBackToStartMenu>(OnBackToStartMenuCallback);
    }

    public void OnNewGameClick()
    {
        _view.Show(false);
        _signalBus.Fire<MainMenuSignals.OnNewGame>();
    }

    public void OnSettingsClick()
    {
        _view.Show(false);
        _signalBus.Fire<MainMenuSignals.OnSettingsMenu>();
    }


    public void Dispose()
    {
        _signalBus.Unsubscribe<MainMenuSignals.OnBackToStartMenu>(OnBackToStartMenuCallback);
    }

    private void OnBackToStartMenuCallback(MainMenuSignals.OnBackToStartMenu obj)
    {
        _view.Show(true);
    }
}