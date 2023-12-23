using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // m_inventory is the player's inventory
    [SerializeField] public List<GameObject> m_inventory;
    
    
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    
    // PLAYER'S TRASH COUNT
    [SerializeField] private int m_trashCount = 0;
    
    
   
    
    // Start is called before the first frame update
    void Start()
    {
       // m_inventory = m_player.GetComponent<Inventory>().m_inventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Add item to player's inventory when player collides with item
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemValue"></param>
    /// <param name="itemName"></param>
    /// <param name="itemDescription"></param>
    /// <param name="itemSprite"></param>
    public void AddItem(GameObject item)
    {
        m_inventory.Add(item);
        if(item.GetComponent<ItemDetails>().GetItemType() == "trash")
        {
            m_trashCount++;
            Debug.Log("Trash count is now " + m_trashCount);
        }
    }
}
