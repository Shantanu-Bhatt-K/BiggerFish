using System.Collections.Generic;
using UnityEngine;

public class AreaSelectState : BaseState
{
    public AreaSelectState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Entered Fishing Idle");
        SwitchState(stateFactory.FishingIdle(new Dictionary<string, object>()));
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubState()
    {
        
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
