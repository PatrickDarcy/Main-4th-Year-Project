using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum collectables
{
    WOOD,
    STONE,
    MUSHROOM1,
    MUSHROOM2
}

public class InventoryScript : MonoBehaviour
{
    public List<collectables> inventory = new List<collectables>();
    private const int inventorySize = 20;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable" && IsNotInventoryFull())
        {
            if (other.name.StartsWith("Wood"))
            {
                inventory.Add(collectables.WOOD);
                Destroy(other.gameObject);
            }
            else if(other.name.StartsWith("Stone"))
            {
                inventory.Add(collectables.STONE);
                Destroy(other.gameObject);
            }
            else if (other.name.StartsWith("Mushroom1"))
            {
                inventory.Add(collectables.MUSHROOM1);
                Destroy(other.gameObject);
            }
            else if (other.name.StartsWith("Mushroom2"))
            {
                inventory.Add(collectables.MUSHROOM2);
                Destroy(other.gameObject);
            }
        }
    }

    private bool IsNotInventoryFull()
    {
        return inventory.Count < inventorySize;
    }
}
