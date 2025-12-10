using UnityEditor;
using UnityEngine;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System;
using Codice.CM.Common;

public static class DatabaseCreator
{

    [MenuItem("Tools/Clear Database")]
    public static void ClearDatabase()
    {
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        if (File.Exists(dbPath))
        {
            var db = new SQLiteConnection(dbPath);
            db.Execute("DROP TABLE IF EXISTS All_Fish;");
            db.Execute("DROP TABLE IF EXISTS All_Aquarium;");
            db.Execute("DROP TABLE IF EXISTS All_Bait;");
            db.Execute("DROP TABLE IF EXISTS All_Decorations;");
            Debug.Log("Dropped all tables in the database at: " + dbPath);
        }
        else
        {
            Debug.Log("No existing database found at: " + dbPath);
        }
    }
    [MenuItem("Tools/Generate Game Tables")]
    public static void CreateDatabasetable()
    {
        
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);
        db.Execute("CREATE TABLE IF NOT EXISTS All_Fish (GUID TEXT PRIMARY KEY, Name TEXT, minSize REAL, maxSize REAL, baseSellCost INTEGER, prefabPath TEXT, rarity INTEGER, environment INTEGER, catchingAreaRadius REAL, xSpeed REAL, ySpeed REAL, xOffset REAL, yOffset REAL, spaceRequired INTEGER, followBias REAL, cohesiveBias REAL, seperationBias REAL, alignmentBias REAL, maxSpeed REAL);");
        db.Execute("CREATE TABLE IF NOT EXISTS All_Aquarium (GUID TEXT PRIMARY KEY, Name TEXT, maxSpace INTEGER, width REAL, height REAL, depth REAL, prefabPath TEXT, maxDecoration INTEGER,  cost INTEGER);");
        db.Execute("CREATE TABLE IF NOT EXISTS All_Bait (GUID TEXT PRIMARY KEY, Name TEXT, modifierType INT, modifiedRarity INTEGER, sizeModifier REAL,rarityModifier REAL, bestEnvironment INTEGER, easeModifier REAL, prefabPath TEXT, cost INTEGER);");
        db.Execute("CREATE TABLE IF NOT EXISTS All_Decorations (GUID TEXT PRIMARY KEY, Name TEXT, prefabPath TEXT, isFloating INTEGER);");

        Debug.Log("Created Tables");
    }

    [MenuItem("Tools/Fill Bait Table")]
    public static void FillBaitTable()
    {
        List<Bait> allBait = new List<Bait>();
        string[] bGuids = AssetDatabase.FindAssets("t:Bait");
        foreach (string bGuid in bGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(bGuid);
            Bait baitAsset = AssetDatabase.LoadAssetAtPath<Bait>(path);
            if (baitAsset != null)
            {
                allBait.Add(baitAsset);
            }
        }

        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);

        foreach (Bait bait in allBait)
        {
            Bait_Data baitData = bait.ToBaitData();
            db.Execute("INSERT INTO All_Bait (GUID, Name, modifierType, modifiedRarity, sizeModifier, easeModifier, prefabPath, cost, bestEnvironment, rarityModifier) VALUES(?, ?, ?, ?, ?, ?, ?, ?,?,?);",
                baitData.GUID, baitData.Name, baitData.modifierType, baitData.modifiedRarity, baitData.sizeModifier, baitData.easeModifier, baitData.prefabPath, baitData.cost, baitData.bestEnvironment, baitData.rarityModifier);
        }
        Debug.Log("Filled Bait Table");
    }

    [MenuItem("Tools/Fill Fish Table")]
    public static void FillFishTable()
    {
        List<Fish> allFish = new List<Fish>();
        
        string[] fGuids = AssetDatabase.FindAssets("t:Fish");
       

        foreach (string guid in fGuids)
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
            Fish_Data fish_data = fish.ToFishData();
            string query = $"INSERT INTO All_Fish (GUID, Name, minSize, maxSize, baseSellCost, prefabPath, rarity, environment, catchingAreaRadius, xSpeed, ySpeed, xOffset, yOffset, tempVar, followBias, cohesiveBias, seperationBias, alignmentBias) VALUES ('{fish_data.GUID}', '{fish_data.Name}', '{fish_data.minSize}', '{fish_data.maxSize}', '{fish_data.baseSellCost}', '{fish_data.prefabPath}', '{fish_data.rarity}', '{fish_data.environment}', '{fish_data.catchingAreaRadius}', '{fish_data.xSpeed}', '{fish_data.ySpeed}', '{fish_data.xOffset}', '{fish_data.yOffset}', '{fish_data.spaceRequired}', '{fish_data.followBias}', '{fish_data.cohesiveBias}', '{fish_data.seperationBias}', '{fish_data.alignmentBias}');";
            Debug.Log(query);
            db.Execute("INSERT INTO All_Fish  (GUID, Name, minSize, maxSize, baseSellCost, prefabPath, rarity, environment, catchingAreaRadius, xSpeed, ySpeed, xOffset, yOffset, spaceRequired, followBias, cohesiveBias, seperationBias, alignmentBias, maxSpeed) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);",
                fish_data.GUID, fish_data.Name, fish_data.minSize, fish_data.maxSize, fish_data.baseSellCost,
                fish_data.prefabPath, fish_data.rarity, fish_data.environment, fish_data.catchingAreaRadius,
                fish_data.xSpeed, fish_data.ySpeed, fish_data.xOffset, fish_data.yOffset, fish_data.spaceRequired,
                fish_data.followBias, fish_data.cohesiveBias, fish_data.seperationBias, fish_data.alignmentBias, fish_data.maxSpeed);
        }
        Debug.Log("Filled Fish Table");
    }

    [MenuItem("Tools/Fill DecorationTable")]
    public static void FillDecorationTable()
    {
        List<Decoration> allDecorations = new List<Decoration>();
        string[] dGuids = AssetDatabase.FindAssets("t:Decoration"); 
        foreach (string dguid in dGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(dguid);
            Decoration decorationAsset = AssetDatabase.LoadAssetAtPath<Decoration>(path);
            if (decorationAsset != null)
            {
                allDecorations.Add(decorationAsset);
            }
        }
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);
        foreach (Decoration decoration in allDecorations)
        {
            Decoration_Data dData = decoration.ToDecorationData();
            db.Execute("INSERT INTO All_Decorations(GUID, Name, prefabPath, isFloating)VALUES(?,?,?,?)", dData.GUID, dData.Name, dData.prefabPath, dData.isFloating);

        }
        Debug.Log("Filled Decoration Table");
    }
    [MenuItem("Tools/Get Fish Table")]
    public static void GetFishTable()
    {
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);

        List<Fish_Data> fishData = new List<Fish_Data>();
        fishData = db.Query<Fish_Data>("SELECT * FROM All_Fish;");
        foreach (Fish_Data fish in fishData)
        {
            Debug.Log(fish.Name);
        }
        Debug.Log("Fetched Fish Table");
    }

    [MenuItem("Tools/ Fill Aquarium Table")]
    public static void FillAquarium() {
        List<Aquarium> allAquarium = new List<Aquarium>();
        string[] aGuids = AssetDatabase.FindAssets("t:Aquarium");
        foreach (string aguid in aGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(aguid);
            Aquarium decorationAsset = AssetDatabase.LoadAssetAtPath<Aquarium>(path);
            if (decorationAsset != null)
            {
                allAquarium.Add(decorationAsset);
            }
        }
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        var db = new SQLiteConnection(dbPath);
        foreach (Aquarium aquarium in allAquarium)
        {
            Aquarium_Data aData = aquarium.ToAquariumData();
            db.Execute("INSERT INTO All_Aquarium(GUID, Name, maxSpace, width, height, depth, prefabPath, maxDecoration)VALUES(?,?,?,?,?,?,?,?)", aData.GUID, aData.Name, aData.maxSpace, aData.width, aData.height, aData.depth, aData.prefabPath, aData.maxDecoration);

        }

        Debug.Log("Filled Aquarium Table");
    }


    /////////////////////////////////////////////// Create player Inventory Tables ////////////////////////////////////////////

    

    [MenuItem("Tools/Create Player Inventory Table")]
    public static void  CreatePlayerTables()
    {
        SQLitePCL.Batteries_V2.Init();
        string pDBPath = Path.Combine(Application.persistentDataPath, "Database", "data.DB");
        Debug.Log(pDBPath);
        Directory.CreateDirectory(Path.GetDirectoryName(pDBPath));
        var connectionString = new SQLiteConnectionString(pDBPath, storeDateTimeAsTicks: true, key: "super_secure_password");
        var persistentDB = new SQLiteConnection(connectionString);
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Inventory_Fish(ID INTEGER PRIMARY KEY AUTOINCREMENT, fish_GUID TEXT, size REAL);");
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Inventory_Bait(bait_GUID TEXT PRIMARY KEY , amount INTEGER);");
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Inventory_Decoration(decoration_GUID TEXT PRIMARY KEY, amount INTEGER );");
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Inventory_Aquarium(ID INTEGER PRIMARY KEY AUTOINCREMENT, aquarium_GUID TEXT, currentFish INTEGER, currentDecoration INTEGER);");
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Aquarium_Fish(ID INTEGER PRIMARY KEY AUTOINCREMENT, fish_GUID TEXT, aquarium_ID INT, size REAL);");
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Aquarium_Decoration(ID INTEGER PRIMARY KEY AUTOINCREMENT, decoration_GUID TEXT, aquarium_ID INT, xPos REAL, yPos REAL, zPos REAL, xRot REAL, yRot REAL, zRot REAL);");
        persistentDB.Execute("CREATE TABLE IF NOT EXISTS Player_Stats(name TEXT PRIMARY KEY, value INTEGER);");
    }
}


