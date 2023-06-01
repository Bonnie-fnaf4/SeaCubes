using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAndMoney : MonoBehaviour
{
    public int money, level;

    public int idColorLevel, idTypeLevel;
    public PlayerController2 playerController2;

    public Text moneyText, levelText;

    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        if (PlayerPrefs.GetInt("Level") <= 0) PlayerPrefs.SetInt("Level", 1);
        level = PlayerPrefs.GetInt("Level");

        moneyText.text = "Money: " + money;
        levelText.text = "Level " + level;

        idColorLevel = PlayerPrefs.GetInt("ColorLevel");
        idTypeLevel = PlayerPrefs.GetInt("TypeColorLevel");

        playerController2.SwitchColorFromStorage(idTypeLevel, idColorLevel);
    }

    public void UpLevel()
    {
        level++;
        money += 350;

        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Level", level);

        moneyText.text = "Money: " + money;
        levelText.text = "Level " + level;
    }
}
