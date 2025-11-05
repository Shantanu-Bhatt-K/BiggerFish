using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private Button quitButton;

    public override void InstallBindings()
    {
        // === UI Panels ===
        Container.BindInstance(mainMenuPanel).WithId("mainMenuPanel");
        Container.BindInstance(settingsPanel).WithId("settingsPanel");

        // === Buttons ===
        Container.BindInstance(playButton).WithId("playButton");
        Container.BindInstance(settingsButton).WithId("settingsButton");
        Container.BindInstance(settingsBackButton).WithId("settingsBackButton");
        Container.BindInstance(quitButton).WithId("quitButton");

        // === Substates ===
        Container.Bind<MainMenuState>().AsTransient();
        Container.Bind<SettingsMenuState>().AsTransient();
    }
}
