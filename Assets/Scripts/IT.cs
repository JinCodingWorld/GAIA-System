using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class IT : MonoBehaviour
{
    public ARTrackedImageManager manager;

    private void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    // 그림 인식해야 만 뜸.
    private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage t in eventArgs.added)
        {
            Vector2 posGPS = GetComponent<GPS>().GetGPSInfo();
            //GetComponent<DB>().CreateStoreCharacter(posGPS, t.transform);
            //GetComponent<DB>().confirmLocation(posGPS);
        }
        foreach(ARTrackedImage t in eventArgs.updated)
        {

        }
    }


}