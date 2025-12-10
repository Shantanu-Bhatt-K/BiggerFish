using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class HomeControlState : BaseState
{

    [Inject(Id = "worldPlayer")] private WorldPlayer worldPlayer;
    public HomeControlState(StateMachine _context, StateFactory _stateFactory) : base(_context, _stateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState()
    {
        worldPlayer.OnTriggerEnterEvent += CheckTriggerEnter;   
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void InitializeSubState()
    {
        throw new System.NotImplementedException();
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
                    SwitchState(stateFactory.HomePromptState(new Dictionary<string, object> { { "interactable", (object)interactable } }));
                }
            }
        }
    }
    
}
