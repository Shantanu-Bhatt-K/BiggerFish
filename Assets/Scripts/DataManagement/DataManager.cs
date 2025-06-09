using NUnit.Framework;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{   
    SQLiteConnection streamingDB;
    SQLiteConnection persistentDB;
    static DataManager instance;
    void Awake()
    {
        SQLitePCL.Batteries_V2.Init();
        string dbPath = Path.Combine(Application.dataPath, "StreamingAssets", "game.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
        string pDBPath = Path.Combine(Application.persistentDataPath, "Database", "data.DB");
        var connectionString = new SQLiteConnectionString(pDBPath, storeDateTimeAsTicks: true, key: "super_secure_password");
        streamingDB = new SQLiteConnection(dbPath);
        persistentDB = new SQLiteConnection(connectionString);
        if(instance == null)
        {
            instance = new DataManager();
        }
        else
        {
            Debug.Log("error");
        }
    }

    public List<Fish_Data> GetAllFish()
    {
        List<Fish_Data> allFish  = new List<Fish_Data>(); 
        try
        {
            allFish = streamingDB.Query<Fish_Data>("SELECT * FROM All_Fish;");

        }
        catch(Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
        return allFish;
    }

    public List<Aquarium_Data> GetAllAquarium()
    {
        List<Aquarium_Data> allAquarium = new List<Aquarium_Data>();
        try
        {
            allAquarium = streamingDB.Query<Aquarium_Data>("SELECT * FROM All_Aquarium;");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return allAquarium;
    }

    public List<Decoration_Data> GetAllDecoration()
    {
        List<Decoration_Data> allDecoration = new List<Decoration_Data>();
        try {
            allDecoration = streamingDB.Query<Decoration_Data>("SELECT * FROM All_Decoration");
        }
        catch(Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return allDecoration;
    }
    public List<Bait_Data> GetAllBait()
    {
        List<Bait_Data> allBait = new List<Bait_Data>();
        try
        {

        }
        catch(Exception e) {
            Debug.Log(e); Application.Quit();
        }
        return allBait;
    }
   
    /////////////////////////////////////////////////////////////////////////Player Data/////////////////////////////////////////////////////////////
    


}
