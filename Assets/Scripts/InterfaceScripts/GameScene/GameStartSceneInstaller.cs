using UnityEngine;
using Zenject;

public class GameStartSceneInstaller : MonoInstaller
{
    [SerializeField] private ChooseNameView _chooseNameView;
    
    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);
            
        Container.BindInterfacesAndSelfTo<ChooseNameView>().FromInstance(_chooseNameView);
    }
}