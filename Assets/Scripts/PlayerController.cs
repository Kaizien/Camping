using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // m_speed controls the speed of the character
    [SerializeField] private float m_speed = 5f;
    
    // m_jumpForce controls the force of the jump
    [SerializeField] private float m_jumpForce = 10f;
    
    // m_gravity controls the gravity of the character
    [SerializeField] private float m_gravity = 1f;
    
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    
    // m_playerRigidbody is the player's rigidbody
    private Rigidbody m_playerRigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //get player game object
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // Get the horizontal and jump inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");
        
        
        // Debug the inputs
        Debug.Log("Horizontal Input: " + horizontalInput);
        Debug.Log("Jump Input: " + jumpInput);
        
        // Create a new Vector3 to store the movement
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        
        // Move the player based on input
        m_player.transform.position += movement * m_speed * Time.deltaTime;
        
        // If the player presses the jump button, jump
        if (jumpInput)
        {
            m_playerRigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
    }
}
