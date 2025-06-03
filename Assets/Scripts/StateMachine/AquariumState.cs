using System.Collections.Generic;
using UnityEngine;

public class AquariumState : BaseState
{
    private bool isShopping = false;
    public AquariumState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Entered Aquarium State");
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubState()
    {
        if(isShopping)
        {
            SetSubState(stateFactory.Shopping(new Dictionary<string, object>()));
        }
        else
        {
            SetSubState(stateFactory.AquariumIdle(new Dictionary<string, object>()));
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
