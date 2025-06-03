using System.Collections.Generic;
using UnityEngine;
using static StateMachine;

public class PlayMenuState : BaseState
{
    public PlayMenuState(StateMachine _context, StateFactory _stateFactory, Dictionary<string, object> _data) : base(_context, _stateFactory, _data)
    {
        Debug.Log(isRootState);
    }

    public override void CheckSwitchStates()
    {
       
    }

    public override void EnterState()
    {
        Debug.Log("Entered Play menu");
        context.playPanel.SetActive(true);
        context.fishButton.onClick.AddListener(() => { context.gameState = GameStates.Fishing; Debug.Log("Pressed To Fish"); });
        context.aquariumButton.onClick.AddListener(() => { context.gameState = GameStates.Aquarium; Debug.Log("Pressed To aquarium"); });


        context.playBackButton.onClick.AddListener(() => { SwitchState(stateFactory.MainMenu(new Dictionary<string, object>())); });
    }

    public override void ExitState()
    {
        context.menuPanel.SetActive(false);
        context.settingsPanel.SetActive(false);
        context.playPanel.SetActive(false);
        context.fishButton.onClick.RemoveAllListeners();
        context.aquariumButton.onClick.RemoveAllListeners();
        context.playBackButton.onClick.RemoveAllListeners();
    }

    public override void InitializeSubState()
    {
        
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    
}
