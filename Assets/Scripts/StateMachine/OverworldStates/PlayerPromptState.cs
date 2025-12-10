using UnityEngine;
using Zenject;

public class PlayerPromptState : BaseState
{
    private Interactable interactable;
    [Inject(Id = "worldPlayer")] private WorldPlayer worldPlayer;
    public PlayerPromptState(StateMachine context, StateFactory factory) : base(context, factory) { }
    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        interactable = (Interactable)data["interactable"];
        worldPlayer.OnTriggerExitEvent += CheckTriggerExit; 
        Debug.Log(interactable.InteractionPrompt);
    }

    public override void ExitState()
    {
        worldPlayer.OnTriggerExitEvent -= CheckTriggerExit;
    }

    public override void InitializeSubState()
    {
        
    }

    public override void UpdateState()
    {
        GatherInput();
        if (Input.GetKeyDown(interactable.InteractKey))
        {
            Debug.Log("Interacted with " + interactable.InteractableType);
            switch(interactable.InteractableType)
            {
                case InteractableType.House:
                    SwitchState(stateFactory.HouseState());
                    break;
                default:
                    Debug.Log("No interaction defined for this type.");
                    break;
            }
        }
    }
    void GatherInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0, vertical).normalized;
        worldPlayer.Input = Quaternion.Euler(0, 45, 0) * inputDir;
    }
    void CheckTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            if (other.gameObject.TryGetComponent<Interactable>(out var exitedInteractable))
            {
                if (exitedInteractable == interactable)
                {
                    SwitchState(stateFactory.PlayerControlState());
                }
            }
        }
    }
    
    
}
