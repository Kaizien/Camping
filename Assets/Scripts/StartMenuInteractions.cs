using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This Script handles interactions from the user. primarily quitting the game or starting the game.
/// </summary>
public class StartMenuInteractions : MonoBehaviour
{
    [SerializeField] private GameObject m_startMenu;

    [SerializeField] private GameObject m_LoadingScreenText;

    [SerializeField] private GameObject m_LoadingScreenCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// When the button is clicked, start the game. pause for 5 seconds between displaying the loading screen and starting the game.
    /// </summary>
    public void StartGame()
    {
        Debug.Log("Starting game");
        m_startMenu.SetActive(false);
        m_LoadingScreenText.SetActive(true);
        m_LoadingScreenCounter.SetActive(true);
        StartCoroutine(PauseGame(10f));

    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    
    /// <summary>
    /// Thuis function pauses the game for a specified number of seconds. also, change the text of the loading screen to show the number of seconds left.
    /// the counter is a ui component of Text(Legacy)
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    IEnumerator PauseGame(float seconds)
    {
        // every second for float seconds, update the text of the counter to show the number of seconds left.
        for (int i = 0; i <= seconds; i++)
        {
            m_LoadingScreenCounter.GetComponent<UnityEngine.UI.Text>().text = ("Starting in " + (seconds - i).ToString() + "...");
            yield return new WaitForSeconds(1f);
            
            //if time is equal to seconds, load the demo scene.
            if (i == seconds)
            {
                SceneManager.LoadScene("Scenes/Demo");
            }
        }
    }

}
