using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetails : MonoBehaviour
{
    // m_itemType is the type of item
    [SerializeField] private string m_itemType;
    
    // m_itemValue is the value of the item
    [SerializeField] private int m_itemValue;
    
    // m_itemName is the name of the item
    [SerializeField] private string m_itemName;
    
    // m_itemDescription is the description of the item
    [SerializeField] private string m_itemDescription;
    



    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemDetails GetItemInformation(GameObject item)
    {
        ItemDetails itemDetails = item.GetComponent<ItemDetails>();
        itemDetails.m_itemType = GetItemType();
        itemDetails.m_itemName = GetItemName();
        itemDetails.m_itemDescription = GetItemDescription();
        itemDetails.m_itemValue = GetItemValue();
        return (itemDetails);
    }
    
    /// <summary>
    /// Get the item's type and return it
    /// </summary>
    /// <returns></returns>
    public string GetItemType()
    {
        Debug.Log("This item's type is " + m_itemType);
        return (m_itemType);
    }
    
    private string GetItemName()
    {
        Debug.Log("This item's name is " + m_itemName);
        return (m_itemName);
    }
    
    private string GetItemDescription()
    {
        Debug.Log("This item's description is " + m_itemDescription);
        return (m_itemDescription);
    }

    private int GetItemValue()
    {
        Debug.Log("This item's value is " + m_itemValue);
        return (m_itemValue);
    }
    
    public void SetItemType(string itemType)
    {
        m_itemType = itemType;
    }
    
    public void SetItemName(string itemName)
    {
        m_itemName = itemName;
    }
    
    public void SetItemDescription(string itemDescription)
    {
        m_itemDescription = itemDescription;
    }
    
    public void SetItemValue(int itemValue)
    {
        m_itemValue = itemValue;
    }
    

}
