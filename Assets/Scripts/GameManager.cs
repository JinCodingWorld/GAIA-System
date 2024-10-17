using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip buttonClickSound;
    public AudioClip popupWindowSound;
    public AudioClip levelupSound;

    public Text moneyText;
    public Text fatigueText1;
    public Text fatigueText2;
    public Text IntelText;
    public Text AgiText;
    public Text avalPoints;

    private int intelpoint = 0;
    private int agipoint = 0;
    private int points = 0;


    private void Update()
    {
        avalPoints.text = ": " + points;
    }
    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void clickSound()
    {
        audioS.PlayOneShot(buttonClickSound);
    }

    public void popWindowSound()
    {
        audioS.PlayOneShot(popupWindowSound);
    }

    public void levelUpSound()
    {
        audioS.PlayOneShot(levelupSound);
    }

    public void SceneTransition(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void quiteGame()
    {
        Application.Quit();
    }

    public void gainCoins()
    {
        moneyText.text = "200";
    }

    public void fatigueGain()
    {
        fatigueText1.text = "Fatigue: 50%";
        fatigueText2.text = "Fatigue: 50%";
    }

    public void intelPoint()
    {
        if (points <= 0)
            return;
        intelpoint++;
        points--;
        IntelText.text = "INT: " + intelpoint;
    }

    public void agiPoint()
    {
        if (points <= 0)
            return;
        agipoint++;
        points--;
        AgiText.text = "AGI: " + agipoint;
    }

    public void gainAbilityPoint()
    {
        points++;
    }
}
