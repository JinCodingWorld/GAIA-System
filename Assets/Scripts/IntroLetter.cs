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
        introtext.DOText("���̾� �ý����� ���� ���迡�� �÷��̾ ���� �÷��̸� \r\n" +
            "���� �ɷ�ġ�� ���׷��̵� �� �� �ִ� ������ �׸��� �������� �Դϴ�." +
            "\r\n�� �ٸ� ���Ǽ����� ���̾� �ý��ۿ��� ���� ����Ʈ�� �޼����� ���� " +
            "\r\n�������� ������ ������ ������ �� �ֽ��ϴ�." +
            "\r\n���ǰ� ������ ������ ���ο� ���� '���̾� �ý���'���� �� �ٸ� �丣�ҳ��� " +
            "\r\n������ ��ܺ�����. ������ ���� ���� ���� �پ��� ������ �� �� �ֽ��ϴ�. " +
            "\r\n\r\n�׷� ����� �÷��̸� �����մϴ�.", 28).SetEase(Ease.Linear).SetAutoKill(false).Pause();
    }
    public void StartTweens()
    {
        DOTween.PlayAll();
    }
}
