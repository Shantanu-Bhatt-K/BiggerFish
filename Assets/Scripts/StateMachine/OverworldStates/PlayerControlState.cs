using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerControlState : BaseState
{

    [Inject(Id = "worldPlayer")] private WorldPlayer worldPlayer;
    public PlayerControlState(StateMachine context, StateFactory factory) : base(context, factory) { }

    public override void CheckSwitchStates()
    {
       
    }
    public override void EnterState()
    {
       worldPlayer.OnTriggerEnterEvent += CheckTriggerEnter;
    }
    public override void ExitState()
    {
        worldPlayer.OnTriggerEnterEvent -= CheckTriggerEnter;
       worldPlayer.Input = Vector3.zero;
    }

    public override void InitializeSubState()
    {
       
    }

    public override void UpdateState()
    {
        GatherInput();
    }
    
    void GatherInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0, vertical).normalized;
        worldPlayer.Input = Quaternion.Euler(0, 45, 0) * inputDir;
    }
    void CheckTriggerEnter(Collider other) 
    {
        Debug.Log("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Interactable"))
        {
            if (other.gameObject.TryGetComponent<Interactable>(out var interactable))
            {
                if (interactable.IsPrompt)
                {
                    SwitchState(stateFactory.PlayerPromptState(new Dictionary<string, object> { { "interactable", (object)interactable } }));
                }
            }
        }
    }

    
}
