using Zenject;

using UnityEngine;
using UnityEngine.UI;

public class StateMachine : ITickable
{

    BaseState currentState;
    StateFactory stateFactory;

    ///////////////////////////////////////////////public Get Setters////////////////////////////////////////

    //State Definer
    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }

    public StateMachine(StateFactory factory)
    {
        stateFactory = factory;
        currentState = stateFactory.Menu();
        ((MenuState)currentState).SetContext(this);
        currentState.EnterState();
    }
    public void Tick()
    {
        currentState.UpdateStates();
    }
}
