using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsMenuState : BaseState
{
    [Inject(Id = "settingsBackButton")] private Button settingsBackButton;
    [Inject(Id = "settingsPanel")] private GameObject settingsPanel;

    public SettingsMenuState(StateMachine context, StateFactory factory) : base(context, factory) { }

    public override void CheckSwitchStates(){}

    public override void EnterState()
    {
        settingsPanel.SetActive(true);
        settingsBackButton.onClick.AddListener(OnBack);
        Debug.Log("Entered Settings Menu State");
    }

    public override void ExitState()
    {
        settingsPanel.SetActive(false);
        settingsBackButton.onClick.RemoveListener(OnBack);
    }
    private void OnBack() => SwitchState(stateFactory.MainMenuState());
    public override void InitializeSubState(){}

    public override void UpdateState(){}
}
