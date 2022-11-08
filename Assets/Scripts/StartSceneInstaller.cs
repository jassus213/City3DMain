using UnityEngine;
using Zenject;

public class StartSceneInstaller : MonoInstaller
{
    [SerializeField] private StartMenuView _startMenuView;
    [SerializeField] private SettingsMenuView _settingsMenuView;
        
    public override void InstallBindings()
    {
        MainMenuInstaller.MenuInstaller.Install(Container);
            
        Container.BindInterfacesAndSelfTo<StartMenuView>().FromInstance(_startMenuView);
        //Container.BindInterfacesAndSelfTo<SettingsMenuView>().FromInstance(_settingsMenuView);
    }
}
