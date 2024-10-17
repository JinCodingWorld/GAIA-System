using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Assign this in the inspector
    public GameObject completeButton;
    public Toggle checkBox;
    private float elapsedTime = 28790f;
    private bool isTiming = false;
    private int hours;
    private int minutes;
    private int seconds;

    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }

        if(hours >= 8)
        {
            StopTimer();
            completeButton.SetActive(true);
            checkBox.isOn = true;
        }
    }

    private void Start()
    {
        //StartTimer();
    }
    public void StartTimer()
    {
        isTiming = true;

    }
    public void ResumeTimer()
    {
        isTiming = true;

    }

    public void StopTimer()
    {
        isTiming = false;
    }

    private void UpdateTimerText()
    {
        // Format elapsed time as hours:minutes
        hours = Mathf.FloorToInt(elapsedTime / 3600);
        minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerText();
    }
}