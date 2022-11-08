using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public class MenuInstaller : Installer<MenuInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<MainMenuSignals.OnNewGame>().OptionalSubscriber();
            Container.DeclareSignal<MainMenuSignals.OnSettingsMenu>().OptionalSubscriber();
            Container.DeclareSignal<MainMenuSignals.OnBackToStartMenu>().OptionalSubscriber();

            Container.BindInterfacesAndSelfTo<StartScreenPresenter>().AsSingle();
            //Container.BindInterfacesAndSelfTo<SettingsMenuPresenter>().AsSingle();
        }
    }
}