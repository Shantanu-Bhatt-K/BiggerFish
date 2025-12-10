using UnityEngine;
using UnityEngine.InputSystem;
public enum InteractableType
{
    House,
    FishShop,
    BaitShop,
    Pond,
    AquariumShelf,
}
public interface IIinteractable
{
    string InteractionPrompt { get; }
    public bool IsPrompt { get; set; }
    public KeyCode InteractKey { get; set; }
    public InteractableType InteractableType { get; set; }
     
}
