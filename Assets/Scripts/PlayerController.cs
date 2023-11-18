using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //  m_animator is the animator component of the player
    [SerializeField] private Animator m_animator;
    
    // m_speed controls the speed of the character
    [SerializeField] private float m_speed = 3f;
    
    // m_jumpForce controls the force of the jump
    [SerializeField] private float m_jumpForce = 4f;
    
    // m_gravity controls the gravity of the character
    [SerializeField] private float m_gravity = 1f;
    
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    
    // m_playerRigidbody is the player's rigidbody 2d
    private Rigidbody2D m_playerRigidbody2D;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //get player game object
        m_player = GameObject.Find("Player");
        m_playerRigidbody2D = m_player.GetComponent<Rigidbody2D>();
        m_animator = m_player.GetComponent<Animator>();
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
        //Debug.Log("Horizontal Input: " + horizontalInput);
        
        
        // Create a new Vector3 to store the movement
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        
       // m_animator.SetFloat("Speed", Mathf.Abs(movement));
        
        // Move the player based on input
        m_player.transform.position += movement * m_speed * Time.deltaTime;
        
        // If the player presses the jump button, jump
        if (jumpInput)
        {
            //m_playerRigidbody2D.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_playerRigidbody2D.velocity = Vector3.up * m_jumpForce;
            Debug.Log("Jump Input: " + jumpInput);
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
}
