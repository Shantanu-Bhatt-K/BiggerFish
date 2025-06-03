using UnityEngine;

public enum ModifierType
{
    Rarity, 
    Size, 
    Ease
}
[CreateAssetMenu(fileName = "Bait", menuName = "ScriptableObjects/Bait", order = 1)]
public class Bait : ScriptableObject
{
    [Header("General")]
    public string GUID;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        GUID = System.Guid.NewGuid().ToString();
    }
    public string Name;
    public string modifierType;
    public fishRarity modifiedRarity;
    public float sizeModifier;
    public float easeModifier;
    public GameObject prefabModel;
}

public class Bait_Data
{
    public string GUID { get; set; }
    public string Name { get; set; }
    public string modifierType { get; set; }
    public int modifiedRarity { get; set; } // fishRarity enum stored as int
    public float sizeModifier { get; set; }
    public float easeModifier { get; set; }
    public string prefabPath { get; set; }
}