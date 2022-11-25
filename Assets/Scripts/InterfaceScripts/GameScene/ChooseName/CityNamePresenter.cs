using System;
using Zenject;

public class CityNamePresenter : ICityNamePresenter, IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly CityNameView _cityNameView;
    private readonly CommonGameSettings _commonGameSettings;

    public CityNamePresenter(SignalBus signalBus, CityNameView cityNameView, CommonGameSettings commonGameSettings)
    {
        _signalBus = signalBus;
        _cityNameView = cityNameView;
        _commonGameSettings = commonGameSettings;
    }

    public string GetCityName()
    {
        return _commonGameSettings.CityName;
    }

    public void Initialize()
    {
        _cityNameView.SetPreseneter(this);
        
        _signalBus.Subscribe<GameSceneSignals.SetCityName>(OnSetCityName);
        
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<GameSceneSignals.SetCityName>(OnSetCityName);
    }

    private void OnSetCityName(GameSceneSignals.SetCityName obj)
    {
        _cityNameView.SetCityName();
    }
}
