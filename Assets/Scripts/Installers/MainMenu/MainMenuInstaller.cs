using Zenject;


public class MenuInstaller : Installer<MenuInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<MainMenuSignals.OnNewGame>().OptionalSubscriber();
        Container.DeclareSignal<MainMenuSignals.OnSettingsMenu>().OptionalSubscriber();
        Container.DeclareSignal<MainMenuSignals.OnBackToStartMenu>().OptionalSubscriber();

        Container.BindInterfacesAndSelfTo<MainMenuPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<SettingsMenuPresenter>().AsSingle();
    }
}