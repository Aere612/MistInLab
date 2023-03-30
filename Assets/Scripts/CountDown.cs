using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour //16
{
    public int timeLeft=1800;
    void Start()
    {
        StartCoroutine(Countdown());
    }
    void GameOver()
    {
        //game over
    }
    IEnumerator Countdown()
    {
        while (timeLeft>=1)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        GameOver();
    }
}