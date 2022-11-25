using System;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenuPresenter : IMainMenuPresenter, IInitializable, IDisposable
{
    private readonly IMainMenuView _view;
    private readonly SignalBus _signalBus;

    public MainMenuPresenter(IMainMenuView screenView, SignalBus signalBus)
    {
        _view = screenView;
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        _view.SetPresenter(this);

        _signalBus.Subscribe<MainMenuSignals.OnBackToStartMenu>(OnBackToStartMenuCallback);
    }

    public void OnSettingsClick()
    {
        _view.Show(false);
        _signalBus.Fire<MainMenuSignals.OnSettingsMenu>();
    }

    public void OnNewGameClick()
    {
        SceneManager.LoadScene("GameScene");
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