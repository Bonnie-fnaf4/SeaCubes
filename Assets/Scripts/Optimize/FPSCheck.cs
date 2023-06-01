using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCheck : MonoBehaviour
{
    public float fps;
    public Text fpsText;
    public float Timer = 0, Timer2 = 0, Timer3 = 0;
    public GameObject[] Sea;
    public bool isDeleteSea = false, is20FPS = true;

    public PlayerController2 playerController2;
    public GraundController[] graundControllers;

    public Color Green, Red;

    public Image Off20FPS, OffOptimize;

    public GameObject Setting;

    private void Update()
    {
        if (Timer2 >= 45) return;
        Timer += Time.deltaTime;

        if (Timer > 0.2)
        {
            fps = 1 / Time.deltaTime;
            fpsText.text = fps.ToString("000.00");
            Timer = 0;
            Timer2++;

            if(fps <= 20 && !isDeleteSea)
            {
                Timer3++;

                if(Timer3 > 10 && is20FPS)
                {
                    //OffOptimize.color = Green;
                    isDeleteSea = true;
                    playerController2.isOptimize = true;

                    PlayerPrefs.SetInt("FPSCheck2", 1);

                    for (int i = 0; i < graundControllers.Length; i++)
                    {
                        graundControllers[i].isOptimize = true;
                    }
                    for (int i = 0; i < Sea.Length; i++)
                    {
                        Destroy(Sea[i]);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Application.targetFrameRate = 15;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Application.targetFrameRate = 1000;
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("is20FPS", 0);

        Green = new Color(0, 1, 0);
        Red = new Color(1, 0, 0);
        if (PlayerPrefs.GetInt("FPSCheck2") == 1)
        {
            Timer2 = 45;
            OffOptimize.color = Red;
            isDeleteSea = true;
            playerController2.isOptimize = true;
            for (int i = 0; i < graundControllers.Length; i++)
            {
                graundControllers[i].isOptimize = true;
            }
            for (int i = 0; i < Sea.Length; i++)
            {
                Destroy(Sea[i]);
            }
        } else OffOptimize.color = Green;

        if (PlayerPrefs.GetInt("is20FPS") == 1)
        {
            is20FPS = false;
            //Off20FPS.color = Red;
        }
        else; //Off20FPS.color = Green;
    }

    public void OffOnFPSCheck()
    {
        if(PlayerPrefs.GetInt("FPSCheck") == 1)
        {
            PlayerPrefs.SetInt("FPSCheck", 0);
            PlayerPrefs.SetInt("FPSCheck2", 0);
            OffOptimize.color = Green;
            playerController2.isOptimize = false;
            for (int i = 0; i < graundControllers.Length; i++)
            {
                graundControllers[i].isOptimize = false;
            }
            return;
        }

        if (PlayerPrefs.GetInt("FPSCheck") == 0)
        {
            PlayerPrefs.SetInt("FPSCheck", 1);
            OffOptimize.color = Red;
            isDeleteSea = true;
            playerController2.isOptimize = true;
            for (int i = 0; i < graundControllers.Length; i++)
            {
                graundControllers[i].isOptimize = true;
            }
            for (int i = 0; i < Sea.Length; i++)
            {
                Destroy(Sea[i]);
            }
            return;
        }
    }

    public void OffOn20FPSTrigger()
    {
        if (PlayerPrefs.GetInt("is20FPS") == 0)
        {
            is20FPS = false;
            //Off20FPS.color = Red;
            PlayerPrefs.SetInt("is20FPS", 1);
            return;
        }
        if (PlayerPrefs.GetInt("is20FPS") == 1)
        {
            is20FPS = true;
            //Off20FPS.color = Green;
            PlayerPrefs.SetInt("is20FPS", 0);
            return;
        }
    }

    public void OpenCloseSettings()
    {
        if (Setting.activeSelf == true) Setting.SetActive(false);
        else Setting.SetActive(true);
    }

    public void OneButtom()
    {
        OffOnFPSCheck();
        OffOn20FPSTrigger();
    }
}
