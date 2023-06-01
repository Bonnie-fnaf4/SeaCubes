using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public Slider slider;
    public PlayerController2 playerController2;

    private void Update()
    {
        if (!playerController2.isOptimize) slider.value = playerController2.affectedBodiesCount();
        if (playerController2.isOptimize) slider.value = playerController2.affectedBodiesCountNoLevelApp + playerController2.affectedBodiesCount();
    }
}
