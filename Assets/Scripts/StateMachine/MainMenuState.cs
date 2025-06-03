using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : BaseState
{
    public MainMenuState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Entered Main menu State");
        context.menuPanel.SetActive(true);
        context.playButton.onClick.AddListener(() => { SwitchState(stateFactory.PlayMenu(new Dictionary<string, object>()));  });
        context.settingsButton.onClick.AddListener(() => { SwitchState(stateFactory.SettingsMenu(new Dictionary<string, object>())); });
        context.menuBackButton.onClick.AddListener(() => { Application.Quit(); });
    }

    public override void ExitState()
    {
        context.menuPanel.SetActive(false);
        context.settingsPanel.SetActive(false);
        context.playPanel.SetActive(false);
        context.playButton.onClick.RemoveAllListeners();
        context.settingsButton.onClick.RemoveAllListeners();
        context.menuBackButton.onClick.RemoveAllListeners();
    }

    public override void InitializeSubState()
    {
       
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
