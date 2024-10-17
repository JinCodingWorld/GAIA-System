using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    [SerializeField] private GameObject handPointer;
    private float skeletonConfience = 0.0001f;


    // Update is called once per frame
    void Update()
    {
        // 손의 추적 정보에서 스켈레톤의 신뢰도가 skeltonConfience보다 큰지 여부 확인
        bool hasConfience = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.confidence > skeletonConfience;

        if (hasConfience)
        {
            var palmCenter = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center;

            var depthEstimation = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation;

            Vector3 positionPointer = ManoUtils.Instance.CalculateNewPositionDepth(palmCenter, depthEstimation);

            handPointer.transform.position = positionPointer;
            handPointer.SetActive(true);
        }

        else
        {
            handPointer.transform.DetachChildren();
            handPointer.SetActive(false);


        }
    }
}
