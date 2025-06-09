using Unity.VisualScripting;
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
    public string prefabPath;
    public bool isFloating;

    public Decoration_Data ToDecorationData()
    {
        Decoration_Data dData = new()
        {
            Name = Name,
            prefabPath = prefabPath,
            GUID = GUID,
            isFloating = (isFloating?1 : 0)
        };
        return dData;
    }
}

public class Decoration_Data
{
    public string GUID { get; set; }
    public string Name { get; set; }
    public string prefabPath { get; set; }
    public int isFloating {  get; set; }
    public Decoration ToDecoration()
    {
        Decoration dData = new()
        {
            Name = Name,
            prefabPath = prefabPath,
            GUID = GUID,
            isFloating = (isFloating == 1 ? true : false)
        };
        return dData;
    }
}