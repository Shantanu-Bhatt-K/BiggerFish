using UnityEngine;

[CreateAssetMenu(fileName = "Decoration", menuName = "ScriptableObjects/Decoration", order = 1)]
public class Decoration : ScriptableObject
{
    public string GUID;
    [ContextMenu("Generate GUID for ID")]
    private void GenerateGUID()
    {
        GUID = System.Guid.NewGuid().ToString();
    }
    public string Name;
    public GameObject prefabModel;
}

public class Decoration_XData
{
    public string GUID { get; set; }
    public string Name { get; set; }
    public string prefabPath { get; set; }
}