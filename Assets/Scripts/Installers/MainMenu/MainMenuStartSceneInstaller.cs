using UnityEngine;
using Zenject;

public class MainMenuStartSceneInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private SettingsMenuView _settingsMenuView;
        
    public override void InstallBindings()
    {
        MenuInstaller.Install(Container);
            
        Container.BindInterfacesAndSelfTo<MainMenuView>().FromInstance(mainMenuView);
        Container.BindInterfacesAndSelfTo<SettingsMenuView>().FromInstance(_settingsMenuView);
    }
}
