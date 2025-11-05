using UnityEngine;

public class OverworldState : BaseState
{
    private readonly SceneLoader loader;
    public OverworldState(StateMachine context, StateFactory factory, SceneLoader loader)
        : base(context, factory)
    {
        this.loader = loader;
        isRootState = true;
    }
    public override void CheckSwitchStates()
    {
    }
    public override void EnterState()
    {
        loader.LoadSceneAsync("WorldScene", OnSceneLoaded);
    }
    public override void ExitState()
    {
        
    }

    private void OnSceneLoaded()
    {
        InitializeSubState();
    }
    public override void InitializeSubState()
    {
        SetSubState(stateFactory.PlayerControlState());
        subState.EnterState();
    }
    public override void UpdateState()
    {

    }
}
