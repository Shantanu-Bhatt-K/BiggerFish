using UnityEngine;
using Zenject;

public class OverworldInstaller : MonoInstaller
{
    [SerializeField] private WorldPlayer worldPlayer;


    public override void InstallBindings()
    {
        Container.BindInstance(worldPlayer).WithId("worldPlayer");
         Container.Bind<PlayerControlState>().AsTransient();
        Container.Bind<PlayerPromptState>().AsTransient();
    }
}