using SQLite;
using UnityEngine;


public enum fishRarity
{
    Common, //93.15%
    Uncommon,//4.50%
    Rare, //1.50%
    Epic, //0.73%
    Legendary //0.12%
}

public enum Environment
{
    WaterFall,
    River,
    Pond,
    Lake,
    Sea
}
[CreateAssetMenu(fileName = "Fish", menuName = "ScriptableObjects/Fish", order = 1)]
public class Fish : ScriptableObject
{

    [Header("General variables")]
    public string Name;
    public string GUID;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        GUID = System.Guid.NewGuid().ToString();
    }
    public float minSize;
    public float maxSize;
    public int baseSellCost;
    public string prefabPath;
    public fishRarity rarity;

    [Header("Catching Variables")]
    public Environment environment;
    public float catchingAreaRadius;

    [Header("Minigame variables")]
    public float xSpeed;
    public float ySpeed;
    public float xOffset;
    public float yOffset;

    [Header("Aquarium Variables")]

    public float tempVar;
    public float followBias;
    public float cohesiveBias;
    public float seperationBias;
    public float alignmentBias;

    public Fish_Data toFishData()
    {
        Fish_Data retFish= new Fish_Data();
        retFish.Name = Name;
        retFish.GUID = GUID;
        retFish.minSize = minSize;
        retFish.maxSize = maxSize;
        retFish.baseSellCost = baseSellCost;
        retFish.prefabPath = prefabPath;
        retFish.rarity = (int)rarity;
        retFish.environment = (int)environment;
        retFish.catchingAreaRadius = catchingAreaRadius;
        retFish.xSpeed = xSpeed;
        retFish.ySpeed = ySpeed;
        retFish.xOffset = xOffset;
        retFish.yOffset = yOffset;
        retFish.tempVar = tempVar;
        retFish.followBias = followBias;
        retFish.cohesiveBias = cohesiveBias;
        retFish.seperationBias = seperationBias;
        retFish.alignmentBias = alignmentBias;
        return retFish;
    }
}


public class Fish_Data
{
    public string Name { get; set; }
    public string GUID { get; set; }
    public float minSize { get; set; }
    public float maxSize { get; set; }
    public int baseSellCost { get; set; }
    public string prefabPath { get; set; } // store prefab path or Addressable key as string
    public int rarity { get; set; } // store fishRarity enum as int
    public int environment { get; set; } // store Environment enum as int
    public float catchingAreaRadius { get; set; }
    public float xSpeed { get; set; }
    public float ySpeed { get; set; }
    public float xOffset { get; set; }
    public float yOffset { get; set; }
    public float tempVar { get; set; }
    public float followBias { get; set; }
    public float cohesiveBias { get; set; }
    public float seperationBias { get; set; }
    public float alignmentBias { get; set; }
    public Fish toFish()
    {
        Fish retFish = new Fish();
        retFish.Name = Name;
        retFish.GUID = GUID;
        retFish.minSize = minSize;
        retFish.maxSize = maxSize;
        retFish.baseSellCost = baseSellCost;
        retFish.prefabPath = prefabPath;
        retFish.rarity = (fishRarity)rarity;
        retFish.environment = (Environment)environment;
        retFish.catchingAreaRadius = catchingAreaRadius;
        retFish.xSpeed = xSpeed;
        retFish.ySpeed = ySpeed;
        retFish.xOffset = xOffset;
        retFish.yOffset = yOffset;
        retFish.tempVar = tempVar;
        retFish.followBias = followBias;
        retFish.cohesiveBias = cohesiveBias;
        retFish.seperationBias = seperationBias;
        retFish.alignmentBias = alignmentBias;
        return retFish;
    }
}