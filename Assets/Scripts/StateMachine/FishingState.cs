using System.Collections.Generic;
using UnityEngine;

public class FishingState : BaseState
{
    public FishingState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
        isRootState = true;
    }

    public override void CheckSwitchStates()
    {
       
    }

    public override void EnterState()
    {
        Debug.Log("Entered Fishing State");
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubState()
    {
        SetSubState(stateFactory.AreaSelect(new Dictionary<string, object>()));
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
