using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public List<collectables> m_inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        m_inventoryItems = gameObject.GetComponent<InventoryScript>().inventory;
    }

    // Update is called once per frame
    void Update()
    {
        m_inventoryItems = gameObject.GetComponent<InventoryScript>().inventory;
    }
}
