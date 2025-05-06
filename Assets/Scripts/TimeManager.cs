using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public GameObject lightObject;
    public TextMeshProUGUI text;
    float time, localTime;
    float secondsChange = 0;
    bool isRealTime = true;

    void Start()
    {
        time = System.DateTime.Now.Hour * 3600 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second;
        print(time + isRealTime.ToString());
        print((int)(time / 3600) + ":" + (int)((time - (int)(time / 3600) * 3600) / 60));
    }

    void Update()
    {
        secondsChange += Time.deltaTime;

        if (secondsChange >= 1)
        {
            secondsChange--;
            time++;
            localTime++;

            if (time >= 86400) time -= 86400;
        }
        if (localTime >= 86400) localTime -= 86400;
        else if (localTime < 0) localTime += 86400;

        if (isRealTime)
        {
            lightObject.transform.rotation = Quaternion.Euler(time * 0.00416f - 90, 0, 0);
            text.text = (int)(time / 3600) + ":" + (int)((time - (int)(time / 3600) * 3600) / 60);
        }
        else
        {
            lightObject.transform.rotation = Quaternion.Euler(localTime * 0.00416f - 90, 0, 0);
            text.text = (int)(localTime / 3600) + ":" + (int)((localTime - (int)(localTime / 3600) * 3600) / 60);
        }
    }

    public void SwitchTimeMode()
    {
        if (isRealTime) isRealTime = false;
        else isRealTime = true;
    }

    public void AddHour()
    {
        if (!isRealTime) localTime += 3600;
    }

    public void SubtractHour()
    {
        if (!isRealTime) localTime -= 3600;
    }
}
