using UnityEngine;
using UnityEngine.InputSystem;

public  class Interactable : MonoBehaviour, IIinteractable
{
    [SerializeField] protected string prompt = "Press E to interact";
    [SerializeField] protected bool isPrompt = false;
    [SerializeField] protected KeyCode interactKey = KeyCode.E;
    [SerializeField] protected InteractableType interactableType;
    public string InteractionPrompt => prompt;
    public bool IsPrompt { get => isPrompt; set => isPrompt = value; }
    public KeyCode InteractKey { get => interactKey; set => interactKey = value; }
    public InteractableType InteractableType { get => interactableType; set => interactableType = value; }
   
}
