using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuState : BaseState
{
    public SettingsMenuState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
        Debug.Log(isRootState);
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Entered Settings menu");
        context.settingsPanel.SetActive(true);
        context.settingsBackButton.onClick.AddListener(() => { SwitchState(stateFactory.MainMenu(new Dictionary<string, object>())); });
    }

    public override void ExitState()
    {
        context.menuPanel.SetActive(false);
        context.settingsPanel.SetActive(false);
        context.playPanel.SetActive(false);
        context.settingsBackButton.onClick.RemoveAllListeners();
    }

    public override void InitializeSubState()
    {
       
    }

    public override void UpdateState()
    {
       CheckSwitchStates();
    }
}
