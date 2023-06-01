using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            audioSource.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale < 1)
        {
            audioSource.pitch = 0.5f;
            audioSource.volume = 0.5f;
        }
        else
        {
            audioSource.pitch = 1;
            audioSource.volume = 1;
        }
    }

    public void StopMusic()
    {
        if (audioSource.enabled == false)
        {
            audioSource.enabled = true;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            audioSource.enabled = false;
            PlayerPrefs.SetInt("Music", 1);
        }
    }
}
