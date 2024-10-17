using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObjcectOnClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip danceMusic;
    public static bool isDancing = false;
    public GameObject[] arObject;

    public static int currentIndex = 0;
    private ManoGestureContinuous openGrab;
    private ManoGestureTrigger releaseGrab;


    // GameObject[] childObjects = new GameObject[arObject.transform.childCount];

    private void Awake()
    {
        openGrab = ManoGestureContinuous.OPEN_HAND_GESTURE;
        releaseGrab = ManoGestureTrigger.RELEASE_GESTURE;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ManomotionManager.Instance.ShouldCalculateGestures(true);

        GestureInfo gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;

        ManoGestureTrigger currentGesture = gestureInfo.mano_gesture_trigger;


        // 현재 인식된 제스처 확인
        //if (currentGesture == ManoGestureTrigger.GRAB_GESTURE)
        //{
        //    SpawnObject();
        //}

        //if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == openGrab)
        //{
        //    SpawnObject();
        //}

        if (currentGesture == ManoGestureTrigger.RELEASE_GESTURE)
        {
            SpawnObject();
        }

        if (!isDancing)
        {
            audioSource.Stop();
        }
    }

    private void SpawnObject()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation;

        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x, trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        //Instantiate(arObject, jointPosition, Quaternion.identity);
        Vector3 rotate = new Vector3(0, 180, 0);
        Instantiate(arObject[currentIndex], jointPosition, Quaternion.Euler(rotate));

        isDancing = true;
        audioSource.PlayOneShot(danceMusic);
        Handheld.Vibrate();

        currentIndex++;
    }



}