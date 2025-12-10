using UnityEngine;
using Zenject;

public class HouseInteriorInstaller : MonoInstaller
{
    [SerializeField] private WorldPlayer worldPlayer;
    public override void InstallBindings()
    {
        Container.BindInstance(worldPlayer).WithId("worldPlayer");
        Container.Bind<HomeControlState>().AsTransient();
        Container.Bind<HomePromptState>().AsTransient();
    }
}