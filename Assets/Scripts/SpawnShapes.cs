using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour
{
    public List<GameObject> Shapes;

    public void CreatingObjects(int i)
    {
        Instantiate(Shapes[i], gameObject.transform);
    }
}
