using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public player score
    [SerializeField] private int m_score = 0;

    
    // m_OnGround is true if the player is on the ground
    [SerializeField] private bool m_OnGround = true;
    
    // m_inventory is the player's inventory
    [SerializeField] private Inventory m_inventory;
    
    //  m_animator is the animator component of the player
    [SerializeField] private Animator m_animator;
    
    // m_speed controls the speed of the character
    [SerializeField] private float m_speed = 3f;
    
    // m_jumpForce controls the force of the jump
    [SerializeField] private float m_jumpForce = 4f;
    
    // m_gravity controls the gravity of the character
    [SerializeField] private float m_gravity = 2f;
    
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    
    // m_playerRigidbody is the player's rigidbody 2d
    private Rigidbody2D m_playerRigidbody2D;
    
    
    private SpriteRenderer m_spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        //get player game object
        m_player = gameObject;
        m_playerRigidbody2D = m_player.GetComponent<Rigidbody2D>();
        m_animator = m_player.GetComponent<Animator>();
        // Initialize the Sprite Renderer reference
        m_spriteRenderer = m_player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerOnGround();
    }


    private void PlayerOnGround()
    {
        //is player on ground?
        m_OnGround = m_playerRigidbody2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        
        // Check if the player is on the ground
        if (m_OnGround)
        {
            // Set the player's gravity to 0
            m_playerRigidbody2D.gravityScale = 0;
        }
        else
        {
            // Set the player's gravity to the default gravity
            m_playerRigidbody2D.gravityScale = m_gravity;
        }
    }


    private void PlayerMovement()
    {
        // Get the horizontal and jump inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");

        // Create a new Vector3 to store the movement
        Vector3 movement = new Vector3(horizontalInput, 0, 0);

        // Move the player based on input
        m_player.transform.position += movement * m_speed * Time.deltaTime;

        // Check if horizontal input is not zero (the player is moving)
        if (horizontalInput > 0)
        {
            // Moving right - unflip the sprite
            m_spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            // Moving left - flip the sprite
            m_spriteRenderer.flipX = false;
        }

        // If the player presses the jump button, jump if currently m_OnGround == true
        if (jumpInput && m_OnGround)
        {
            // Set the player's velocity to the jump force
            m_playerRigidbody2D.velocity = new Vector2(m_playerRigidbody2D.velocity.x, m_jumpForce);
        }
    }



    
    private void OnCollisionEnter(Collision collision)
    {
        // If the player collides with the ground, set the player's rigidbody to the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        }
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
        // Add the item to the player's inventory
        Debug.Log("Player collided with item. Adding item to inventory.");
        m_inventory.AddItem(item);
        
    }
}
