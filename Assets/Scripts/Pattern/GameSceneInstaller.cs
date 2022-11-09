using Zenject;


public class GameSceneInstaller : Installer<GameSceneInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<GameSceneSignals.SaveCityName>().OptionalSubscriber();

        Container.BindInterfacesAndSelfTo<ChooseNamePresenter>().AsSingle();
    }
}