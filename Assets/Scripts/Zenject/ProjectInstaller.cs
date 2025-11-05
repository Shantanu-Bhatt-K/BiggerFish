using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStateMachine();
        BindFactories();
        BindRootStates();
        BindGlobalServices();
    }

    private void BindStateMachine()
    {
        Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle().NonLazy();
    }

    private void BindFactories()
    {
        Container.Bind<StateFactory>().AsSingle();
    }

    private void BindRootStates()
    {
        Container.Bind<MenuState>().AsTransient();
        // Container.Bind<OverworldState>().AsTransient();
        // Container.Bind<FishingState>().AsTransient();
        // Container.Bind<HomeState>().AsTransient();
        // Container.Bind<AquariumState>().AsTransient();
    }

    private void BindGlobalServices()
    {
        Container.Bind<SceneLoader>().AsSingle();
        // Container.Bind<AudioManager>().AsSingle();
        // Container.Bind<PlayerData>().AsSingle();
        // Add more global singletons as needed
    }
}