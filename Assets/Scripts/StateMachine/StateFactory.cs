using System.Collections.Generic;
using UnityEngine;

public class StateFactory 
{
    StateMachine context;

    public StateFactory (StateMachine _context)
    {
        context = _context;
    }
    public BaseState Menu(Dictionary<string, object> _data) 
    {
        return new MenuState(context, this, _data);
    }
    public BaseState MainMenu(Dictionary<string, object> _data)
    {
        return new MainMenuState(context, this, _data);
    }
    public BaseState SettingsMenu(Dictionary<string, object> _data)
    {
        return new SettingsMenuState(context, this, _data);
    }
    public BaseState PlayMenu(Dictionary<string, object> _data)
    {
        return new PlayMenuState(context, this, _data);
    }
    public BaseState Aquarium(Dictionary<string, object> _data)
    {
        return new AquariumState(context, this, _data);
    }

    public BaseState Shopping(Dictionary<string, object> _data) 
    {
        return new ShoppingState(context, this, _data);
    }
    public BaseState Fishing(Dictionary<string, object> _data) 
    {
        return new FishingState(context, this, _data);
    }
    public BaseState AreaSelect(Dictionary<string, object> _data) 
    {
        return new AreaSelectState(context, this, _data);
    }
    public BaseState FishingIdle(Dictionary<string, object> _data) 
    {
        return new FishingIdleState(context, this, _data);
    }
    public BaseState AquariumIdle(Dictionary<string, object> _data)
    {
        return new AquariumIdleState(context, this, _data);
    }
    public BaseState LineThrown(Dictionary<string, object> _data) 
    {
        return new LineThrowState(context, this, _data);
    }
    public BaseState BaitSelect(Dictionary<string, object> _data) 
    {
        return new BaitSelectState(context, this, _data);
    }
    public BaseState Bobbing(Dictionary<string, object> _data) 
    {
        return new BobbingState(context, this, _data);
    }
    public BaseState Minigame(Dictionary<string, object> _data) 
    {
        return new MinigameState(context, this, _data);
    }
    public BaseState Result(Dictionary<string, object> _data) 
    {
        return new ResultState(context, this, _data);
    }

}
