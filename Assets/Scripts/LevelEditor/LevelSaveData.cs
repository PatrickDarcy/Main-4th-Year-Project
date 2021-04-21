using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public List<SaveShapeData> m_saveShapeDatas = new List<SaveShapeData>();
    public SaveInventoryData m_saveInventoryData = new SaveInventoryData();
}
[System.Serializable]
public class SaveShapeData
{
    public string name;
    public Vector3 objectPosition;
}
[System.Serializable]
public class SaveInventoryData
{
    public List<collectables> itemTypes = new List<collectables>();
}

public class LevelSave
{
    static string s_jsonPath = Application.dataPath + "/Resources/";

    static public void SaveGameplay(ShapeData[] t_shapes, InventoryData t_inventory)
    {
        LevelData levelData = new LevelData();


        foreach(ShapeData shape in t_shapes)
        {
            SaveShapeData shapeData = new SaveShapeData();

            shapeData.name = shape.name;
            shapeData.objectPosition = shape.m_position;

            levelData.m_saveShapeDatas.Add(shapeData);
        }

        SaveInventoryData inventoryData = new SaveInventoryData();
        inventoryData.itemTypes = t_inventory.m_inventoryItems;
        levelData.m_saveInventoryData = inventoryData;

        string jsonData = JsonUtility.ToJson(levelData, true);
        string fullPath = s_jsonPath + "BOB" + ".txt";

        System.IO.File.WriteAllText(fullPath, jsonData);
    }
    static public LevelData loadLevel()
    {
        TextAsset loadFile = Resources.Load<TextAsset>("BOB");
        Debug.Log(loadFile.text);
        if(loadFile != null)
        {
            LevelData loadLevel = JsonUtility.FromJson<LevelData>(loadFile.text);

            return loadLevel;
        }
        return null;
    }
    static public void SaveLevel(ShapeData[] t_shapes)
    {
        float m_numberOfLevel = 0;
        LevelData levelData = new LevelData();

        foreach (ShapeData shape in t_shapes)
        {
            SaveShapeData shapeData = new SaveShapeData();

            shapeData.name = shape.name;
            shapeData.objectPosition = shape.m_position;

            levelData.m_saveShapeDatas.Add(shapeData);
        }

        m_numberOfLevel++;
        string jsonData = JsonUtility.ToJson(levelData, true);
        string fullPath = s_jsonPath + "Level" + m_numberOfLevel + ".txt";

        System.IO.File.WriteAllText(fullPath, jsonData);
    }

}