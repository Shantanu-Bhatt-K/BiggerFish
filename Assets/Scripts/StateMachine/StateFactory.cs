using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StateFactory 
{
    DiContainer container;
   
   public static SceneContext GetCurrentSceneContext()
    {
        var sceneContext = Object.FindAnyObjectByType<SceneContext>();
        if (sceneContext == null)
        {
            Debug.LogError("No SceneContext found in the current scene!");
            return null;
        }
        return sceneContext;
    }

    public static DiContainer GetCurrentSceneContainer()
    {
        var context = GetCurrentSceneContext();
        return context != null ? context.Container : null;
    }

    public StateFactory(DiContainer container)
    {
        this.container = container;
    }

    ///////////////////////////////////////////////// Global States /////////////////////////////////////////////////
    public BaseState Menu()
    {
        return container.Instantiate<MenuState>();
    }

    public BaseState OverworldState()
    {
        return container.Instantiate<OverworldState>();
    }
     public BaseState HouseState()
    {
        return container.Instantiate<HouseState>();
    }
    //////////////////////////////////////////////// Menu Scene States /////////////////////////////////////////////////
    public BaseState MainMenuState()
    {
        return GetCurrentSceneContainer().Instantiate<MainMenuState>();
    }

   

    public BaseState SettingsMenuState()
    {
        return GetCurrentSceneContainer().Instantiate<SettingsMenuState>();
    }
///////////////////////////////////////////////// Overworld Scene States /////////////////////////////////////////////////
    public BaseState PlayerControlState()
    {
        return GetCurrentSceneContainer().Instantiate<PlayerControlState>();
    }
    public BaseState PlayerPromptState(Dictionary<string, object> args)
    {
        var state = GetCurrentSceneContainer().Instantiate<PlayerPromptState>();
        state.setArgs(args); // ✅ Pass data here
        return state;
    }
    
    public BaseState HomeControlState()
    {
        return GetCurrentSceneContainer().Instantiate<HomeControlState>();
    }

    internal BaseState HomePromptState(Dictionary<string, object> dictionary)
    {
        return GetCurrentSceneContainer().Instantiate<HomePromptState>();
    }
}
