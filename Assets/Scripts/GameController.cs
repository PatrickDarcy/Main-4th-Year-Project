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
        }
    }

    private void OnApplicationQuit()
    {
        ShapeData[] shapes = FindObjectsOfType<ShapeData>();
        LevelSave.Save(shapes);
    }
}
