using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Application.targetFrameRate = 60;

        SignalBusInstaller.Install(Container);
           
        Container.Bind<CommonGameSettings>()
            .ToSelf()
            .AsSingle();
    }
}