using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTracker : MonoBehaviour
{
    private float totalDistance = 0f;
    private Vector3 lastPosition;
    private bool isTracking = false;
    public Text totalDis;
    public Text levelText;
    public Text statusLevelText;

    public GameObject nextButton;
    public GameObject levelUp;

    void Start()
    {
        Input.location.Start();
        InvokeRepeating("UpdateLocation", 0f, 1f);
    }

    void UpdateLocation()
    {
        if (Input.location.status == LocationServiceStatus.Running && isTracking)
        {
            Vector3 currentPosition = new Vector3(
                Input.location.lastData.latitude, 0, Input.location.lastData.longitude);

            if (lastPosition != Vector3.zero)
            {
                float distanceThisFrame = Vector3.Distance(lastPosition, currentPosition) * 111139; // Approximate conversion to meters
                totalDistance += distanceThisFrame;
            }

            // Update last position
            lastPosition = currentPosition;

            // Optional: Display total distance
            Debug.Log("Total Distance: " + totalDistance + " meters");
        }
        else
        {
            Debug.Log("Location service not running");
        }
    }

    private void Update()
    {
        // Display total distance in meters
        totalDis.text = "Tracked Distance : " + totalDistance.ToString("F2") + " m"; // Formatting to 2 decimal places
        // 1km가 맞나? 알아봐야 할 소요가 있다.
        if (totalDistance > 1000f)
        {
            nextButton.SetActive(true);
        }
    }

    public void StartTracking()
    {
        isTracking = true;
        lastPosition = Vector3.zero; 
        totalDistance = 0f; 
    }

    public void ResetTracking()
    {
        totalDistance = 0f;
        lastPosition = Vector3.zero;
        isTracking = false; 
        totalDis.text = "Tracked Distance : 0.00 m"; 
    }

    public void PauseTracking()
    {
        isTracking = false; 
    }

    public void ResumeTracking()
    {
        isTracking = true; 
    }

    void OnDestroy()
    {
        Input.location.Stop();
    }

    public void levelUpgrade()
    {
        levelUp.SetActive(true);
        Invoke("deleteLevel", 3f);
        levelText.text = "2";
        statusLevelText.text = "Level: 2";
    }

    void deleteLevel()
    {
        levelUp.SetActive(false);
    }
}
