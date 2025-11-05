using SQLite;
using UnityEngine;


public enum FishRarity
{
    NA, //for testing and fish bait
    Common, //93.15%
    Uncommon,//4.50%
    Rare, //1.50%
    Epic, //0.73%
    Legendary //0.12%
}

public enum Environment
{
    Pond,
    Lake,
    River,
    Reef,
    Ocean
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
    public float minSize;//length multiplier
    public float maxSize;//length multiplier
    public int baseSellCost;
    public string prefabPath;
    public FishRarity rarity;

    [Header("Catching Variables")]
    public Environment environment;
    public float catchingAreaRadius;

    [Header("Minigame variables")]
    public float xSpeed;
    public float ySpeed;
    public float xOffset;
    public float yOffset;

    [Header("Aquarium Variables")]

    public int spaceRequired;
    public float followBias;
    public float cohesiveBias;
    public float seperationBias;
    public float alignmentBias;
    public float maxSpeed;

    public Fish_Data ToFishData()
    {
        Fish_Data retFish = new()
        {
            Name = Name,
            GUID = GUID,
            minSize = minSize,
            maxSize = maxSize,
            baseSellCost = baseSellCost,
            prefabPath = prefabPath,
            rarity = (int)rarity,
            environment = (int)environment,
            catchingAreaRadius = catchingAreaRadius,
            xSpeed = xSpeed,
            ySpeed = ySpeed,
            xOffset = xOffset,
            yOffset = yOffset,
            spaceRequired = spaceRequired,
            followBias = followBias,
            cohesiveBias = cohesiveBias,
            seperationBias = seperationBias,
            alignmentBias = alignmentBias,
            maxSpeed = maxSpeed
        };
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
    public int spaceRequired { get; set; }
    public float followBias { get; set; }
    public float cohesiveBias { get; set; }
    public float seperationBias { get; set; }
    public float alignmentBias { get; set; }
    public float maxSpeed { get; set; }
    public Fish ToFish()
    {
        Fish retFish = new()
        {
            Name = Name,
            GUID = GUID,
            minSize = minSize,
            maxSize = maxSize,
            baseSellCost = baseSellCost,
            prefabPath = prefabPath,
            rarity = (FishRarity)rarity,
            environment = (Environment)environment,
            catchingAreaRadius = catchingAreaRadius,
            xSpeed = xSpeed,
            ySpeed = ySpeed,
            xOffset = xOffset,
            yOffset = yOffset,
            spaceRequired = spaceRequired,
            followBias = followBias,
            cohesiveBias = cohesiveBias,
            seperationBias = seperationBias,
            alignmentBias = alignmentBias,
            maxSpeed = maxSpeed
        };
        return retFish;
    }
}