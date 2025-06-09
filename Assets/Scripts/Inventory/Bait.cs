using UnityEngine;

public enum ModifierType
{
    None,
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
    public ModifierType modifierType;
    public fishRarity modifiedRarity;
    public float sizeModifier;
    public float easeModifier;
    public string prefabPath;
    public int cost;

    public Bait_Data ToBaitData()
    {
        Bait_Data bData = new()
        {
            GUID = GUID,
            Name = Name,
            modifierType = (int)modifierType,
            modifiedRarity = (int)modifiedRarity,
            sizeModifier = sizeModifier,
            easeModifier = easeModifier,
            prefabPath = prefabPath,
            cost = cost
        };
        return bData;
    }
}

public class Bait_Data
{
    public string GUID { get; set; }
    public string Name { get; set; }
    public int modifierType { get; set; }
    public int modifiedRarity { get; set; } // fishRarity enum stored as int
    public float sizeModifier { get; set; }
    public float easeModifier { get; set; }
    public string prefabPath { get; set; }
    public int cost { get; set; }

    public Bait ToBaitData()
    {
        Bait bData = new()
        {
            GUID = GUID,
            Name = Name,
            modifierType = (ModifierType)modifierType,
            modifiedRarity = (fishRarity)modifiedRarity,
            sizeModifier = sizeModifier,
            easeModifier = easeModifier,
            prefabPath = prefabPath,
            cost = cost
        };
        return bData;
    }
}