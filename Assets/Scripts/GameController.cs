using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void OnApplicationQuit()
    {
        ShapeData[] shapes = FindObjectsOfType<ShapeData>();
        LevelSave.Save(shapes);
    }
}
