
using UnityEngine;
using Zenject;
// ReSharper disable All

public class ChooseNamePresenter : IChooseNamePresenter, IInitializable
{
    private readonly SignalBus _signalBus;
    private readonly IChooseNameView _chooseNameView;
    private readonly CommonGameSettings _commonGameSettings;

    public ChooseNamePresenter(SignalBus signalBus, IChooseNameView chooseNameView, CommonGameSettings commonGameSettings)
    {
        _signalBus = signalBus;
        _chooseNameView = chooseNameView;
        _commonGameSettings = commonGameSettings;
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

  
}