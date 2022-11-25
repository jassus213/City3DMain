using UnityEngine;
using Zenject;

public class GameViewInstaller : MonoInstaller
{
    [SerializeField] private ChooseNameView _chooseNameView;
    [SerializeField] private CityNameView _cityNameView;
    [SerializeField] private DestoyView _destoyView;
    
    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<ChooseNameView>().FromInstance(_chooseNameView);
        Container.BindInterfacesAndSelfTo<CityNameView>().FromInstance(_cityNameView);
        Container.BindInterfacesAndSelfTo<DestoyView>().FromInstance(_destoyView);
    }
}