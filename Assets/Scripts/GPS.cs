using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public Text textMsg;

    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();


        // 20ÃÊ µ¿¾È wait
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait < 1)
        {
            textMsg.text = "Time Out";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            textMsg.text = "Location is not Detected";
            yield break;
        }
        else
        {
            while (true)
            {
                textMsg.text = Input.location.lastData.latitude + "¢ªN  " + Input.location.lastData.longitude + "¢ªE";
                    //Input.location.lastData.horizontalAccuracy;

                yield return new WaitForSeconds(1);
            }

            //Input.location.Stop();
        }

    }

    public Vector2 GetGPSInfo()
    {
        Vector2 vPos = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);

        return vPos;
    }

}
