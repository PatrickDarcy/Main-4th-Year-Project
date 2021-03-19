using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Shapes
{
   Circle,
   Rectangle1,
   Rectangle2,
   Cube,
   Cylinder
}

public class GameController : MonoBehaviour
{
    public List<GameObject> m_shapes;
    public GameObject m_playerBackPack;

    // Start is called before the first frame update
    void Awake()
    {
        LevelData levelData = LevelSave.loadLevel();
        if (levelData != null)
        {
            foreach (SaveShapeData shape in levelData.m_saveShapeDatas)
            {
                switch (shape.name)
                {
                    case "Cube(Clone)":
                        GameObject cube = Instantiate<GameObject>(m_shapes[(int)Shapes.Cube]);
                        cube.transform.position = shape.objectPosition;
                        break;
                    case "Circle(Clone)":
                        GameObject circle = Instantiate<GameObject>(m_shapes[(int)Shapes.Circle]);
                        circle.transform.position = shape.objectPosition;
                        break;
                    case "Rectangle1(Clone)":
                        GameObject rec1 = Instantiate<GameObject>(m_shapes[(int)Shapes.Rectangle1]);
                        rec1.transform.position = shape.objectPosition;
                        break;
                    case "Rectangle2(Clone)":
                        GameObject rec2 = Instantiate<GameObject>(m_shapes[(int)Shapes.Rectangle2]);
                        rec2.transform.position = shape.objectPosition;
                        break;
                    case "Cylinder(Clone)":
                        GameObject cylinder = Instantiate<GameObject>(m_shapes[(int)Shapes.Cylinder]);
                        cylinder.transform.position = shape.objectPosition;
                        break;
                    default:
                        break;
                }
            }
            foreach(collectables inventoryData in levelData.m_saveInventoryData.itemTypes)
            {
                switch(inventoryData)
                {
                    case collectables.WOOD:
                        m_playerBackPack.GetComponent<InventoryScript>().inventory.Add(collectables.WOOD);
                        break;
                    case collectables.STONE:
                        m_playerBackPack.GetComponent<InventoryScript>().inventory.Add(collectables.STONE);
                        break;
                    case collectables.MUSHROOM1:
                        m_playerBackPack.GetComponent<InventoryScript>().inventory.Add(collectables.MUSHROOM1);
                        break;
                    case collectables.MUSHROOM2:
                        m_playerBackPack.GetComponent<InventoryScript>().inventory.Add(collectables.MUSHROOM2);
                        break;
                    default:
                        break;
                }
            }

        }
    }

    private void OnApplicationQuit()
    {
        ShapeData[] shapes = FindObjectsOfType<ShapeData>();
        InventoryData inventoryData = FindObjectOfType<InventoryData>();
        LevelSave.Save(shapes,inventoryData);
    }
}
