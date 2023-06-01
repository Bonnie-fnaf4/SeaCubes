using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GraundController[] graundControllers;
    public GameObject MenuPanel, PausePanel, btnContinue;

    public TimeSet timeSet;

    public float TimeSave;
    public void StartGame()
    {
        for(int i = 0; i < graundControllers.Length; i++)
        {
            graundControllers[i].end = false;
        }

        timeSet.SetTimeToStart();
        MenuPanel.SetActive(false);
    }

    public void StartGameToSlow()
    {
        for (int i = 0; i < graundControllers.Length; i++)
        {
            graundControllers[i].end = false;
        }

        timeSet.SetTimeToSlow();
        MenuPanel.SetActive(false);
    }

    public void Pause()
    {
        if(Time.timeScale >= 1) TimeSave = Time.timeScale;
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = TimeSave;
        PausePanel.SetActive(false);
    }

    public void Dead()
    {
        TimeSave = Time.timeScale;
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        btnContinue.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = TimeSave;
        for (int i = 0; i < graundControllers.Length; i++)
        {
            graundControllers[i].end = true;
        }
        PausePanel.SetActive(false);
        MenuPanel.SetActive(true);

        //Application.LoadLevel(0);
    }
}
