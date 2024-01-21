using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameObject m_timerText;

    public int secondsCount;
    
    // Start is called before the first frame update
    void Start()
    {
        secondsCount = 0;
        StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    IEnumerator UpdateTimer()
    {
        
        while (true) // Infinite loop, you can add a condition to break it if needed
        {
            secondsCount++;
            string timerText = FormatTime(secondsCount);
            // Update your UI or text element here with timerText
            // For example: yourTextElement.text = timerText;
            m_timerText.GetComponent<UnityEngine.UI.Text>().text = "Time: " + timerText;
            yield return new WaitForSeconds(1f); // Wait for one second
        }
    }

    string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
