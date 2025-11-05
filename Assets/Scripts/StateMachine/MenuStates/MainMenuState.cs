using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuState : BaseState
{
    [Inject(Id = "playButton")] private Button playButton;
    [Inject(Id = "settingsButton")] private Button settingsButton;
    [Inject(Id = "mainMenuPanel")] private GameObject mainMenuPanel;
    public MainMenuState(StateMachine context, StateFactory factory) : base(context, factory) { }

    public override void EnterState()
    {
        playButton.onClick.AddListener(OnPlay);
        settingsButton.onClick.AddListener(OnSettings);
        mainMenuPanel.SetActive(true);
        Debug.Log("Entered Main Menu State");
    }

    public override void ExitState()
    {
        playButton.onClick.RemoveListener(OnPlay);
        settingsButton.onClick.RemoveListener(OnSettings);
        mainMenuPanel.SetActive(false);
    }
    
    private void OnPlay() => SwitchRootState(stateFactory.OverworldState());
    private void OnSettings() => SwitchState(stateFactory.SettingsMenuState());

    public override void InitializeSubState() { }
    public override void UpdateState() { }
    public override void CheckSwitchStates() { }
}
