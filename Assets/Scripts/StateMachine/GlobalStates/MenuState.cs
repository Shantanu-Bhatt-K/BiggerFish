using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class MenuState : BaseState
{

    private readonly SceneLoader loader;


    
     public MenuState(StateFactory factory, SceneLoader _loader) : base(null, factory) 
    {
        loader = _loader;
       isRootState = true;
    }

    // Optional setter
    public void SetContext(StateMachine sm)
    {
        context = sm;
    }

    public override void CheckSwitchStates()
    {
    }

    public override void EnterState()
    {
        loader.LoadSceneAsync("MenuScene", OnSceneLoaded);
    }
    private void OnSceneLoaded()
    {
        InitializeSubState();
    }
    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {
        SetSubState(stateFactory.MainMenuState());
        subState.EnterState();
    }

    public override void UpdateState()
    {
    }

}
