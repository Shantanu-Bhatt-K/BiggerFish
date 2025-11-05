using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState
{
    protected StateMachine context;
    protected StateFactory stateFactory;
    protected Dictionary<string, object> data = new Dictionary<string, object>();
    protected BaseState superState;
    protected BaseState subState;
    protected bool isRootState = false;

    public BaseState(StateMachine _context, StateFactory _stateFactory)
    {
        context = _context;
        stateFactory = _stateFactory;
    }

    public void setArgs(Dictionary<string, object> _data)
    {
        data = _data;
    }   
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubState();


    public void UpdateStates() {
        UpdateState();
        if(subState != null)
        {
            subState.UpdateStates();
        }
    }
    public void ExitStates()
    {
        ExitState();
        if(subState != null)
        {
            subState.ExitStates();
        }
    }
    protected void SwitchState(BaseState _newState)
    {
        Debug.Log("Switching State to " + _newState.GetType().Name);
        ExitStates();
        _newState.EnterState();
        if (isRootState)
        {
            Debug.Log("isRootState");
            context.CurrentState = _newState;
        }
        else if (superState != null)
        {
            Debug.Log("isNotRootState");
            superState.SetSubState(_newState);
        }

    }
    
    protected void SwitchRootState(BaseState newRootState)
    {
        BaseState root = GetRootState();
        root.ExitStates();
        newRootState.EnterState();
        root.context.CurrentState = newRootState;
    }
    protected void SetSuperState(BaseState _newSuperState) 
    {
        superState = _newSuperState;
    }
    protected void SetSubState(BaseState _newSubState)
    {
        subState = _newSubState;
        subState.SetSuperState(this);
    }
    
    protected BaseState GetRootState()
    {
        BaseState root = this;
        while (root.superState != null)
        {
            root = root.superState;
        }
        return root;
    }
}
