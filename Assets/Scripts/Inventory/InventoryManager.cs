using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using SQLite;




public class InventoryManager 
{
    public Dictionary<string, int> inventoryFish = new Dictionary<string, int>();
    public Dictionary<string, int> inventoryDecoration = new Dictionary<string , int>();
    public Dictionary<string, int> inventoryBait = new Dictionary<string, int>();
    public int money = 0;
    public Dictionary<string, Aquarium> inventoryAquarium = new Dictionary<string, Aquarium>();
    public Dictionary<string, Dictionary<string, int>> AquariumFish = new Dictionary<string, Dictionary<string, int>>();
    public InventoryManager()
    {

    }

   
}
