using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Screen_Visualizer : MonoBehaviour
{
    public TextMeshProUGUI integrity, lockState;
    public int timeLeft;
    float value;
    public GameObject gm;
    void Update()
    {
        timeLeft = gm.GetComponent<GameManager>().timeLeft;
        if (timeLeft > 300)
        {
            value = (float)0.000025 * (float)timeLeft * (float)timeLeft + (float)0.01 * (float)timeLeft;
            integrity.text = "%"+Math.Floor(value).ToString();
        }
        else
        {
            integrity.text = "Collapse Imminent";
        }
        if (value < 33)
        {
            integrity.color = Color.red;
        }else if (value < 66)
        {
            integrity.color = Color.yellow;
        }
        
    }
}
