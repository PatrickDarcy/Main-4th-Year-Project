using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Objects
{
    Bush_01,
    Bush_02,
    Grass_01,
    Grass_02,
    Ground_01,
    Ground_02,
    Ground_03,
    Mushroom1,
    Mushroom2,
    Rock_01,
    Rock_03,
    Rock_04,
    Stump_01,
    Tree_01,
    Tree_02,
    Tree_03,
    Wood
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
                    case "Bush_01(Clone)":
                        GameObject Bush_01 = Instantiate<GameObject>(m_shapes[(int)Objects.Bush_01]);
                        Bush_01.transform.position = shape.objectPosition;
                        break;
                    case "Bush_02(Clone)":
                        GameObject Bush_02 = Instantiate<GameObject>(m_shapes[(int)Objects.Bush_02]);
                        Bush_02.transform.position = shape.objectPosition;
                        break;
                    case "Grass_01(Clone)":
                        GameObject Grass_01 = Instantiate<GameObject>(m_shapes[(int)Objects.Grass_01]);
                        Grass_01.transform.position = shape.objectPosition;
                        break;
                    case "Grass_02(Clone)":
                        GameObject Grass_02 = Instantiate<GameObject>(m_shapes[(int)Objects.Grass_02]);
                        Grass_02.transform.position = shape.objectPosition;
                        break;
                    case "Ground_01(Clone)":
                        GameObject Ground_01 = Instantiate<GameObject>(m_shapes[(int)Objects.Ground_01]);
                        Ground_01.transform.position = shape.objectPosition;
                        break;
                    case "Ground_02(Clone)":
                        GameObject Ground_02 = Instantiate<GameObject>(m_shapes[(int)Objects.Ground_02]);
                        Ground_02.transform.position = shape.objectPosition;
                        break;
                    case "Ground_03(Clone)":
                        GameObject Ground_03 = Instantiate<GameObject>(m_shapes[(int)Objects.Ground_03]);
                        Ground_03.transform.position = shape.objectPosition;
                        break;
                    case "Mushroom1(Clone)":
                        GameObject Mushroom1 = Instantiate<GameObject>(m_shapes[(int)Objects.Mushroom1]);
                        Mushroom1.transform.position = shape.objectPosition;
                        break;
                    case "Mushroom2(Clone)":
                        GameObject Mushroom2 = Instantiate<GameObject>(m_shapes[(int)Objects.Mushroom2]);
                        Mushroom2.transform.position = shape.objectPosition;
                        break;
                    case "Rock_01(Clone)":
                        GameObject Rock_01 = Instantiate<GameObject>(m_shapes[(int)Objects.Rock_01]);
                        Rock_01.transform.position = shape.objectPosition;
                        break;
                    case "Rock_03(Clone)":
                        GameObject Rock_03 = Instantiate<GameObject>(m_shapes[(int)Objects.Rock_03]);
                        Rock_03.transform.position = shape.objectPosition;
                        break;
                    case "Rock_04(Clone)":
                        GameObject Rock_04 = Instantiate<GameObject>(m_shapes[(int)Objects.Rock_04]);
                        Rock_04.transform.position = shape.objectPosition;
                        break;
                    case "Stump_01(Clone)":
                        GameObject Stump_01 = Instantiate<GameObject>(m_shapes[(int)Objects.Stump_01]);
                        Stump_01.transform.position = shape.objectPosition;
                        break;
                    case "Tree_01(Clone)":
                        GameObject Tree_01 = Instantiate<GameObject>(m_shapes[(int)Objects.Tree_01]);
                        Tree_01.transform.position = shape.objectPosition;
                        break;
                    case "Tree_02(Clone)":
                        GameObject Tree_02 = Instantiate<GameObject>(m_shapes[(int)Objects.Tree_02]);
                        Tree_02.transform.position = shape.objectPosition;
                        break;
                    case "Tree_03(Clone)":
                        GameObject Tree_03 = Instantiate<GameObject>(m_shapes[(int)Objects.Tree_03]);
                        Tree_03.transform.position = shape.objectPosition;
                        break;
                    case "Wood(Clone)":
                        GameObject Wood = Instantiate<GameObject>(m_shapes[(int)Objects.Wood]);
                        Wood.transform.position = shape.objectPosition;
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
        LevelSave.SaveGameplay(shapes,inventoryData);
    }
}
