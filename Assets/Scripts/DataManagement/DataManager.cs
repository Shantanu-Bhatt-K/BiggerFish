using NUnit.Framework;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryFish
{
    public int ID { get; set; }
    public string Fish_GUID { get; set; }
    public float size { get; set; }
}

public class InventoryBait
{
    public string Bait_GUID { get; set; }
    public int amount { get; set; }
}
public class InventoryDecoration
{
    public string Decoration_GUID { get; set; }
    public int amount { get; set; }
}
public class InventoryAquarium
{
    public int ID { get; set; }
    public string Aquarium_GUID { get; set; }
    public int currentFish { get; set; }
    public int currentDecoration { get; set; }
}
public class AquariumFish
{
    public int ID { get; set; }
    public string fish_GUID { get; set; }
    public int aquarium_ID { get; set; }
    public float size { get; set; }

}
public class AquariumDecoration
{
    public int ID { get; set; }
    public string decoration_GUID { get; set; }
    public  int aquarium_ID { get; set; }
    public float xPos { get; set; }
    public float yPos { get; set; }
    public float zPos { get; set; }
    public float xRot { get; set; }
    public float yRot { get; set; }
    public float zRot { get; set; }
}

public class PlayerStats
{
    public string name { get; set; }
    public int amount { get; set; }
}

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
   
    /////////////////////////////////////////////////////////////////////////Get Inventory Data/////////////////////////////////////////////////////////////
    
    
    public List<AquariumDecoration> GetAquariumDecoration()
    {
        List<AquariumDecoration> aquariumDecoration = new List<AquariumDecoration>();
        try
        {
            aquariumDecoration = persistentDB.Query<AquariumDecoration>("SELECT * FROM Aquarium_Decoration");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return aquariumDecoration;
    }

    public List<AquariumFish> GetAquariumFish()
    {
        List<AquariumFish> aquariumFish = new List<AquariumFish>();
        try
        {
            aquariumFish = persistentDB.Query<AquariumFish>("SELECT * FROM Aquarium_Fish");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return aquariumFish;
    }

    public List<InventoryAquarium> GetInventoryAquarium()
    {
        List<InventoryAquarium> inventoryAquarium = new List<InventoryAquarium>();
        try
        {
            inventoryAquarium = persistentDB.Query<InventoryAquarium>("SELECT * FROM Inventory_Aquarium");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return inventoryAquarium;
    }
    public List<Fish_Data> GetInventoryFish()
    {
        List<Fish_Data> inventoryFish = new List<Fish_Data>();
        try
        {
            inventoryFish = persistentDB.Query<Fish_Data>("SELECT * FROM Inventory_Fish");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return inventoryFish;
    }
    public List<InventoryBait> GetInventoryBait()
    {
        List<InventoryBait> inventoryBait = new List<InventoryBait>();
        try
        {
            inventoryBait = persistentDB.Query<InventoryBait>("SELECT * FROM Inventory_Bait");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return inventoryBait;
    }
    public List<InventoryDecoration> GetInventoryDecoration()
    {
        List<InventoryDecoration> inventoryDecoration = new List<InventoryDecoration>();
        try
        {
            inventoryDecoration = persistentDB.Query<InventoryDecoration>("SELECT * FROM Inventory_Bait");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return inventoryDecoration;
    }

    public List<PlayerStats> GetPlayerStats()
    {
        List<PlayerStats> playerStats = new List<PlayerStats>();
        try
        {
            playerStats = persistentDB.Query<PlayerStats>("SELECT * FROM Inventory_Bait");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
        return playerStats;
    }

    /////////////////////Aquarium Fish Data Update////////////////////////////////////////////////////////
    public void InsertAquariumFish(string fish_GUID, int aquariumID, float size)
    {
        try
        {
            persistentDB.Execute(
                "INSERT INTO Aquarium_Fish(fish_GUID, aquarium_ID, size) VALUES (?, ?, ?);",
                fish_GUID, aquariumID, size
            );
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Application.Quit();
        }
    }
    public void RemoveAquariumFish(AquariumFish fish)
    {
        try
        {
            persistentDB.Execute("DELETE FROM Aquarium_Fish WHERE ID = ?;", fish.ID);
            Debug.Log("Removed Fish from Aquarium");
        }
        catch(Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
    }

    //////////////////////////////////////////// Aquarium Decoration Data Update////////////////////////////////////////////
    public void InsertAquariumDecoration(string decorationGUID, int aquariumID, Vector3 position, Vector3 rotation)
    {
        try
        {
            persistentDB.Execute(
                "INSERT INTO Aquarium_Decoration(decoration_GUID, aquarium_ID, xPos, yPos, zPos, xRot, yRot, zRot) VALUES (?, ?, ?, ?, ?, ?, ?, ?);",
               decorationGUID, aquariumID, position.x, position.y, position.z, rotation.x, rotation.y, rotation.z
            );
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Application.Quit();
        }
    }


    public void RemoveAquariumDecoration(AquariumDecoration decoration)
    {
        try
        {
            persistentDB.Execute("DELETE FROM Aquarium_Decoration WHERE ID = ?;", decoration.ID);
            Debug.Log("Removed Decoration from Aquarium");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
    }
    //////////////// Inventory Fish Data Update////////////////////////////////////////////////////////
    public void AddInventoryFish(string fishGUID, float size)
    {
        try
        {
            persistentDB.Execute(
                "INSERT INTO Inventory_Fish(fish_GUID, size) VALUES (?, ?);",
                fishGUID, size
            );
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Application.Quit();
        }
    }

    public void RemoveInventoryFish(InventoryFish fish)
    {
        try
        {
            persistentDB.Execute("DELETE FROM Inventory_Fish WHERE ID = ?;", fish.ID);
            Debug.Log("Removed Fish from Inventory");
        }
        catch (Exception e)
        {
            Debug.Log(e); Application.Quit();
        }
    }

    //////////////////////////////////Inventory Aquarium Data Update//////////////////////////////////////
    public void AddInventoryAquarium(string Aquarium_GUID)
    {
        try
        {
            persistentDB.Execute(
                "INSERT INTO Inventory_Aquarium(Aquarium_GUID, currentFish, currentDecoration) VALUES (?, ?, ?);",
                Aquarium_GUID, 0, 0
            );
           
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Application.Quit();
        }
    }

    public void RemoveInventoryAquarium(InventoryAquarium aquarium)
    {
        try
        {
            // 1️⃣ Get the fish before deleting anything
            List<AquariumFish> aquariumFishes = GetAquariumFish(aquarium.ID);
            List<AquariumDecoration> aquariumDecorations = GetAquariumDecorations(aquarium.ID);

            // 2️⃣ Begin a transaction
            persistentDB.RunInTransaction(() =>
            {
                // 3️⃣ Delete aquarium and its fish
                persistentDB.Execute("DELETE FROM Inventory_Aquarium WHERE ID = ?;", aquarium.ID);
                persistentDB.Execute("DELETE FROM Aquarium_Fish WHERE Aquarium_ID = ?;", aquarium.ID);
                persistentDB.Execute("DELETE FROM Aquarium_Decoration WHERE Aquarium_ID = ?;", aquarium.ID);

                Debug.Log($"Removed Aquarium and its fish and decoration for aquarium ID = {aquarium.ID}");

                // 4️⃣ Move fish to inventory
                foreach (AquariumFish aquariumFish in aquariumFishes)
                {
                    persistentDB.Execute(
                        "INSERT INTO Inventory_Fish (fish_GUID, size) VALUES (?, ?);",
                        aquariumFish.fish_GUID, aquariumFish.size
                    );

                }
                foreach (AquariumDecoration aquariumDecoration in aquariumDecorations)
                {
                    int rowsAffected = persistentDB.Execute(
                        "UPDATE Inventory_Decoration SET amount = amount + 1 WHERE decoration_GUID = ?;",
                        aquariumDecoration.decoration_GUID
                    );

                    if (rowsAffected == 0)
                    {
                        persistentDB.Execute(
                            "INSERT INTO Inventory_Decoration (decoration_GUID, amount) VALUES (?, 1);",
                            aquariumDecoration.decoration_GUID
                        );
                    }
                }
            });

            Debug.Log("Successfully moved fish back to inventory");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error removing aquarium: {e}");
            Application.Quit();
        }
    }
    ////////////////////////////////////////////// Player Stats Update ////////////////////////////////////////////////////////////
    
    public void   AddPlayerStats(string Item, int amount)
    {
        try
        {
            int rowsAffected = persistentDB.Execute("UPDATE Player_Stats SET value = value + ? WHERE name = ?;", amount, Item);
            if (rowsAffected == 0)
            {
                persistentDB.Execute("INSERT INTO Player_Stats(name, value) VALUES (?, ?);", Item, amount);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
    }

    public void RemovePlayerStats(string Item, int amount)
    {
        try
        {
            persistentDB.RunInTransaction(() =>
            {
                persistentDB.Execute("UPDATE Player_Stats SET value = value - ? WHERE name = ?", amount, Item);
                persistentDB.Execute("UPDATE Player_Stats SET value = 0 WHERE value <= 0;");
            });
        }
        catch(Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
    }
    ////////////////////////////////////////////// Inventory Bait Data Update /////////////////////////////////////////////////////
    public void AddInventoryBait(string GUID, int amount)
    {
        try
        {
            int rowsAffected = persistentDB.Execute("UPDATE Inventory_Bait SET amount = amount + ? WHERE bait_GUID = ?;", amount, GUID);
            if (rowsAffected == 0)
            {
                persistentDB.Execute("INSERT INTO Inventory_Bait(bait_GUID, amount) VALUES (?, ?);", GUID, amount);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
    }

    public void RemoveInventoryBait(string GUID, int amount)
    {
        try
        {
            persistentDB.RunInTransaction(() =>
            {
                persistentDB.Execute("UPDATE Inventory_Bait SET amount = amount - ? WHERE bait_GUID = ?", amount, GUID);
                persistentDB.Execute("DELETE FROM Inventory_Bait WHERE amount <= 0;");
            });
            
        }
        catch( Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
    }

    //////////////////////////////////////////// Inventory Decoration Data Update //////////////////////////////////////////////////
    public void AddInventoryDecoration(string GUID, int amount )
    {
        try
        {
            int rowsAffected = persistentDB.Execute("UPDATE Inventory_Decoration SET amount = amount + ? WHERE decoration_GUID = ?;", amount, GUID);
            if (rowsAffected == 0)
            {
                persistentDB.Execute("INSERT INTO Inventory_Decoration(decoration_GUID, amount) VALUES (?, ?);", GUID, amount);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
    }

    public void RemoveInventoryDecoration(string GUID, int amount)
    {
        try
        {
            persistentDB.RunInTransaction(() =>
            {
                persistentDB.Execute("UPDATE Inventory_Decoration SET amount = amount - ? WHERE decoration_GUID = ?", amount, GUID);
                persistentDB.Execute("DELETE FROM Inventory_Decoration WHERE amount <= 0;");
            });

        }
        catch (Exception e)
        {
            Debug.Log(e);
            Application.Quit();
        }
    }
    ////////////////////////////////////////////// Get Aquarium Data ///////////////////////////////////////////////////////////////
    public List<AquariumFish> GetAquariumFish(int aquariumID)
    {
        try
        {
            List<AquariumFish> aquariumFish = persistentDB.Query<AquariumFish>("SELECT * FROM Aquarium_Fish WHERE Aquarium_ID = ?", aquariumID);
            Debug.Log($"Fetched Fishes for aquarium = {aquariumID}");
            return aquariumFish;
        }
        catch(Exception e)
        {
            Debug.LogError(e);
            Application.Quit();
            return null;
        }
    }
    public List<AquariumDecoration> GetAquariumDecorations(int aquariumID)
    {
        try
        {
            List<AquariumDecoration> aquariumDecoration = persistentDB.Query<AquariumDecoration>("SELECT * FROM Aquarium_Decoration WHERE Aquarium_ID = ?", aquariumID);
            Debug.Log($"Fetched Fishes for aquarium = {aquariumID}");
            return aquariumDecoration;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Application.Quit();
            return null;
        }
    }
}



