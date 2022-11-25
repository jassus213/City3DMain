using Zenject;


public class GameSceneInstaller : Installer<GameSceneInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<GameSceneSignals.SaveCityName>().OptionalSubscriber();
        Container.DeclareSignal<GameSceneSignals.SetCityName>().OptionalSubscriber();
        Container.DeclareSignal<GameSceneSignals.OnDestoyClick>().OptionalSubscriber();

        Container.BindInterfacesTo<InputHandler>().AsSingle();
        Container.Bind<InputState>().AsSingle();

        Container.BindInterfacesTo<MouseHandler>().AsSingle();
        Container.Bind<MouseState>().AsSingle();

        Container.BindInterfacesAndSelfTo<ChooseNamePresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<CityNamePresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<DestroyPresenter>().AsSingle();
    }
}