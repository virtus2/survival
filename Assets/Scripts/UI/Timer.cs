using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int minute;
    private int seconds;
    public Text timerText;
    StringBuilder sb;
    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0;
        sb = new StringBuilder(4);
    }


    public void TickTimer()
    {
        seconds += 1;
        if(seconds >= 60)
        {
            seconds = 0;
            minute += 1;
        }
        sb = new StringBuilder(4);
        sb.AppendFormat("{0,2}:{1,2}", minute, seconds);
        timerText.text = sb.ToString();
    }

    public void StartTimer()
    {
        InvokeRepeating("TickTimer", 0f, 1f);
    }

    public void StopTimer()
    {
        CancelInvoke("TickTimer");
    }

}
