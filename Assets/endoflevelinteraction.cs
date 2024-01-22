using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endoflevelinteraction : MonoBehaviour
{
    // m_player is the player object
    [SerializeField] private GameObject m_player;
    // m_Scoreboard is the scoreboard object
    [SerializeField] private GameObject m_Scoreboard;
    
    //reference to a script attached to the scoreboard gameobject
    [SerializeField] private EndGameHandler m_endGameHandler;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Check to see if other object is the player!
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected.");
            m_Scoreboard.SetActive(true);
            m_endGameHandler.PlayerReachedEndOfLevel();
        }
    }
}
