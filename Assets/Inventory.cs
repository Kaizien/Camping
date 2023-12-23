using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    // m_inventory is the player's inventory
    [SerializeField] public List<GameObject> m_inventory;
    
    
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    
    // PLAYER'S TRASH COUNT
    [SerializeField] private int m_trashCount;
    
    //UI ELEMENTS
    [SerializeField] private UIDocument m_uiDocument;
    
    // the progress bar
    [SerializeField] public ProgressBar m_trashCountProgressBar;
   
    
    // Start is called before the first frame update
    void Start()
    {
        m_trashCount = 0;
       //init trassh count progress bar
       m_trashCountProgressBar = m_uiDocument.rootVisualElement.Q<ProgressBar>("TrashCollected");
       
       m_trashCountProgressBar.value = 0;
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
        //m_inventory.Add(item); //not actually doign this anymore. we just need to keep track of the number of trash items collected.
        if(item.GetComponent<ItemDetails>().GetItemType() == "trash")
        {
            m_trashCount++;
            Debug.Log("Trash count is now " + m_trashCount);
            UpdateTrashCount();
            
            
        }
    }

    private void UpdateTrashCount()
    {
        //update the trash count progress bar with the amount of trash collected.
        m_trashCountProgressBar.value = m_trashCount;

    }
    
}
