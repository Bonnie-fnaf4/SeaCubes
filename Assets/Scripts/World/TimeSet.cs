using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSet : MonoBehaviour
{
    public float Timer = 0;
    public bool isStart = false, step1 = false, step2 = false, SlowMode;

    public Text TimerText, TimeScale;
    public PlayerController2 playerController2;
    public float speedOld, FakeTimetimeScale;

    private void Start()
    {
        Time.timeScale = 1;
        FakeTimetimeScale = 1;
        speedOld = playerController2.speedForse;
    }
    void Update()
    {
        //TimerText.text = "" + Timer;
        TimeScale.text = "x" + FakeTimetimeScale.ToString("0.00");

        if (SlowMode || !(FakeTimetimeScale >= 1)) return;

        if(isStart)
        {
            Timer += Time.deltaTime;
        }

        if(Timer >= 20 && !step1 && !(FakeTimetimeScale >= 1.5f))
        {
            step1 = true;
            isStart = false;
            Timer = 0;
        }

        if (step1 && !(FakeTimetimeScale >= 1.5f))
        {
            FakeTimetimeScale += Time.deltaTime / 60;
            playerController2.speedForse = speedOld * FakeTimetimeScale;
        }

        if (FakeTimetimeScale > 1.5f && !step2 && !(FakeTimetimeScale >= 2f))
        {
            isStart = false;
            step1 = false;
            step2 = true;
            //Time.timeScale = 1.5f;
            FakeTimetimeScale = 1.5f;
            Timer = 0;
        }

        if (step2 && !(FakeTimetimeScale >= 2))
        {
            Timer += Time.deltaTime;
        }

        if(step2 && Timer >= 40)
        {
            //Time.timeScale += Time.deltaTime / 120;
            FakeTimetimeScale += Time.deltaTime / 120;
            playerController2.speedForse = speedOld * FakeTimetimeScale;
        }

        if (FakeTimetimeScale >= 2)
        {
            FakeTimetimeScale = 2;
            step2 = false;
            isStart = false;
            step1 = false;
            Timer = 0;
        }
    }

    public void SetTimeToStart()
    {
        //Time.timeScale = 1f;
        FakeTimetimeScale = 1;
        playerController2.speedForse = speedOld * FakeTimetimeScale;
        Timer = 0;
        isStart = true;
        SlowMode = false;

        //Time.timeScale = 1.5f;
        //step1 = true;
        //isStart = false;
        //Timer = 0;
    }

    public void SetTimeToSlow()
    {
        //Time.timeScale = 1;
        FakeTimetimeScale = 1;
        playerController2.speedForse = speedOld * FakeTimetimeScale;
        SlowMode = true;
    }
}
