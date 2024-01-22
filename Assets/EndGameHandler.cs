using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This script handles interactions from the user. primarily quitting the game or starting the game when the level
/// ends. It also populates the values for Score, Time, and collectibles collected.
/// </summary>
public class EndGameHandler : MonoBehaviour
{
    // m_timerText is the timer text
    [SerializeField] private GameObject m_scoreboardTimerText;
    //m_scoreText is the score text
    [SerializeField] private GameObject m_scoreboardScoreText;
    //m_collectibles is an array of game objects that are collectibles. Activated or deactivated based on their counterpart in the level.
    [SerializeField] private GameObject[] m_scoreboardCollectibles;
        
    [SerializeField] private GameObject[] m_collectiblesReference;
    [SerializeField] private GameObject m_TimerTextReference;
    [SerializeField] private GameObject m_scoreTextReference;
    
    
    // Start is called before the first frame update
    void Start()
    { 

    }

    /// <summary>
    /// when triggered by the player colliding with the end game object, populate the score, time, and collectibles collected.
    /// </summary>
    public void PlayerReachedEndOfLevel()
    {
        //set the end game screen to active
        gameObject.SetActive(true);
        Debug.Log("Player has reached the end of the level");
        //stop the timer
        StopCoroutine("UpdateTimer");
        //get the timer text
        string timerText = m_TimerTextReference.GetComponent<UnityEngine.UI.Text>().text;
        Debug.Log("Timer text on scoreboard should be set to: " + timerText);
        //get the score text
        string scoreText = m_scoreTextReference.GetComponent<UnityEngine.UI.Text>().text;
        //get the collectibles reference and set it active
        GetCollectiblesCollected();
        //set the text for the end game screen
        m_scoreboardScoreText.GetComponent<UnityEngine.UI.Text>().text = scoreText;
        m_scoreboardTimerText.GetComponent<UnityEngine.UI.Text>().text = timerText;
        


    }


    /// <summary>
    /// GetCollectiblesCollected() returns the number of collectibles collected by the player and sets the gameobjects active/inactive based on if they were collected.
    /// </summary>
    public void GetCollectiblesCollected()
    {
        //get number of items in the collectibles array
        int collectiblesCount = m_scoreboardCollectibles.Length;
        
        //set the collectibles to active or inactive based on their counterpart in the level
        for (int i = 0; i < collectiblesCount; i++)
        {
            //if the collectible is active in the level, set it active on the scoreboard
            if (m_collectiblesReference[i].activeSelf)
            {
                m_scoreboardCollectibles[i].SetActive(true);
            }
            //if the collectible is inactive in the level, set it inactive on the scoreboard
            else
            {
                m_scoreboardCollectibles[i].SetActive(false);
            }
            
        }
       
    }
    
    /// <summary>
    /// relaod the current level
    /// </summary>
    public void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
    /// <summary>
    /// quit the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
