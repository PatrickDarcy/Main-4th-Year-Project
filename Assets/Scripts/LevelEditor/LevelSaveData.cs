using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class LevelData
{
    public List<SaveShapeData> m_saveShapeDatas = new List<SaveShapeData>();
}
[System.Serializable]
public class SaveShapeData
{
    public string name;
    public Vector3 objectPosition;
}

public class LevelSave
{
    static string s_jsonPath = Application.dataPath + "/Resources/";

    static public void Save(ShapeData[] t_shapes)
    {
        LevelData levelData = new LevelData();


        foreach(ShapeData shape in t_shapes)
        {
            SaveShapeData shapeData = new SaveShapeData();

            shapeData.name = shape.name;
            shapeData.objectPosition = shape.m_position;

            levelData.m_saveShapeDatas.Add(shapeData);
        }

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
}