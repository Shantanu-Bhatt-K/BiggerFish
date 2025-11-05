using System;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadSceneAsync(string sceneName, Action onLoaded)
    {
        var async = SceneManager.LoadSceneAsync(sceneName);
        async.completed += _ => onLoaded?.Invoke();
    }

}