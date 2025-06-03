using UnityEditor;
using UnityEngine;
using SQLite;
using System.IO;
using System.Collections.Generic;

public static class DatabaseCreator
{
    [MenuItem("Tools/Generate Game Tables")]
    public static void CreateDatabasetable()
    {
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);
        db.Execute("CREATE TABLE IF NOT EXISTS All_Fish (GUID TEXT PRIMARY KEY, Name TEXT, minSize REAL, maxSize REAL, baseSellCost INTEGER, prefabPath TEXT, rarity INTEGER, environment INTEGER, catchingAreaRadius REAL, xSpeed REAL, ySpeed REAL, xOffset REAL, yOffset REAL, tempVar REAL, followBias REAL, cohesiveBias REAL, seperationBias REAL, alignmentBias REAL);");
        db.Execute("CREATE TABLE IF NOT EXISTS All_Aquarium (GUID TEXT PRIMARY KEY, Name TEXT, maxSpace INTEGER, width REAL, height REAL, depth REAL, prefabPath TEXT, maxDecoration INTEGER);");
        db.Execute("CREATE TABLE IF NOT EXISTS All_Bait (GUID TEXT PRIMARY KEY, Name TEXT, modifierType TEXT, modifiedRarity INTEGER, sizeModifier REAL, easeModifier REAL, prefabPath TEXT);");
        db.Execute("CREATE TABLE IF NOT EXISTS All_Decorations (GUID TEXT PRIMARY KEY, Name TEXT, prefabPath TEXT);");

        Debug.Log("Created Tables");
    }

    [MenuItem("Tools/Fill Fish Table")]
    public static void FillFishTable()
    {
        List<Fish> allFish = new List<Fish>();
        string[] guids = AssetDatabase.FindAssets("t:Fish");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Fish fishAsset = AssetDatabase.LoadAssetAtPath<Fish>(path);
            if (fishAsset != null)
            {
                allFish.Add(fishAsset);
            }
        }

        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);

        foreach (Fish fish in allFish)
        {

            Fish_Data fish_data = fish.toFishData();
            string query = $"INSERT INTO All_Fish (GUID, Name, minSize, maxSize, baseSellCost, prefabPath, rarity, environment, catchingAreaRadius, xSpeed, ySpeed, xOffset, yOffset, tempVar, followBias, cohesiveBias, seperationBias, alignmentBias) VALUES ('{fish_data.GUID}', '{fish_data.Name}', '{fish_data.minSize}', '{fish_data.maxSize}', '{fish_data.baseSellCost}', '{fish_data.prefabPath}', '{fish_data.rarity}', '{fish_data.environment}', '{fish_data.catchingAreaRadius}', '{fish_data.xSpeed}', '{fish_data.ySpeed}', '{fish_data.xOffset}', '{fish_data.yOffset}', '{fish_data.tempVar}', '{fish_data.followBias}', '{fish_data.cohesiveBias}', '{fish_data.seperationBias}', '{fish_data.alignmentBias}');";
            Debug.Log(query);
            db.Execute("INSERT INTO All_Fish  (GUID, Name, minSize, maxSize, baseSellCost, prefabPath, rarity, environment, catchingAreaRadius, xSpeed, ySpeed, xOffset, yOffset, tempVar, followBias, cohesiveBias, seperationBias, alignmentBias) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);",
                fish_data.GUID, fish_data.Name, fish_data.minSize, fish_data.maxSize, fish_data.baseSellCost,
                fish_data.prefabPath, fish_data.rarity, fish_data.environment, fish_data.catchingAreaRadius,
                fish_data.xSpeed, fish_data.ySpeed, fish_data.xOffset, fish_data.yOffset, fish_data.tempVar,
                fish_data.followBias, fish_data.cohesiveBias, fish_data.seperationBias, fish_data.alignmentBias);
            }

    }
    [MenuItem("Tools/get Fish Table")]
    public static void GetFishTable()
    {
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);

        List<Fish_Data> fishData = new List<Fish_Data>();
        fishData = db.Query<Fish_Data>("SELECT * FROM All_Fish;");
        foreach(Fish_Data fish in fishData)
        {
            Debug.Log(fish.Name);
        }
    }
}
