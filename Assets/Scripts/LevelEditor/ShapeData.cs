using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeData : MonoBehaviour
{
    public string m_name;
    public Vector3 m_position;

    private void Start()
    {
        m_position = gameObject.transform.position;
        m_name = gameObject.name;
    }

    private void Update()
    {
        m_position = gameObject.transform.position;
    }
}
