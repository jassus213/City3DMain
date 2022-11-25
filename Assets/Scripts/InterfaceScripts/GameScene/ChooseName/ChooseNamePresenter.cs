using UnityEngine;
using Zenject;

// ReSharper disable All

public class ChooseNamePresenter : IChooseNamePresenter, IInitializable, ITickable
{
    private readonly SignalBus _signalBus;
    private readonly IChooseNameView _chooseNameView;
    private readonly CommonGameSettings _commonGameSettings;
    private readonly InputState _inputState;

    public ChooseNamePresenter(SignalBus signalBus, IChooseNameView chooseNameView,
        CommonGameSettings commonGameSettings, InputState inputState)
    {
        _signalBus = signalBus;
        _chooseNameView = chooseNameView;
        _commonGameSettings = commonGameSettings;
        _inputState = inputState;
    }


    public void Initialize()
    {
        _chooseNameView.SetPresenter(this);

        _chooseNameView.SetCityName(_commonGameSettings.CityName);
    }


    public void OnSaveClick()
    {
        var cityName = _chooseNameView.GetCityName();
        if (string.IsNullOrEmpty(cityName))
        {
            _chooseNameView.ErrorCityName("Invalid City Name");
            return;
        }

        _commonGameSettings.SetCityName(cityName);
        _chooseNameView.Show(false);
        _signalBus.Fire<GameSceneSignals.SetCityName>();
        Debug.Log(_commonGameSettings.CityName);
    }


    public void Tick()
    {
        if (_inputState.IsEnterClick)
            OnSaveClick();
        if (_inputState.IsEscClick)
            Debug.Log(true);
    }
}