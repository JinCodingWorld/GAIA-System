using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IntroLetter : MonoBehaviour
{
    public Text introtext;

    private void Start()
    {
        introtext.DOText("가이아 시스템은 현실 세계에서 플레이어가 게임 플레이를 \r\n" +
            "통해 능력치를 업그레이드 할 수 있는 일종의 그림자 가상현실 입니다." +
            "\r\n또 다른 현실세계인 가이아 시스템에서 일일 퀘스트를 달성함을 통해 " +
            "\r\n개개인의 레벨과 보상을 받으실 수 있습니다." +
            "\r\n현실과 가상이 합쳐진 새로운 세계 '가이아 시스템'에서 또 다른 페르소나를 " +
            "\r\n마음껏 즐겨보세요. 레벨이 오를 수록 더욱 다양한 경험을 할 수 있습니다. " +
            "\r\n\r\n그럼 당신의 플레이를 응원합니다.", 28).SetEase(Ease.Linear).SetAutoKill(false).Pause();
    }
    public void StartTweens()
    {
        DOTween.PlayAll();
    }
}
