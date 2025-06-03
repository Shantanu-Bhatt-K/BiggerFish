using GogoGaga.OptimizedRopesAndCables;
using System.Collections.Generic;
using System.Linq;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    public enum GameStates
    {
        Menu,
        Fishing, 
        Aquarium
    }
    [Header("Menu Attachments")]
    public GameObject menuPanel;
    public GameObject settingsPanel;
    public GameObject playPanel;
    public Button menuBackButton;
    public Button settingsBackButton;
    public Button playButton;
    public Button settingsButton;
    public Button fishButton;
    public Button aquariumButton;
    public Button playBackButton;

    [Header("Game Data")]
    public List<Fish> fishList = new List<Fish>();
    public List<Bait> baitList = new List<Bait>();
    public List<Decoration> decorationList = new List<Decoration>();
    public List<Aquarium> aquariumList = new List<Aquarium>();
    //Player Attachments
    [Header("Player Attachments")]
    [SerializeField] private GameObject Player;

    [Header("Fishing Rod Attachments")]
    [SerializeField] private Transform baseRodBone;
    [SerializeField] private Transform tipRodBone;
    [SerializeField] private Rope fishingRope;
    [SerializeField] private Transform rodTipLocation;
    [SerializeField] private Transform rodTransform;

    [Header("Rod Bend Variables")]
    [SerializeField] private float bendIntensity = 1f;
    [SerializeField] private float smoothness = 5f;

    [Header("Rod Throw Attachments")]
    [SerializeField] private float throwForceModifier = 0.1f;
    [SerializeField] private float fullLineLength = 10f;

    [Header("Bait Attachments")]
    [SerializeField] private Transform baitLocation;
    [SerializeField] private ConfigurableJoint baitJoint;
    [SerializeField] private Rigidbody baitRigidbody;

    BaseState currentState;
    StateFactory stateFactory;

    //public variables
    //Menu Variables
    public GameStates gameState { get;  set; } = GameStates.Menu;
    public Dictionary<string, Fish> allFish = new Dictionary<string, Fish>();
    public Dictionary<string, Bait> allBait = new Dictionary<string, Bait>();
    public Dictionary<string, Decoration> allDecoration = new Dictionary<string, Decoration>(); 
    public Dictionary<string, Aquarium> allAquarium =  new Dictionary<string, Aquarium>();


    ///////////////////////////////////////////////public Get Setters////////////////////////////////////////

    //State Definer
    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }

   

    private void Awake()
    {
        //State Factory setup and Init
        stateFactory = new StateFactory(this);
        currentState = stateFactory.Menu(new Dictionary<string, object>());
        currentState.EnterState();
    }



    void Start()
    {
        
    }

    
    void Update()
    {
        currentState.UpdateStates();
    }
}
