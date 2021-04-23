using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private const int inventorySize = 32;
    public List<Button> m_inventoryTabs;
    public List<Sprite> m_itemImages;
    private int m_currentTab = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable" && IsNotInventoryFull())
        {
            if (other.name.StartsWith("Wood"))
            {
                inventory.Add(collectables.WOOD);
                m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.WOOD];
                m_currentTab++;
                Destroy(other.gameObject);
            }
            else if(other.name.StartsWith("Stone"))
            {
                inventory.Add(collectables.STONE);
                m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.STONE];
                m_currentTab++;
                Destroy(other.gameObject);
            }
            else if (other.name.StartsWith("Mushroom1"))
            {
                inventory.Add(collectables.MUSHROOM1);
                m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.MUSHROOM1];
                m_currentTab++;
                Destroy(other.gameObject);
            }
            else if (other.name.StartsWith("Mushroom2"))
            {
                inventory.Add(collectables.MUSHROOM2);
                m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.MUSHROOM2];
                m_currentTab++;
                Destroy(other.gameObject);
            }
        }
    }

    public void SetupSavedInventory(LevelData t_levelData)
    {
        foreach(collectables t_inventoryData in t_levelData.m_saveInventoryData.itemTypes)
        {
            switch(t_inventoryData)
            {
                case collectables.WOOD:
                    m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.WOOD];
                    m_currentTab++;
                    break;
                case collectables.STONE:
                    m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.STONE];
                    m_currentTab++;
                    break;
                case collectables.MUSHROOM1:
                    m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.MUSHROOM1];
                    m_currentTab++;
                    break;
                case collectables.MUSHROOM2:
                    m_inventoryTabs[m_currentTab].image.sprite = m_itemImages[(int)collectables.MUSHROOM2];
                    m_currentTab++;
                    break;
                default:
                    break;
            }
        }
    }
    private bool IsNotInventoryFull()
    {
        return inventory.Count < inventorySize;
    }

    public void spawnInventoryItem(GameObject gameObject)
    {
        if(gameObject != null)
        Instantiate<GameObject>(gameObject);
    }
}
