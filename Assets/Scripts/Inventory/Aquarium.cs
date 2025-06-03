using UnityEngine;

[CreateAssetMenu(fileName = "Aquarium", menuName = "ScriptableObjects/Aquarium", order = 1)]
public class Aquarium : ScriptableObject
{
    public string GUID;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        GUID = System.Guid.NewGuid().ToString();
    }
    public string Name;
    public int maxSpace;
    public float width;
    public float height;
    public float depth;
    public GameObject modelPrefab;
    public int maxDecoration;
}

public class Aquarium_Data
{
    public string GUID { get; set; }
    public string Name { get; set; }
    public int maxSpace { get; set; }
    public float width { get; set; }
    public float height { get; set; }
    public float depth { get; set; }
    public string prefabPath { get; set; } // prefab path or Addressable key
    public int maxDecoration { get; set; }
}