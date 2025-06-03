using System;
using System.Collections.Generic;
using UnityEngine;
using static StateMachine;

public class MenuState : BaseState
{
    public MenuState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
        isRootState = true;
        InitializeSubState();
        
    }

    public override void CheckSwitchStates()
    {
        if(context.gameState == StateMachine.GameStates.Fishing)
        {
            SwitchState(stateFactory.Fishing(new Dictionary<string, object>()));
        }
        else if (context.gameState == StateMachine.GameStates.Aquarium)
        {
            SwitchState(stateFactory.Aquarium(new Dictionary<string, object>()));
        }
    }

    public override void EnterState()
    {
        Debug.Log("Entered Menu State");
    }

    

    public override void ExitState()
    {
        context.menuPanel.SetActive(false);
        context.settingsPanel.SetActive(false);
        context.playPanel.SetActive(false);   
    }

    public override void InitializeSubState()
    {
        Debug.Log("Called Menu Initialize SubState");
        SetSubState(stateFactory.MainMenu(new Dictionary<string, object>()));
        subState.EnterState();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

   
}
    

