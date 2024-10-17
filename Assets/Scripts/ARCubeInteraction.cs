using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCubeInteraction : MonoBehaviour
{
    private ManoGestureContinuous closeGrab;
    private ManoGestureContinuous openGrab;
    private ManoGestureContinuous pinch;
    private ManoGestureTrigger click;
    private ManoGestureTrigger swipe;
    private ManoGestureContinuous pointer;


    private string handTag = "Player";

    private float skeletonConfidenceThreshold = 0.0001f;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        closeGrab = ManoGestureContinuous.CLOSED_HAND_GESTURE;
        openGrab = ManoGestureContinuous.OPEN_HAND_GESTURE;
        pinch = ManoGestureContinuous.HOLD_GESTURE;
        click = ManoGestureTrigger.CLICK;
        swipe = ManoGestureTrigger.SWIPE_DOWN;
        pointer = ManoGestureContinuous.POINTER_GESTURE;
    }

    private void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        MoveWhenGrab(other);
        RotateWhenHolding(other);
        erasePlayer(other);
    }

    private void MoveWhenGrab(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == closeGrab)
        {
            transform.parent = other.gameObject.transform;
        }

        else
        {
            transform.parent = null;
        }
    }


    private void RotateWhenHolding(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == pinch)
        {
            Handheld.Vibrate();
            transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.World);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == handTag)
        {
            Handheld.Vibrate();

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    gameObject.SetActive(false);
    //    SpawnObjcectOnClick.currentIndex = 0;
    //}

    private void erasePlayer(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == pointer)
        {
            gameObject.SetActive(false);
            SpawnObjcectOnClick.currentIndex = 0;

            SpawnObjcectOnClick.isDancing = false;
        }
    }

}
