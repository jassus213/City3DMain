using System;
using Zenject;

public class ChooseNamePresenter : IChooseNamePresenter, IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly IChooseNameView _chooseNameView;

    public ChooseNamePresenter(SignalBus signalBus, IChooseNameView chooseNameView)
    {
        _signalBus = signalBus;
        _chooseNameView = chooseNameView;
    }


    public void Initialize()
    {
        _chooseNameView.SetPresenter(this);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void OnSaveClick()
    {
        _chooseNameView.Show(false);
    }
}