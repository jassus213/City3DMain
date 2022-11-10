using UnityEngine;
using Zenject;

public class GameStartSceneInstaller : MonoInstaller
{
    [SerializeField] private ChooseNameView _chooseNameView;
    [SerializeField] private CityNameView _cityNameView;
    
    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<ChooseNameView>().FromInstance(_chooseNameView);
        Container.BindInterfacesAndSelfTo<CityNameView>().FromInstance(_cityNameView);
    }
}