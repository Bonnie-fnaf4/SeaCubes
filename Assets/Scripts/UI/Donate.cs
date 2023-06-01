using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donate : MonoBehaviour
{
    public GameObject DonatePanel;

    public void OpenPanel()
    {
        if(DonatePanel.activeSelf == false ) DonatePanel.SetActive(true);
        else DonatePanel.SetActive(false);
    }

    public void OpenBrowser()
    {
        Application.OpenURL("https://www.donationalerts.com/r/bonni_fnaf4");
    }
}
