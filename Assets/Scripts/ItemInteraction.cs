using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    
    // m_playerRigidbody is the player's rigidbody 2d
    [SerializeField] private Rigidbody2D m_playerRigidbody2D;
    
    // m_playerController is the player's controller
    [SerializeField] private GameObject m_playerController;
    
    // m_item is this item object
    [SerializeField] public GameObject m_item;
    
    // Start is called before the first frame update
    // Get the player and the player's controller + the player's RigidBody2D Component.
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    ///if collision occurs with player, notify player that the item is to be added to its inventory (picked up), then destroy the item
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject == m_player)
        {
            Debug.Log("Collision with player detected");
            m_playerController.GetComponent<PlayerController>().AddItem(m_item);
            //m_player.GetComponentInChildren<Inventory>().AddItem(m_item);
            //set item to be inactive
           // m_item.SetActive(false);
            //set item to be a child of the inventory
           // m_item.transform.SetParent(m_player.GetComponentInChildren<Inventory>().transform);
           
           //destroy the item after updating counts.
           Destroy(m_item);
            
        }
    }
}
