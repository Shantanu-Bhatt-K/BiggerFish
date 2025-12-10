using UnityEngine;

public class HomePromptState : BaseState
{
    public HomePromptState(StateMachine _context, StateFactory _stateFactory) : base(_context, _stateFactory){}

    public override void CheckSwitchStates()
    {
       
    }

    public override void EnterState()
    {
        Debug.Log("Entered Prompt State");
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubState()
    {
        
    }

    public override void UpdateState()
    {
       
    }
}
